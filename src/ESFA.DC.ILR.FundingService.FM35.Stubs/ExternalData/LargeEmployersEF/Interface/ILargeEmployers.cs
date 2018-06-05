using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.LargeEmployersEF.Model;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.LargeEmployersEF.Interface
{
    public interface ILargeEmployers
    {
        IEnumerable<Large_Employers> Large_Employers { get; }
    }
}
