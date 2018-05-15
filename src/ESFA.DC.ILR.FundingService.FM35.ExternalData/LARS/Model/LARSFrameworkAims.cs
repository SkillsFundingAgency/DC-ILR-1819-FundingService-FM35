﻿using System;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model
{
    public class LARSFrameworkAims
    {
        public int FworkCode { get; set; }

        public int ProgType { get; set; }

        public int PwayCode { get; set; }

        public string LearnAimRef { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public int FrameworkComponentType { get; set; }
    }
}
