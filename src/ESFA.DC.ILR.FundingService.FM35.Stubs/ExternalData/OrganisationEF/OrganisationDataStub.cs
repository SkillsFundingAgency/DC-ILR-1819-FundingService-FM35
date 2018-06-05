using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Interface;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Model;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF
{
    public class OrganisationDataStub : IOrganisation
    {
        public IEnumerable<Org_Version> Org_Version => OrgVersionData();

        public IEnumerable<Org_Funding> Org_Funding => OrgFundingData();

        private IEnumerable<Org_Version> OrgVersionData()
        {
            return new List<Org_Version>
            {
                new Org_Version
                {
                    MajorNumber = 1,
                    MinorNumber = 0,
                    MaintenanceNumber = 0,
                    MainDataSchemaName = "Version_001",
                    RefDataSchemaName = null,
                    ActivationDate = new DateTime(2014, 07, 01),
                    ExpiryDate = null,
                    Description = "Inital Version of Org",
                    Comment = "Inital Version of Org",
                    Created_On = new DateTime(2015, 06, 01),
                    Created_By = "DataLoader",
                    Modified_On = new DateTime(2015, 06, 01),
                    Modified_By = "DataLoader",
                },
                new Org_Version
                {
                    MajorNumber = 2,
                    MinorNumber = 0,
                    MaintenanceNumber = 0,
                    MainDataSchemaName = "Version_002",
                    RefDataSchemaName = null,
                    ActivationDate = new DateTime(2015, 07, 01),
                    ExpiryDate = null,
                    Description = "Changes for 1516",
                    Comment = "Added Ext Status to Org Details and Change to Version table",
                    Created_On = new DateTime(2015, 06, 01),
                    Created_By = "DataLoader",
                    Modified_On = new DateTime(2015, 06, 01),
                    Modified_By = "DataLoader",
                },
                new Org_Version
                {
                    MajorNumber = 3,
                    MinorNumber = 0,
                    MaintenanceNumber = 0,
                    MainDataSchemaName = "Version_003",
                    RefDataSchemaName = null,
                    ActivationDate = new DateTime(2016, 01, 01),
                    ExpiryDate = null,
                    Description = "Added Column - HESAProvider to Org_Details",
                    Comment = "Added Column - HESAProvider to Org_Details",
                    Created_On = new DateTime(2015, 07, 12),
                    Created_By = "DataLoader",
                    Modified_On = new DateTime(2015, 07, 12),
                    Modified_By = "DataLoader",
                },
            };
        }

        private IEnumerable<Org_Funding> OrgFundingData()
        {
            return new List<Org_Funding>
            {
                new Org_Funding
                {
                    UKPRN = 10006341,
                    FundModelName = "Adult Skills (College)",
                    FundingFactor ="TRANSITION FACTOR",
                    FundingFactorType = "Adult Skills",
                    FundingFactorValue = "1.03920",
                    EffectiveFrom = new DateTime(2018, 08, 01),  
                    EffectiveTo = new DateTime(2019, 07, 31),
                    CODACode = "",
                    Comment = null,
                    Created_On = new DateTime(2018, 07, 01),
                    Created_By = "System",
                    Modified_On = new DateTime(2018, 07, 01),
                    Modified_By = "System",
                },
                new Org_Funding
                {
                    UKPRN = 10006341,
                    FundModelName = "16-19 Learner Responsive Funding",
                    FundingFactor ="TRANSITION FACTOR",
                    FundingFactorType = "EFA 16-19",
                    FundingFactorValue = "1.03920",
                    EffectiveFrom = new DateTime(2018, 08, 01),
                    EffectiveTo = new DateTime(2019, 07, 31),
                    CODACode = "",
                    Comment = null,
                    Created_On = new DateTime(2018, 07, 01),
                    Created_By = "System",
                    Modified_On = new DateTime(2018, 07, 01),
                    Modified_By = "System",
                },
                new Org_Funding
                {
                    UKPRN = 10033670,
                    FundModelName = "Adult Skills (College)",
                    FundingFactor ="TRANSITION FACTOR",
                    FundingFactorType = "Adult Skills",
                    FundingFactorValue = "1.03920",
                    EffectiveFrom = new DateTime(2018, 08, 01),
                    EffectiveTo = new DateTime(2019, 07, 31),
                    CODACode = "",
                    Comment = null,
                    Created_On = new DateTime(2018, 07, 01),
                    Created_By = "System",
                    Modified_On = new DateTime(2018, 07, 01),
                    Modified_By = "System",
                },
                new Org_Funding
                {
                    UKPRN = 10033670,
                    FundModelName = "16-19 Learner Responsive Funding",
                    FundingFactor ="TRANSITION FACTOR",
                    FundingFactorType = "EFA 16-19",
                    FundingFactorValue = "1.03920",
                    EffectiveFrom = new DateTime(2018, 08, 01),
                    EffectiveTo = new DateTime(2019, 07, 31),
                    CODACode = "",
                    Comment = null,
                    Created_On = new DateTime(2018, 07, 01),
                    Created_By = "System",
                    Modified_On = new DateTime(2018, 07, 01),
                    Modified_By = "System",
                },
            };
        }
    }
}
