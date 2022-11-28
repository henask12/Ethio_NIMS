using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class RequirmentPeriodResponse : OperationStatusResponse
    {
        public RequirmentPeriodDTO Response { get; set; }
        public RequirmentPeriodResponse()
        {
            Response = new RequirmentPeriodDTO();
        }
    }
    public class RequirmentPeriodsResponse : OperationStatusResponse
    {
        public List<RequirmentPeriodDTO> Response { get; set; }
        public RequirmentPeriodsResponse()
        {
            Response = new List<RequirmentPeriodDTO>();
        }
    }

    public class RequirmentPeriodDTO
    {
        public long Id { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public PurchaseGroupDTO PurchaseGroup { get; set; }
    }

}
