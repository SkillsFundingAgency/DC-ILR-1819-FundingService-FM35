using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LargeEmployer.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Organisation.Model;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes.Model;
using ESFA.DC.ILR.FundingService.FM35.Service.Builders;
using ESFA.DC.ILR.FundingService.FM35.Service.Interface.Builders;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData;
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
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.EntityName.Should().Be("global");
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - IsGlobal True"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.IsGlobal.Should().BeTrue();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Children Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Children.Count.Should().Be(1);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attribute Count"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributeCount()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Attributes.Count.Should().Be(4);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedGlobalAttributes();

            // ACT
            var globalEntity = SetupGlobalEntity();

            // ASSERT
            globalEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region OrgFunding Entity

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.EntityName.Should().Be("OrgFunding");
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - IsGlobal False"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Children Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Parent.Should().BeNull(); // Null here because parent is created through AddChild Method.
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Entity Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Entity Attribute Count"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_AttributeCount()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Attributes.Count.Should().Be(5);
        }

        /// <summary>
        /// Return OrgFunding Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "OrgFunding - Entity Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_OrgFunding_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedOrgFundingAttributes();

            // ACT
            var orgEntity = SetupOrgEntity();

            // ASSERT
            orgEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Learner Entity

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_EntityNameCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.EntityName.Should().Be("Learner");
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_IsGlobal()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ChildrenCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Children.Count.Should().Be(1);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ParentCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCountCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Count.Should().Be(2);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCorrect()
        {
            //ARRANGE
            var expectedAttributes = ExpectedLearnerAttributes();

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
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

        private IDataEntity SetupOrgEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var orgBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            var orgFunding = referenceDataCacheMock.OrgFunding.Select(v => v.Value).First();

            return orgBuilder.OrgFundingEntity(orgFunding.First());
        }

        private IDataEntity SetupLearnerEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return learnerBuilder.LearnerEntity(TestLearner);
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
                                OrgFundEffectiveFrom = new DateTime(2018, 08, 01),
                                OrgFundEffectiveTo = new DateTime(2019, 07, 31),
                            }
                        }
                    }
                }
                 && l.LargeEmployers == new Dictionary<int, IEnumerable<LargeEmployers>>
                 {
                     {
                         99999, new List<LargeEmployers>
                         {
                            new LargeEmployers
                            {
                                ERN = 99999,
                                EffectiveFrom = new DateTime(2018, 05, 01),
                                EffectiveTo = null,
                            },
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

        private ILearner TestLearner => new MessageLearner
        {
            LearnRefNumber = "Learner1",
            DateOfBirthSpecified = true,
            DateOfBirth = new DateTime(2000, 01, 01),
            LearnerEmploymentStatus = new MessageLearnerLearnerEmploymentStatus[]
            {
                new MessageLearnerLearnerEmploymentStatus
                {
                    EmpIdSpecified = true,
                    EmpId = 99999,
                    AgreeId = "AgreeID",
                    EmpStat = 1,
                    DateEmpStatApp = new DateTime(2018, 08, 01),
                }
            }
        };

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

        private IDictionary<string, IAttributeData> ExpectedOrgFundingAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "OrgFundEffectiveTo", new AttributeData("OrgFundEffectiveTo", new DateTime(2019, 07, 31)) },
                { "OrgFundEffectiveFrom", new AttributeData("OrgFundEffectiveFrom", new DateTime(2018, 08, 01)) },
                { "OrgFundFactor", new AttributeData("OrgFundFactor", "Factor") },
                { "OrgFundFactValue", new AttributeData("OrgFundFactValue", "1.918") },
                { "OrgFundFactType", new AttributeData("OrgFundFactType", "FactorType") },
            };
        }

        private IDictionary<string, IAttributeData> ExpectedLearnerAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "LearnRefNumber", new AttributeData("LearnRefNumber", "Learner1") },
                { "DateOfBirth", new AttributeData("DateOfBirth", new DateTime(2000, 01, 01)) },
            };
        }

        #endregion
    }
}
