//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Serialization;
//using ESFA.DC.ILR.FundingService.FM35.Contexts;
//using ESFA.DC.ILR.FundingService.FM35.Contexts.Interface;
//using ESFA.DC.ILR.FundingService.FM35.ExternalData;
//using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
//using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Interface;
//using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Service;
//using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Service.Interface;
//using ESFA.DC.ILR.FundingService.FM35.InternalData;
//using ESFA.DC.ILR.FundingService.FM35.InternalData.Interface;
//using ESFA.DC.ILR.FundingService.FM35.Service.Builders;
//using ESFA.DC.ILR.FundingService.FM35.Service.Interface.Builders;
//using ESFA.DC.ILR.Model;
//using ESFA.DC.ILR.Model.Interface;
//using ESFA.DC.IO.Dictionary;
//using ESFA.DC.IO.Interfaces;
//using ESFA.DC.OPA.Model.Interface;
//using ESFA.DC.OPA.Service.Interface;
//using ESFA.DC.Serialization.Interfaces;
//using ESFA.DC.Serialization.Json;
//using FluentAssertions;
//using Xunit;

//namespace ESFA.DC.ILR.FundingService.FM35.Service.Tests
//{
//    public class FundingServiceTests
//    {
//        /// <summary>
//        /// Return FundingOutputs from the Funding Service
//        /// </summary>
//        [Fact(DisplayName = "ProcessFunding - FundingOutput Exists"), Trait("Funding Service", "Unit")]
//        public void ProcessFunding_Exists()
//        {
//            // ARRANGE
//            // Use Test Helpers

//            // ACT
//            var fundingOutput = RunFundingService();

//            // ASSERT
//            fundingOutput.Should().NotBeNull();
//        }

//        #region Test Helpers

//        private readonly IOPAService opaService =
//            new OPAService(_sessionBuilder, _dataEntityBuilder, MockRulebaseProviderFactory());

//        private IEnumerable<IFM35FundingOutputs> RunFundingService()
//        {
//            IMessage message = ILRFile(@"Files\ILR-10006341-1819-20180607-102124-03.xml");
//            IFundingContext fundingContext = SetupFundingContext(message);

//            IReferenceDataCache referenceDataCache = new ReferenceDataCache();
//            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
//            IReferenceDataCachePopulationService referenceDataCachePopulationService = new ReferenceDataCachePopulationService(referenceDataCache, LARSMock().Object, PostcodesMock().Object);
//            IDataEntityBuilder dataEntityBuilder = new DataEntityBuilder(referenceDataCache, attributeBuilder);
//            IFundingOutputService fundingOutputService = new FundingOutputService();
//            IInternalDataCache validALBLearnersCache = new InternalDataCache();

//            var fundingService = new FundingService(dataEntityBuilder, opaService, fundingOutputService);

//            var preFundingOrchestrationService = new PreFundingFM35PopulationService(referenceDataCachePopulationService, fundingContext, validALBLearnersCache);
//            preFundingOrchestrationService.PopulateData();

//            return fundingService.ProcessFunding(fundingContext.UKPRN, validALBLearnersCache.ValidLearners);
//        }

//        private IFundingContext SetupFundingContext(IMessage message)
//        {
//            IKeyValuePersistenceService keyValuePersistenceService = BuildKeyValueDictionary(message);
//            IJsonSerializationService serializationService = new JsonSerializationService();
//            IFundingContextManager fundingContextManager = new FundingContextManager(JobContextMessage, keyValuePersistenceService, serializationService);

//            return new FundingContext(fundingContextManager);
//        }

//        private static DictionaryKeyValuePersistenceService BuildKeyValueDictionary(IMessage message)
//        {
//            var messageNew = (Message)message;

//            var learners = messageNew.Learner.ToList();

//            var list = new DictionaryKeyValuePersistenceService();
//            var serializer = new JsonSerializationService();

//            list.SaveAsync("ValidLearnRefNumbers", serializer.Serialize(learners)).Wait();

//            return list;
//        }

//        private Message ILRFile(string filePath)
//        {
//            Message message;
//            Stream stream = new FileStream(filePath, FileMode.Open);

//            using (var reader = XmlReader.Create(stream))
//            {
//                var serializer = new XmlSerializer(typeof(Message));
//                message = serializer.Deserialize(reader) as Message;
//            }

//            stream.Close();

//            return message;
//        }

//        #endregion
//    }
//}
