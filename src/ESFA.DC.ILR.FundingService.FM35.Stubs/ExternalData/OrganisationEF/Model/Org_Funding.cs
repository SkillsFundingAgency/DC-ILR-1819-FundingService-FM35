using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Model
{
    public class Org_Funding
    {
        public int UKPRN { get; set; }

        public string FundModelName { get; set; }

        public string FundingFactor { get; set; }

        public string FundingFactorType { get; set; }

        public string FundingFactorValue { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public string CODACode { get; set; }

        public string Comment { get; set; }

        public DateTime Created_On { get; set; }

        public string Created_By { get; set; }

        public DateTime Modified_On { get; set; }

        public string Modified_By { get; set; }
    }
}
