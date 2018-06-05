using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes.Interface;
using ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes.Model;

namespace ESFA.DC.ILR.FundingService.FM35.ExternalData.Postcodes
{
    public class PostcodesReferenceDataService : IPostcodesReferenceDataService
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public PostcodesReferenceDataService(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public string PostcodesCurrentVersion()
        {
            return _referenceDataCache.PostcodeCurrentVersion;
        }

        public IEnumerable<SfaAreaCost> SFAAreaCostsForPostcode(string postcode)
        {
            try
            {
                return _referenceDataCache.SfaAreaCost[postcode];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find Postcode: " + postcode + " in the SFA Area Cost Dictionary. Exception details: " + ex));
            }
        }

        public IEnumerable<SfaDisadvantage> SFADisadvantagesForPostcode(string postcode)
        {
            try
            {
                return _referenceDataCache.SfaDisadvantage[postcode];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find Postcode: " + postcode + " in the SFA Postcode Disadvantage Dictionary. Exception details: " + ex));
            }
        }
    }
}