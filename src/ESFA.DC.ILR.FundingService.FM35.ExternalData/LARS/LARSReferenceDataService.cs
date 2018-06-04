using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.ExternalCache.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.LARS
{
    public class LARSReferenceDataService : ILARSReferenceDataService
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public LARSReferenceDataService(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public string LARSCurrentVersion()
        {
            return _referenceDataCache.LARSCurrentVersion;
        }

        public IEnumerable<LARSAnnualValue> LARSAnnualValuesForLearnAimRef(string learnAimRef)
        {
            try
            {
                return _referenceDataCache.LARSAnnualValue[learnAimRef];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find LARS AnnualValue data for LearnAimRef: " + learnAimRef + " in the Dictionary. Exception details: " + ex));
            }
        }

        public IEnumerable<LARSFrameworkAims> LARSFFrameworkAimsForLearnAimRef(string learnAimRef)
        {
            try
            {
                return _referenceDataCache.LARSFrameworkAims[learnAimRef];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find LARS Framework Aims data for LearnAimRef: " + learnAimRef + " in the Dictionary. Exception details: " + ex));
            }
        }

        public IEnumerable<LARSFunding> LARSFundingsForLearnAimRef(string learnAimRef)
        {
            try
            {
                return _referenceDataCache.LARSFunding[learnAimRef];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find LARS Funding data for LearnAimRef: " + learnAimRef + " in the Dictionary. Exception details: " + ex));
            }
        }

        public LARSLearningDelivery LARSLearningDeliveriesForLearnAimRef(string learnAimRef)
        {
            try
            {
                return _referenceDataCache.LARSLearningDelivery[learnAimRef];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find LARS Learning Delivery data for LearnAimRef: " + learnAimRef + " in the Dictionary. Exception details: " + ex));
            }
        }

        public IEnumerable<LARSLearningDeliveryCategory> LARSLearningDeliveryCategoriesForLearnAimRef(string learnAimRef)
        {
            try
            {
                return _referenceDataCache.LARSLearningDeliveryCatgeory[learnAimRef];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find LARS Learning Delivery Category data for LearnAimRef: " + learnAimRef + " in the Dictionary. Exception details: " + ex));
            }
        }
    }
}
