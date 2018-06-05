using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Model
{
    public class Org_Version
    {
        public int MajorNumber { get; set; }

        public int MinorNumber { get; set; }

        public int MaintenanceNumber { get; set; }

        public string MainDataSchemaName { get; set; }

        public string RefDataSchemaName { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public DateTime Created_On { get; set; }

        public string Created_By { get; set; }

        public DateTime Modified_On { get; set; }

        public string Modified_By { get; set; }
    }
}
