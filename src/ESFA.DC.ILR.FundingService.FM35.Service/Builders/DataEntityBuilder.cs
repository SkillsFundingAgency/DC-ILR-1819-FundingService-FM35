﻿using System;
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
        private const string EntityLearningDeliveryLARS_AnnualValue = "LearningDeliveryAnnualValue";
        private const string EntityLearningDeliveryLARS_Category = "LearningDeliveryLARSCategory";
        private const string EntityLearningDeliveryLARS_Funding = "LearningDeliveryLARS_Funding";
        private const string LearningDeliveryFAMTypeEEF = "EEF";
        private const string LearningDeliveryFAMTypeFFI = "FFI";
        private const string LearningDeliveryFAMTypeRES = "RES";
        private const string LearningDeliveryFAMTypeLDM1 = "LDM1";
        private const string LearningDeliveryFAMTypeLDM2 = "LDM2";
        private const string LearningDeliveryFAMTypeLDM3 = "LDM3";
        private const string LearningDeliveryFAMTypeLDM4 = "LDM4";

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
            var globalEntities = learners.Select(learner =>
            {
                // Global Entity
                IDataEntity globalEntity = GlobalEntity(ukprn);

                // Learner Entity
                IDataEntity learnerEntity = LearnerEntity(learner);

                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    _referenceDataCache.LARSLearningDelivery.TryGetValue(learningDelivery.LearnAimRef, out LARSLearningDelivery larsLearningDelivery);
                    _referenceDataCache.LARSFrameworkAims.TryGetValue(learningDelivery.LearnAimRef, out IEnumerable<LARSFrameworkAims> larsFrameworkAims);
                    IDataEntity learningDeliveryEntity = LearningDeliveryEntity(learningDelivery, larsLearningDelivery, larsFrameworkAims);

                    learnerEntity.AddChild(learningDeliveryEntity);
                }

                globalEntity.AddChild(learnerEntity);

                return globalEntity;
            }).AsParallel();

            return globalEntities;
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

        protected internal IDataEntity LearningDeliveryEntity(ILearningDelivery learningDelivery, LARSLearningDelivery larsLearningDelivery, IEnumerable<LARSFrameworkAims> larsFrameworkAims)
        {
            var learningDeliveryFAMS = PivotLearningDeliveryFAMS(learningDelivery);

            var frameworkComponentType = larsFrameworkAims
                .Where(fwa =>
                    learningDelivery.FworkCodeNullable == fwa.FworkCode
                    && learningDelivery.ProgTypeNullable == fwa.ProgType
                    && learningDelivery.PwayCodeNullable == fwa.PwayCode)
                .Select(fwct => fwct.FrameworkComponentType).FirstOrDefault();

            IDataEntity learningDeliveryEntity = new DataEntity(EntityLearningDelivery)
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
                        frameworkComponentType,
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

            foreach (var learningDeliveryFAM in learningDelivery.LearningDeliveryFAMs)
            {
                IDataEntity learningDeliveryFAMEntity = LearningDeliveryFAMEntity(learningDeliveryFAM);

                learningDeliveryEntity.AddChild(learningDeliveryFAMEntity);
            }

            if (_referenceDataCache.LARSAnnualValue.ContainsKey(learningDelivery.LearnAimRef))
            {
                learningDeliveryEntity.AddChildren(
                    _referenceDataCache.LARSAnnualValue[learningDelivery.LearnAimRef]
                        .Select(larsAnnualValue => LARSAnnualValueEntity(larsAnnualValue)));
            }

            if (_referenceDataCache.LARSFunding.ContainsKey(learningDelivery.LearnAimRef))
            {
                learningDeliveryEntity.AddChildren(
                    _referenceDataCache.LARSFunding[learningDelivery.LearnAimRef]
                        .Select(larsFunding => LARSFundingEntity(larsFunding)));
            }

            if (_referenceDataCache.LARSLearningDeliveryCatgeory.ContainsKey(learningDelivery.LearnAimRef))
            {
                learningDeliveryEntity.AddChildren(
                    _referenceDataCache.LARSLearningDeliveryCatgeory[learningDelivery.LearnAimRef]
                        .Select(larsCategory => LARSLearningDeliveryCategoryEntity(larsCategory)));
            }

            if (_referenceDataCache.SfaAreaCost.ContainsKey(learningDelivery.DelLocPostCode))
            {
                learningDeliveryEntity.AddChildren(
                    _referenceDataCache.SfaAreaCost[learningDelivery.DelLocPostCode]
                        .Select(sfaAreaCost => SFAAreaCostEntity(sfaAreaCost)));
            }

            return learningDeliveryEntity;
        }

        protected internal IDataEntity LearningDeliveryFAMEntity(ILearningDeliveryFAM learningDeliveryFam)
        {
            IDataEntity learningDeliveryFAMDataEntity = new DataEntity(EntityLearningDeliveryFAM)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliveryFAMAttributes(
                        learningDeliveryFam.LearnDelFAMCode,
                        learningDeliveryFam.LearnDelFAMDateFromNullable,
                        learningDeliveryFam.LearnDelFAMDateToNullable,
                        learningDeliveryFam.LearnDelFAMType),
            };

            return learningDeliveryFAMDataEntity;
        }

        protected internal IDataEntity LARSAnnualValueEntity(LARSAnnualValue larsAnnualValue)
        {
            var larsAnnualValueEntity = new DataEntity(EntityLearningDeliveryLARS_AnnualValue)
            {
                Attributes = _attributeBuilder.BuildLearningDeliveryLARSAnnualValueAttributes(
                    larsAnnualValue.BasicSkillsType,
                    larsAnnualValue.EffectiveFrom,
                    larsAnnualValue?.EffectiveTo)
            };

            return larsAnnualValueEntity;
        }

        protected internal IDataEntity LARSFundingEntity(LARSFunding larsFunding)
        {
            var larsFundingDataEntity = new DataEntity(EntityLearningDeliveryLARS_Funding)
            {
                Attributes = _attributeBuilder.BuildLearningDeliveryLarsFundingAttributes(
                    larsFunding.FundingCategory,
                    larsFunding.EffectiveFrom,
                    larsFunding?.EffectiveTo,
                    larsFunding.RateUnWeighted,
                    larsFunding.RateWeighted,
                    larsFunding.WeightingFactor),
            };

            return larsFundingDataEntity;
        }

        protected internal IDataEntity LARSLearningDeliveryCategoryEntity(LARSLearningDeliveryCategory larsLearningDeliveryCategory)
        {
            var larsLearningDeliveryCategoryEntity = new DataEntity(EntityLearningDeliveryLARS_Category)
            {
                Attributes = _attributeBuilder.BuildLearningDeliveryLARSCategoryAttributes(
                    larsLearningDeliveryCategory.CategoryRef,
                    larsLearningDeliveryCategory.EffectiveFrom,
                    larsLearningDeliveryCategory?.EffectiveTo)
            };

            return larsLearningDeliveryCategoryEntity;
        }

        protected internal IDataEntity SFAAreaCostEntity(SfaAreaCost sfaAreaCost)
        {
            var sfaAreaCostDataEntity = new DataEntity(EntityLearningDeliverySFA_PostcodeAreaCost)
            {
                Attributes =
                _attributeBuilder.BuildLearningDeliverySfaAreaCostAttributes(
                        sfaAreaCost?.EffectiveFrom,
                        sfaAreaCost?.EffectiveTo,
                        sfaAreaCost.AreaCostFactor),
            };

            return sfaAreaCostDataEntity;
        }

        #endregion

        #region Functions

        protected internal LearningDeliveryFAMPivot PivotLearningDeliveryFAMS(ILearningDelivery learningDelivery)
        {
            var ldmKey = 1;
            var famDictionary = learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains("LDM"))
                    .ToDictionary(k => "LDM" + ldmKey++, ldf => ToNullableInt(ldf.LearnDelFAMCode));

            famDictionary.Add(
                LearningDeliveryFAMTypeEEF,
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains(LearningDeliveryFAMTypeEEF)).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));
            famDictionary.Add(
                LearningDeliveryFAMTypeFFI,
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains(LearningDeliveryFAMTypeFFI)).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));
            famDictionary.Add(
                LearningDeliveryFAMTypeRES,
                ToNullableInt(learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains(LearningDeliveryFAMTypeRES)).Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault()));

            var pivot = new LearningDeliveryFAMPivot
            {
                EEF = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeEEF).Select(v => v.Value).FirstOrDefault(),
                FFI = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeFFI).Select(v => v.Value).FirstOrDefault(),
                RES = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeRES).Select(v => v.Value).FirstOrDefault(),
                LDM1 = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeLDM1).Select(v => v.Value).FirstOrDefault(),
                LDM2 = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeLDM2).Select(v => v.Value).FirstOrDefault(),
                LDM3 = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeLDM3).Select(v => v.Value).FirstOrDefault(),
                LDM4 = famDictionary.Where(k => k.Key == LearningDeliveryFAMTypeLDM4).Select(v => v.Value).FirstOrDefault(),
            };

            return pivot;
        }

        private static int? ToNullableInt(string stringValue)
        {
            if (int.TryParse(stringValue, out int i))
            {
                return i;
            }

            return null;
        }

        #endregion
    }
}
