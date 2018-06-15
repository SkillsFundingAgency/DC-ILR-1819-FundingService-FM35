﻿using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Interface;
using ESFA.DC.ILR.FundingService.FM35.InternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.OrchestrationService.Interface;
using ESFA.DC.ILR.FundingService.FM35.Stubs.Persistance;
using ESFA.DC.ILR.FundingService.FM35.TaskProvider.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.IO.Dictionary;
using ESFA.DC.IO.Interfaces;
using ESFA.DC.Serialization.Xml;

namespace ESFA.DC.ILR.FundingService.FM35.TaskProvider.Service
{
    public class TaskProviderService : ITaskProviderService
    {
        private readonly IKeyValuePersistenceService _keyValuePersistenceService;
        private readonly IInternalDataCache _internalDataCache;
        private readonly IPreFundingFM35OrchestrationService _preFundingFM35OrchestrationService;
        private readonly IFM35OrchestrationService _fm35OrchestrationService;

        public TaskProviderService(IKeyValuePersistenceService keyValuePersistenceService, IInternalDataCache internalDataCache, IPreFundingFM35OrchestrationService preFundingFM35OrchestrationService, IFM35OrchestrationService fm35OrchestrationService)
        {
            _keyValuePersistenceService = keyValuePersistenceService;
            _internalDataCache = internalDataCache;
            _preFundingFM35OrchestrationService = preFundingFM35OrchestrationService;
            _fm35OrchestrationService = fm35OrchestrationService;
        }

        public void ExecuteTasks(Message message)
        {
            // Build Persistance Dictionary
            BuildKeyValueDictionary(message);

            // pre funding
            var learnersToProcess = _preFundingFM35OrchestrationService.Execute();

            // process funding
            var fundingOutputs = ProcessFunding(learnersToProcess);

            // transform shards in to new object
            // var fundingOutputsToPersist = TransformFundingOutput(fundingOutputs);

            // persist
            DataPersister dataPersister = new DataPersister();
            dataPersister.PersistData(fundingOutputs);
        }

        private void BuildKeyValueDictionary(Message message)
        {
            var learners = message.Learner.ToList();

            var list = new DictionaryKeyValuePersistenceService();
            var serializer = new XmlSerializationService();

            _keyValuePersistenceService.SaveAsync("ValidLearnRefNumbers", serializer.Serialize(learners)).Wait();
        }

        private IFM35FundingOutputs ProcessFunding(IEnumerable<IList<ILearner>> learnersList)
        {
            int ukprn = _internalDataCache.UKPRN;
            IList<IFM35FundingOutputs> fundingOutputsList = new List<IFM35FundingOutputs>();

            foreach (var list in learnersList)
            {
                fundingOutputsList.Add(_fm35OrchestrationService.Execute(ukprn, list));
            }

            //TODO: call in to funding outputs transformation and return object

            return fundingOutputsList.Single();
        }

        //private IFM35FundingOutputs TransformFundingOutput(IFM35FundingOutputs fundingOutputsList)
        //{
        //    var global = fundingOutputsList.Global;

        //    var learnerAttributes = fundingOutputsList.SelectMany(f => f.SelectMany(l => l.Learners)).ToArray();

        //    return new FundingOutput.Model.FM35FundingOutputs
        //    {
        //        Global = global,
        //        Learners = learnerAttributes,
        //    };
        //}
    }
}
