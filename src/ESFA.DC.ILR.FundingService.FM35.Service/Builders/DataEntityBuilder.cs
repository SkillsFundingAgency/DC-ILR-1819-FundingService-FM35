using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LargeEmployer.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Organisation.Model;
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
        private const string EntityOrgFunding = "OrgFunding";
        private const string EntityLearner = "Learner";
        private const string EntityLearnerEmploymentStatus = "LearnerEmploymentStatus";
        private const string EntityLargeEmployerReferenceData = "LargeEmployerReferenceData";
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
            //var globalEntities = learners.Select(learner =>
            //{
                //// Global Entity
                //IDataEntity globalEntity = GlobalEntity(ukprn);

                //// Learner Entity
                //IDataEntity learnerEntity = LearnerEntity(learner);
            }

        #region Entity Builders

        protected internal IDataEntity GlobalEntity(int ukprn)
        {
            IDataEntity globalDataEntity = new DataEntity(Entityglobal)
            {
                Attributes =
                    _attributeBuilder.BuildGlobalAttributes(ukprn, _referenceDataCache.LARSCurrentVersion, _referenceDataCache.OrgVersion, _referenceDataCache.PostcodeCurrentVersion),
            };

            var orgFunding = _referenceDataCache.OrgFunding.Where(k => k.Key == ukprn).Select(v => v.Value).Single();

            foreach (var o in orgFunding)
            {
                globalDataEntity.AddChild(OrgFundingEntity(o));
            }

            return globalDataEntity;
        }

        protected internal IDataEntity OrgFundingEntity(OrgFunding orgFunding)
        {
            IDataEntity orgFundingDataEnity = new DataEntity(EntityOrgFunding)
            {
                Attributes =
                    _attributeBuilder.BuildOrgFundingAttributes(
                        orgFunding.OrgFundEffectiveFrom,
                        orgFunding.OrgFundEffectiveTo,
                        orgFunding.OrgFundFactor,
                        orgFunding.OrgFundFactType,
                        orgFunding.OrgFundFactValue),
            };

            return orgFundingDataEnity;
        }

        protected internal IDataEntity LearnerEntity(ILearner learner)
        {
            IDataEntity learnerDataEntity = new DataEntity(EntityLearner)
            {
                Attributes =
                    _attributeBuilder.BuildLearnerAttributes(learner.LearnRefNumber, learner.DateOfBirthNullable),
            };

            foreach (var employmentStatus in learner.LearnerEmploymentStatuses)
            {
                IDataEntity learnerEmploymentStatusDataEntity = LearnerEmploymentStatusEntity(employmentStatus);

                learnerDataEntity.AddChild(learnerEmploymentStatusDataEntity);
            }

            return learnerDataEntity;
        }

        protected internal IDataEntity LearnerEmploymentStatusEntity(ILearnerEmploymentStatus employmentStatus)
        {
            IDataEntity learnerEmploymentStatusDataEntity = new DataEntity(EntityLearnerEmploymentStatus)
            {
                Attributes =
                   _attributeBuilder.BuildLearnerEmploymentStatusAttributes(employmentStatus.EmpIdNullable, employmentStatus.DateEmpStatApp),
            };

            var largeEmployers = _referenceDataCache.LargeEmployers
                   .Where(k => k.Key == employmentStatus.EmpIdNullable).Select(v => v.Value).Single();

            foreach (var lemp in largeEmployers)
            {
                IDataEntity largeEmployersDataEntity = LargeEmployersEntity(lemp);

                learnerEmploymentStatusDataEntity.AddChild(largeEmployersDataEntity);
            }

            return learnerEmploymentStatusDataEntity;
        }

        protected internal IDataEntity LargeEmployersEntity(LargeEmployers largeEmployer)
        {
            IDataEntity largeEmployersDataEntity = new DataEntity(EntityLargeEmployerReferenceData)
            {
                Attributes =
                        _attributeBuilder.BuildLLargeEmployerReferenceDataAttributes(largeEmployer.EffectiveFrom, largeEmployer.EffectiveTo),
            };

            return largeEmployersDataEntity;
        }

        #endregion
    }
}
