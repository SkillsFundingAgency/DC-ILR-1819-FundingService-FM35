using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Interface
{
    public interface IReferenceDataCache
    {
        IDictionary<string, IEnumerable<LARSFunding>> LARSFunding { get; }

        IDictionary<string, LARSLearningDelivery> LARSLearningDelivery { get; }

        IDictionary<string, IEnumerable<LARSAnnualValue>> LARSAnnualValue { get; }

        IDictionary<string, IEnumerable<LARSFrameworkAims>> LARSFrameworkAims { get; }

        IDictionary<string, IEnumerable<LARSLearningDeliveryCategory>> LARSLearningDeliveryCatgeory { get; }

        string LARSCurrentVersion { get; }

        //IDictionary<string, IEnumerable<SfaAreaCost>> SfaAreaCost { get; }

        //string PostcodeCurrentVersion { get; }

        //ORG

        //LEMP
    }
}
