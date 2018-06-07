using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.Service.Interface.Builders;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.OPA.Model;
using ESFA.DC.OPA.Model.Interface;

namespace ESFA.DC.ILR.FundingService.FM35.Service.Builders
{
    public class DataEntityBuilder : IDataEntityBuilder
    {
        #region Constants

        private const string Entityglobal = "global";
        private const string EntityLearner = "Learner";
        private const string EntityLearningDelivery = "LearningDelivery";
        private const string EntityLearningDeliveryFAM = "LearningDeliveryFAM";
        private const string EntityLearningDeliverySFA_PostcodeAreaCost = "SFA_PostcodeAreaCost";
        private const string EntityLearningDeliveryLARS_Funding = "LearningDeliveryLARS_Funding";
        private const string LearningDeliveryFAMTypeADL = "ADL";
        private const string LearningDeliveryFAMTypeRES = "RES";

        #endregion

        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IAttributeBuilder<IAttributeData> _attributeBuilder;

        public DataEntityBuilder(IReferenceDataCache referenceDataCache, IAttributeBuilder<IAttributeData> attributeBuilder)
        {
            _referenceDataCache = referenceDataCache;
            _attributeBuilder = attributeBuilder;
        }

        public IEnumerable<IDataEntity> EntityBuilder(int ukprn, IEnumerable<ILearner> learners)
        {
            return new List<IDataEntity>();
        }

        #region Entity Builders

        protected internal IDataEntity GlobalEntity(int ukprn)
        {
            IDataEntity globalDataEntity = new DataEntity(Entityglobal)
            {
                Attributes =
                    _attributeBuilder.BuildGlobalAttributes(ukprn, _referenceDataCache.LARSCurrentVersion, _referenceDataCache.OrgVersion, _referenceDataCache.PostcodeCurrentVersion),
            };

            return globalDataEntity;
        }

        #endregion
    }
}
