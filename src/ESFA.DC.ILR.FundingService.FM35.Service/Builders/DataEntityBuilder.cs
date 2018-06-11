using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LargeEmployer.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Organisation.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes.Model;
using ESFA.DC.ILR.FundingService.FM35.Service.Interface.Builders;
using ESFA.DC.ILR.FundingService.FM35.Service.Models;
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
        private const string EntitySFAPostcodeDisadvantageEntity = "SFA_PostcodeDisadvantage";
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

            var sfaPostcodeDisadvantageData = _referenceDataCache.SfaDisadvantage.Where(k => k.Key == learner.PostcodePrior).Select(v => v.Value).Single();

            foreach (var postcode in sfaPostcodeDisadvantageData)
            {
                learnerDataEntity.AddChild(SFAPostcodeDisadvantageEntity(postcode));
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

        protected internal IDataEntity SFAPostcodeDisadvantageEntity(SfaDisadvantage postcodeData)
        {
            IDataEntity sfaPostcodeDisadvantgeEntity = new DataEntity(EntitySFAPostcodeDisadvantageEntity)
            {
                Attributes =
                        _attributeBuilder.BuildSFAPostcodeDisadvantageAttributes(postcodeData.Uplift, postcodeData.EffectiveFrom, postcodeData.EffectiveTo),
            };

            return sfaPostcodeDisadvantgeEntity;
        }

        protected internal IDataEntity LearningDeliveryEntity(ILearningDelivery learningDelivery, LARSLearningDelivery larsLearningDelivery, LARSFrameworkAims larsFrameworkAims)
        {
            var learningDeliveryFAMS = PivotLearningDeliveryFAMS(learningDelivery);

            IDataEntity learningDeliveryDataEntity = new DataEntity(EntityLearningDelivery)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliveryAttributes(
                        learningDelivery.AchDateNullable,
                        learningDelivery.AddHoursNullable,
                        learningDelivery.AimSeqNumber,
                        learningDelivery.AimType,
                        learningDelivery.CompStatus,
                        learningDelivery.EmpOutcomeNullable,
                        larsLearningDelivery.EnglandFEHEStatus,
                        larsLearningDelivery.EnglPrscID,
                        learningDelivery.FworkCodeNullable,
                        larsLearningDelivery.FrameworkCommonComponent,
                        larsFrameworkAims.FrameworkComponentType,
                        learningDelivery.LearnActEndDateNullable,
                        learningDelivery.LearnPlanEndDate,
                        learningDelivery.LearnStartDate,
                        learningDeliveryFAMS.EEF,
                        learningDeliveryFAMS.LDM1,
                        learningDeliveryFAMS.LDM2,
                        learningDeliveryFAMS.LDM3,
                        learningDeliveryFAMS.LDM4,
                        learningDeliveryFAMS.FFI,
                        learningDeliveryFAMS.RES,
                        learningDelivery.OrigLearnStartDateNullable,
                        learningDelivery.OtherFundAdjNullable,
                        learningDelivery.OutcomeNullable,
                        learningDelivery.PriorLearnFundAdjNullable,
                        learningDelivery.ProgTypeNullable,
                        learningDelivery.PwayCodeNullable)
            };

            return learningDeliveryDataEntity;
        }

        #endregion

        protected internal LearningDeliveryFAMPivot PivotLearningDeliveryFAMS(ILearningDelivery learningDelivery)
        {
            var ldmKey = 1;
            var famDictionary = learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains("LDM"))
                    .ToDictionary(k => "LDM" + ldmKey++, ldf => ToNullableInt(ldf.LearnDelFAMCode));

            famDictionary.Add(
                "EEF",
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains("EEF")).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));
            famDictionary.Add(
                "FFI",
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains("FFI")).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));
            famDictionary.Add(
                "RES",
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains("RES")).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));

            var pivot = new LearningDeliveryFAMPivot
            {
                EEF = famDictionary.Where(k => k.Key == "EEF").Select(v => v.Value).FirstOrDefault(),
                FFI = famDictionary.Where(k => k.Key == "FFI").Select(v => v.Value).FirstOrDefault(),
                RES = famDictionary.Where(k => k.Key == "RES").Select(v => v.Value).FirstOrDefault(),
                LDM1 = famDictionary.Where(k => k.Key == "LDM1").Select(v => v.Value).FirstOrDefault(),
                LDM2 = famDictionary.Where(k => k.Key == "LDM2").Select(v => v.Value).FirstOrDefault(),
                LDM3 = famDictionary.Where(k => k.Key == "LDM3").Select(v => v.Value).FirstOrDefault(),
                LDM4 = famDictionary.Where(k => k.Key == "LDM4").Select(v => v.Value).FirstOrDefault(),
            };

            return pivot;
        }

        private static int? ToNullableInt(string stringValue)
        {
            int i;
            if (int.TryParse(stringValue, out i))
            {
                return i;
            }

            return null;
        }
    }
}
