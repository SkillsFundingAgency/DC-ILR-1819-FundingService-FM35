using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Organisation.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes.Model;
using ESFA.DC.ILR.FundingService.FM35.Service.Builders;
using ESFA.DC.ILR.FundingService.FM35.Service.Interface.Builders;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.OPA.Model;
using ESFA.DC.OPA.Model.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FundingService.FM35.Service.Tests.Builders
{
    public class DataEntityBuilderTests
    {
        #region Global Entity

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_EntityNameCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.EntityName.Should().Be("global");
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - IsGlobal True"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_IsGlobal()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.IsGlobal.Should().BeTrue();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Children Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ChildrenCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ParentCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attribute Count"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributeCount()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Count.Should().Be(4);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesCorrect()
        {
            //ARRANGE
            var expectedAttributes = ExpectedGlobalAttributes();

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Test Helpers

        private IDataEntity SetupGlobalEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var globalBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return globalBuilder.GlobalEntity(12345678);
        }

        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l =>
                l.LARSCurrentVersion == "Version_005"
                && l.PostcodeCurrentVersion == "Version_003"
                && l.OrgVersion == "Version_002"
                && l.OrgFunding == new Dictionary<int, IEnumerable<OrgFunding>>
                {
                    { 12345678, new List<OrgFunding>
                        {
                            new OrgFunding
                            {
                                UKPRN = 12345678,
                                OrgFundFactor = "Factor",
                                OrgFundFactType = "FactorType",
                                OrgFundFactValue = "1.918",
                                OrgFundEffectiveFrom = new DateTime(2018, 01, 01),
                            }
                        }
                    }
                }
                && l.LARSLearningDelivery == new Dictionary<string, LARSLearningDelivery>
                {
                    { "123456", new LARSLearningDelivery
                        {
                            LearnAimRef = "123456",
                            EnglandFEHEStatus = "EnglandStatus",
                            EnglPrscID = 100,
                            FrameworkCommonComponent = 20,
                        }
                    }
                }
                && l.SfaAreaCost == new Dictionary<string, IEnumerable<SfaAreaCost>>
                {
                    { "CV1 2WT", new List<SfaAreaCost>
                        {
                            new SfaAreaCost
                            {
                                Postcode = "CV1 2WT",
                                EffectiveFrom = DateTime.Parse("2000-08-30"),
                                AreaCostFactor = 1.2m,
                            }
                        }
                    }
                }
                && l.LARSFunding == new Dictionary<string, IEnumerable<LARSFunding>>
                {
                    {
                        "123456", new List<LARSFunding>
                        {
                            new LARSFunding
                            {
                                LearnAimRef = "123456",
                                EffectiveFrom = DateTime.Parse("2010-08-30"),
                                WeightingFactor = "B",
                                RateUnWeighted = 0.5m,
                                RateWeighted = 12345m,
                                FundingCategory = "Matrix",
                            }
                        }
                    }
                });
        }

        private IDictionary<string, IAttributeData> ExpectedGlobalAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "UKPRN", new AttributeData("UKPRN", 12345678) },
                { "LARSVersion", new AttributeData("LARSVersion", "Version_005") },
                { "OrgVersion", new AttributeData("OrgVersion", "Version_002") },
                { "PostcodeDisadvantageVersion", new AttributeData("PostcodeDisadvantageVersion", "Version_003") },
            };
        }

        #endregion
    }
}
