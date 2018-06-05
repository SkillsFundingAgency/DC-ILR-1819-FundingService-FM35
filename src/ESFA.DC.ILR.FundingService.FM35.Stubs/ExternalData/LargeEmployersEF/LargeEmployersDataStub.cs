using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.LargeEmployersEF.Interface;
using ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.LargeEmployersEF.Model;

namespace ESFA.DC.ILR.FundingService.FM35.Stubs.ExternalData.LargeEmployersEF
{
    public class LargeEmployersDataStub : ILargeEmployers
    {
        public IEnumerable<Large_Employers> Large_Employers => LargeEmployersData();

        private IEnumerable<Large_Employers> LargeEmployersData()
        {
            return new List<Large_Employers>
            {
                new Large_Employers
                {
                    ERN = 107733730,
                    EffectiveFrom = new DateTime(2017, 08, 01),
                    EffectiveTo = null
                },
                new Large_Employers
                {
                    ERN = 108833730,
                    EffectiveFrom = new DateTime(2018, 08, 01),
                    EffectiveTo = null
                },
                new Large_Employers
                {
                    ERN = 109933730,
                    EffectiveFrom = new DateTime(2017, 08, 01),
                    EffectiveTo = null
                },
                new Large_Employers
                {
                    ERN = 100033730,
                    EffectiveFrom = new DateTime(2018, 08, 01),
                    EffectiveTo = null
                },
            };
        }
    }
}
