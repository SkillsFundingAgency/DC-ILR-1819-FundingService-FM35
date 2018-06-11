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
using ESFA.DC.ILR.FundingService.FM35.Service.Models;
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
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.EntityName.Should().Be("Learner");
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Children.Count.Should().Be(2);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Attributes.Count.Should().Be(2);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "Learner - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedLearnerAttributes();

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Learner Employment Status Entity

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.EntityName.Should().Be("LearnerEmploymentStatus");
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.Children.Count.Should().Be(1);
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEntity = SetupLearnerEntity();

            // ASSERT
            learnerEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerEmploymentStatus - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.Attributes.Count.Should().Be(2);
        }

        /// <summary>
        /// Return LearnerEmploymentStatus Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearnerLearnerEmploymentStatus - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearnerEmploymentStatus_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedLearnerEmpStatusAttributes();

            // ACT
            var learnerEmpStatusEntity = SetupLearnerEmploymentStatusEntity();

            // ASSERT
            learnerEmpStatusEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Large Employer Entity

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.EntityName.Should().Be("LargeEmployerReferenceData");
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Attributes.Count.Should().Be(2);
        }

        /// <summary>
        /// Return LargeEmployer Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LargeEmployer - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LargeEmployer_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedLargeEmployerAttributes();

            // ACT
            var largeEmployersEntity = SetupLargeEmployersEntity();

            // ASSERT
            largeEmployersEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region SFA PostcodeDisadvantage Entity

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.EntityName.Should().Be("SFA_PostcodeDisadvantage");
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Attributes.Count.Should().Be(3);
        }

        /// <summary>
        /// Return SFAPostcodeDisadvantage Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "SFAPostcodeDisadvantage - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_SFAPostcodeDisadvantage_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedSFAPostcodeDisadvantageAttributes();

            // ACT
            var sfaPostcodeDisadvantageEntity = SetupSFAPostcodeDisadvantageEntity();

            // ASSERT
            sfaPostcodeDisadvantageEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Pivot LearningDeliveryFAM Tests

        /// <summary>
        /// Return PivotLearningDeliveryFAMS Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "PivotLearningDeliveryFAMS - Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_PivotLearningDeliveryFAMS_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var famPivot = SetupPivotLearningDeliveryFAMS();

            // ASSERT
            famPivot.Should().NotBeNull();
        }

        /// <summary>
        /// Return PivotLearningDeliveryFAMS Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "PivotLearningDeliveryFAMS - Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_PivotLearningDeliveryFAMS_Correct()
        {
            // ARRANGE
            var expectedPivot = new LearningDeliveryFAMPivot
            {
                EEF = 2,
                FFI = 3,
                LDM1 = 100,
                LDM2 = 200,
                LDM3 = null,
                LDM4 = null,
                RES = 1
            };

            // ACT
            var famPivot = SetupPivotLearningDeliveryFAMS();

            // ASSERT
            famPivot.Should().BeEquivalentTo(expectedPivot);
        }

        #endregion

        #region LearningDelivery Entity

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.EntityName.Should().Be("LearningDelivery");
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_IsGlobal()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_ChildrenCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            /// ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Attributes.Count.Should().Be(27);
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesCorrect()
        {
            // ARRANGE
            var expectedAttributes = ExpectedLearningDeliveryAttributes();

            // ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            // ASSERT
            learningDeliveryEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
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

        private IDataEntity SetupLearnerEmploymentStatusEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return learnerBuilder.LearnerEmploymentStatusEntity(TestLearner.LearnerEmploymentStatuses.FirstOrDefault());
        }

        private IDataEntity SetupLargeEmployersEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            var lEmp = referenceDataCacheMock.LargeEmployers
                   .Where(k => k.Key == TestLearner.LearnerEmploymentStatuses.FirstOrDefault().EmpIdNullable)
                   .Select(v => v.Value).Single();

            return learnerBuilder.LargeEmployersEntity(lEmp.Single());
        }

        private IDataEntity SetupSFAPostcodeDisadvantageEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            var sfaPostcode = referenceDataCacheMock.SfaDisadvantage
                   .Where(k => k.Key == TestLearner.PostcodePrior)
                   .Select(v => v.Value).Single();

            return learnerBuilder.SFAPostcodeDisadvantageEntity(sfaPostcode.Single());
        }

        private LearningDeliveryFAMPivot SetupPivotLearningDeliveryFAMS()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return learnerBuilder.PivotLearningDeliveryFAMS(TestLearner.LearningDeliveries.Single());
        }

        private IDataEntity SetupLearningDeliveryEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            var larsLearningDelivery = referenceDataCacheMock.LARSLearningDelivery.Select(v => v.Value).FirstOrDefault();
            var larsFrameworkAims = referenceDataCacheMock.LARSFrameworkAims.Select(v => v.Value).FirstOrDefault();

            return learnerBuilder.LearningDeliveryEntity(TestLearner.LearningDeliveries.FirstOrDefault(), larsLearningDelivery, larsFrameworkAims.Single());
        }

        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l =>
                l.LARSCurrentVersion == "Version_005"
                && l.PostcodeCurrentVersion == "Version_003"
                && l.SfaDisadvantage == new Dictionary<string, IEnumerable<SfaDisadvantage>>
                {
                    {
                        "CV1 2WT", new List<SfaDisadvantage>
                        {
                            new SfaDisadvantage
                            {
                                Postcode = "CV1 2WT",
                                Uplift = 1.54m,
                                EffectiveFrom = new DateTime(2000, 01, 01),
                                EffectiveTo = null,
                            }
                        }
                    }
                }
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
                }
                && l.LARSFrameworkAims == new Dictionary<string, IEnumerable<LARSFrameworkAims>>
                {
                    {
                        "123456", new List<LARSFrameworkAims>
                        {
                            new LARSFrameworkAims
                            {
                                LearnAimRef = "123456",
                                EffectiveFrom = DateTime.Parse("2010-08-30"),
                                EffectiveTo = null,
                                FrameworkComponentType = 0,
                                FworkCode = 1,
                                ProgType = 2,
                                PwayCode = 3,
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
            PostcodePrior = "CV1 2WT",
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
            },
            LearningDelivery = new MessageLearnerLearningDelivery[]
            {
                TestLearningDelivery,
            }
        };

        private static readonly MessageLearnerLearningDelivery TestLearningDelivery = new MessageLearnerLearningDelivery
        {
            LearnAimRef = "123456",
            AchDateSpecified = true,
            AchDate = new DateTime(2018, 10, 01),
            AddHoursSpecified = true,
            AddHours = 20,
            AimSeqNumber = 1,
            AimType = 2,
            CompStatus = 3,
            DelLocPostCode = "CV1 2WT",
            EmpOutcomeSpecified = true,
            EmpOutcome = 4,
            FworkCodeSpecified = true,
            FworkCode = 20,
            LearnActEndDateSpecified = true,
            LearnActEndDate = DateTime.Parse("2018-10-01"),
            LearnStartDate = DateTime.Parse("2018-08-01"),
            LearnPlanEndDate = DateTime.Parse("2018-12-01"),
            OrigLearnStartDateSpecified = true,
            OrigLearnStartDate = DateTime.Parse("2018-08-01"),
            OtherFundAdjSpecified = false,
            OutcomeSpecified = true,
            Outcome = 1,
            PriorLearnFundAdjSpecified = false,
            ProgTypeSpecified = true,
            ProgType = 2,
            PwayCodeSpecified = true,
            PwayCode = 3,
            LearningDeliveryFAM = new[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "100",
                    LearnDelFAMType = "LDM",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-08-30"),
                    LearnDelFAMDateToSpecified = true,
                    LearnDelFAMDateTo = DateTime.Parse("2017-10-30")
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "200",
                    LearnDelFAMType = "LDM",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-10-31"),
                    LearnDelFAMDateToSpecified = true,
                    LearnDelFAMDateTo = DateTime.Parse("2018-11-30")
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "1",
                    LearnDelFAMType = "RES",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-12-01"),
                    LearnDelFAMDateToSpecified = false
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "2",
                    LearnDelFAMType = "EEF",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-12-01"),
                    LearnDelFAMDateToSpecified = false
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "3",
                    LearnDelFAMType = "FFI",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-12-01"),
                    LearnDelFAMDateToSpecified = false
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

        private IDictionary<string, IAttributeData> ExpectedLearnerEmpStatusAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "EmpId", new AttributeData("EmpId", 99999) },
                { "DateEmpStatApp", new AttributeData("DateEmpStatApp", new DateTime(2018, 08, 01)) },
            };
        }

        private IDictionary<string, IAttributeData> ExpectedLargeEmployerAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "LargeEmpEffectiveFrom", new AttributeData("LargeEmpEffectiveFrom", new DateTime(2018, 05, 01)) },
                { "LargeEmpEffectiveTo", new AttributeData("LargeEmpEffectiveTo", null) },
            };
        }

        private IDictionary<string, IAttributeData> ExpectedSFAPostcodeDisadvantageAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "DisUplift", new AttributeData("DisUplift",  1.54m) },
                { "DisUpEffectiveFrom", new AttributeData("DisUpEffectiveFrom", new DateTime(2000, 01, 01)) },
                { "DisUpEffectiveTo", new AttributeData("DisUpEffectiveTo", null) },
            };
        }

        private IDictionary<string, IAttributeData> ExpectedLearningDeliveryAttributes()
        {
            return new Dictionary<string, IAttributeData>
            {
                { "AchDate", new AttributeData("AchDate", new DateTime(2018, 10, 01)) },
                { "AddHours", new AttributeData("AddHours", 20) },
                { "AimSeqNumber", new AttributeData("AimSeqNumber", 1) },
                { "AimType", new AttributeData("AimType", 2) },
                { "CompStatus", new AttributeData("CompStatus", 3) },
                { "EmpOutcome", new AttributeData("EmpOutcome", 4) },
                { "EnglandFEHEStatus", new AttributeData("EnglandFEHEStatus", "EnglandStatus") },
                { "EnglPrscID", new AttributeData("EnglPrscID", 100) },
                { "FworkCode", new AttributeData("FworkCode", 20) },
                { "FrameworkCommonComponent", new AttributeData("FrameworkCommonComponent", 20) },
                { "FrameworkComponentType", new AttributeData("FrameworkComponentType", 0) },
                { "LearnActEndDate", new AttributeData("LearnActEndDate", new DateTime(2018, 10, 01)) },
                { "LearnPlanEndDate", new AttributeData("LearnPlanEndDate", new DateTime(2018, 12, 01)) },
                { "LearnStartDate", new AttributeData("LearnStartDate", new DateTime(2018, 08, 01)) },
                { "LrnDelFAM_EEF", new AttributeData("LrnDelFAM_EEF", 2) },
                { "LrnDelFAM_LDM1", new AttributeData("LrnDelFAM_LDM1", 100) },
                { "LrnDelFAM_LDM2", new AttributeData("LrnDelFAM_LDM2", 200) },
                { "LrnDelFAM_LDM3", new AttributeData("LrnDelFAM_LDM3", null) },
                { "LrnDelFAM_LDM4", new AttributeData("LrnDelFAM_LDM4", null) },
                { "LrnDelFAM_FFI", new AttributeData("LrnDelFAM_FFI", 3) },
                { "LrnDelFAM_RES", new AttributeData("LrnDelFAM_RES", 1) },
                { "OrigLearnStartDate", new AttributeData("OrigLearnStartDate", new DateTime(2018, 08, 01)) },
                { "OtherFundAdj", new AttributeData("OtherFundAdj", null) },
                { "Outcome", new AttributeData("Outcome", 1) },
                { "PriorLearnFundAdj", new AttributeData("PriorLearnFundAdj", null) },
                { "ProgType", new AttributeData("ProgType", 2) },
                { "PwayCode", new AttributeData("PwayCode", 3) },
            };
        }

        #endregion
    }
}
