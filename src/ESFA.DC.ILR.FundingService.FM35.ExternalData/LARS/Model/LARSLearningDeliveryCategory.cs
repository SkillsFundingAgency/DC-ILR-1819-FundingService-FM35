using System;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model
{
    public class LARSLearningDeliveryCategory
    {
        public string LearnAimRef { get; set; }

        public int CategoryRef { get; set; }

        public DateTime EffectiveFromFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }
    }
}
