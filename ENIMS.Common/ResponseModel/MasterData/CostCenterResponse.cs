using System;
using System.Collections.Generic;
using System.Text;

namespace 
    ENIMS.Common.ResponseModel.MasterData
{
    public class CostCenterResponse : OperationStatusResponse
    {
        public CostCenterDTO Response { get; set; }
        public CostCenterResponse()
        {
            Response = new CostCenterDTO();
        }
    }  
    public class CostCentersResponse : OperationStatusResponse
    {
        public List<CostCenterDTO> Response { get; set; }
        public CostCentersResponse()
        {
            Response = new List<CostCenterDTO>();
        }
    }  
    public class CostCenterDTO
    {
        public long Id { get; set; }
        public CountryDTO Country { get; set; }
        public string Station { get; set; }
        public string CostCenterName { get; set; }
    }
}
