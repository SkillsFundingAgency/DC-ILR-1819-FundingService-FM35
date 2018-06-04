using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Implementation;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.Tests.ExternalCache
{
    public class ReferenceDataCacheTests
    {
        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does exist"), Trait("LARS", "Unit")]
        public void LARSFunding_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSFunding.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSAnnualValue - Does exist"), Trait("LARS", "Unit")]
        public void LARSAnnualValue_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSAnnualValue.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSFrameworkAims - Does exist"), Trait("LARS", "Unit")]
        public void LARSFrameworkAims_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSFrameworkAims.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSLearningDeliveryCatgeory - Does exist"), Trait("LARS", "Unit")]
        public void LARSLearningDeliveryCatgeory_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSLearningDeliveryCatgeory.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSLearningDelivery.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data from Reference Data Cache.
        /// </summary>
        [Fact(DisplayName = "LARSCurrentVersion - Does exist"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var referenceDataCache = SetupReferenceDataCache();

            // ASSERT
            referenceDataCache.LARSCurrentVersion.Should().NotBeNull();
        }

        #region Test Helpers

        private IReferenceDataCache SetupReferenceDataCache()
        {
            IReferenceDataCache referenceDataCache = new ReferenceDataCache
            {
                LARSFunding = new Dictionary<string, IEnumerable<LARSFunding>>
                {
                    { "123456",  LARSFundingList(LARSFundingTestValue) },
                },
                LARSCurrentVersion = LARSCurrentVersion,
                LARSLearningDelivery = new Dictionary<string, LARSLearningDelivery>
                {
                    { "123456", LARSLearningDeliveryTestValue },
                },
                LARSAnnualValue = new Dictionary<string, IEnumerable<LARSAnnualValue>>
                {
                    { "123456", LARSAnnualValueList(LARSAnnualValueTestValue) },
                },
                LARSFrameworkAims = new Dictionary<string, IEnumerable<LARSFrameworkAims>>
                {
                    { "123456", LARSFrameworkAimsList(LARSFrameworkAimsTestValue) },
                },
                LARSLearningDeliveryCatgeory = new Dictionary<string, IEnumerable<LARSLearningDeliveryCategory>>
                {
                    { "123456", LARSLearningDeliveryCategoryList(LARSLearningDeliveryCategoryTestValue) },
                },
                //PostcodeCurrentVersion = PostcodesCurrentVersion,
                //SfaAreaCost = new Dictionary<string, IEnumerable<SfaAreaCost>>
                //    {
                //        { "CV1 2WT", SFAAreaCostList(sfaAreaCostTestValue) }
                //    }
            };

            return referenceDataCache;
        }

        private static readonly string LARSCurrentVersion = "Version_005";

        private static readonly LARSFunding LARSFundingTestValue =
           new LARSFunding()
           {
               EffectiveFrom = DateTime.Parse("2000-01-01"),
               EffectiveTo = null,
               FundingCategory = "Matrix",
               LearnAimRef = "123456",
               RateWeighted = 1.5m,
               RateUnWeighted = 0.5m,
               WeightingFactor = "W-Factor",
           };

        private static readonly LARSLearningDelivery LARSLearningDeliveryTestValue =
             new LARSLearningDelivery()
             {
                 LearnAimRef = "123456",
                 EnglandFEHEStatus = "F",
                 EnglPrscID = 2,
                 FrameworkCommonComponent = 100,
             };

        private static readonly LARSAnnualValue LARSAnnualValueTestValue =
           new LARSAnnualValue()
           {
               LearnAimRef = "123456",
               EffectiveFrom = DateTime.Parse("2000-01-01"),
               EffectiveTo = null,
               BasicSkillsType = 200,
           };

        private static readonly LARSFrameworkAims LARSFrameworkAimsTestValue =
           new LARSFrameworkAims()
           {
               LearnAimRef = "123456",
               FrameworkComponentType = 1,
               ProgType = 2,
               FworkCode = 3,
               PwayCode = 4,
               EffectiveFrom = DateTime.Parse("2000-01-01"),
           };

        private static readonly LARSLearningDeliveryCategory LARSLearningDeliveryCategoryTestValue =
           new LARSLearningDeliveryCategory()
           {
               LearnAimRef = "123456",
               CategoryRef = 300,
               EffectiveFrom = DateTime.Parse("2000-01-01"),
               EffectiveTo = null,
           };

        private IList<LARSAnnualValue> LARSAnnualValueList(LARSAnnualValue larsAnnualValueData)
        {
            return new List<LARSAnnualValue>
            {
                larsAnnualValueData,
            };
        }

        private IList<LARSFunding> LARSFundingList(LARSFunding larsFundingData)
        {
            return new List<LARSFunding>
            {
                larsFundingData,
            };
        }

        private IList<LARSFrameworkAims> LARSFrameworkAimsList(LARSFrameworkAims larsFrameworkAimsData)
        {
            return new List<LARSFrameworkAims>
            {
                larsFrameworkAimsData,
            };
        }

        private IList<LARSLearningDeliveryCategory> LARSLearningDeliveryCategoryList(LARSLearningDeliveryCategory larsLearningDeliveryCategoryData)
        {
            return new List<LARSLearningDeliveryCategory>
            {
                larsLearningDeliveryCategoryData,
            };
        }

        #endregion
    }
}
