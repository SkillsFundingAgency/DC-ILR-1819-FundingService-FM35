using System;
using System.Collections.Generic;
using System.Text;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Model;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.OrganisationEF.Interface
{
    public interface IOrganisation
    {
        IEnumerable<Org_Version> Org_Version { get; }

        IEnumerable<Org_Funding> Org_Funding { get; }
    }
}
