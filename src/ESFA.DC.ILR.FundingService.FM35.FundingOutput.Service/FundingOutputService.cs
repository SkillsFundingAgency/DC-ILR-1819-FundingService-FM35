using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Attribute;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Model.Interface;
using ESFA.DC.ILR.FundingService.FM35.FundingOutput.Service.Interface;
using ESFA.DC.OPA.Model.Interface;

namespace ESFA.DC.ILR.FundingService.FM35.FundingOutput.Service
{
    public class FundingOutputService : IFundingOutputService
    {
        public FundingOutputService()
        {
        }

        public IFM35FundingOutputs ProcessFundingOutputs(IEnumerable<IDataEntity> dataEntities)
        {
            return new FM35FundingOutputs
            {
                Global = new GlobalAttribute(), // GlobalOutput(dataEntities.Select(g => g.Attributes).First()),
                Learners = null, // LearnerOutput(dataEntities.SelectMany(g => g.Children)),
            };
        }
    }
}
