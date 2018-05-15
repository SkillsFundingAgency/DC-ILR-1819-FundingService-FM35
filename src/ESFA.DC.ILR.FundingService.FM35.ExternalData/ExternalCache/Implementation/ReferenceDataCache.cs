using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Implementation
{
    public class ReferenceDataCache : IReferenceDataCache
    {
        public IDictionary<string, IEnumerable<LARSFunding>> LARSFunding { get; set; } = new Dictionary<string, IEnumerable<LARSFunding>>();

        public IDictionary<string, LARSLearningDelivery> LARSLearningDelivery { get; set; } = new Dictionary<string, LARSLearningDelivery>();

        public IDictionary<string, IEnumerable<LARSAnnualValue>> LARSAnnualValue { get; set; } = new Dictionary<string, IEnumerable<LARSAnnualValue>>();

        public IDictionary<string, IEnumerable<LARSFrameworkAims>> LARSFrameworkAims { get; set; } = new Dictionary<string, IEnumerable<LARSFrameworkAims>>();

        public IDictionary<string, IEnumerable<LARSLearningDeliveryCategory>> LARSLearningDeliveryCatgeory { get; set; } = new Dictionary<string, IEnumerable<LARSLearningDeliveryCategory>>();

        public string LARSCurrentVersion { get; set; }

        // public IDictionary<string, IEnumerable<SfaAreaCost>> SfaAreaCost { get; set; } = new Dictionary<string, IEnumerable<SfaAreaCost>>();

        // public string PostcodeCurrentVersion { get; set; }

        // ORG

        // LEMP
    }
}
