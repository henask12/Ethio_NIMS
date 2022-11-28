using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class OfficeResponse:OperationStatusResponse
    {
        public OfficeDTO Response { get; set; }
        public OfficeResponse()
        {
            Response = new OfficeDTO();
        }
    }
    public class OfficesResponse: OperationStatusResponse
    {
        public List<OfficeDTO> Response { get; set; }
        public OfficesResponse()
        {
            Response =new List<OfficeDTO>();
        }
    }
    public class OfficeDTO
    {
        public long Id { get; set; }
        public string OfficeName { get; set; }

        public string Description { get; set; }
        public CostCenterDTO CostCenter { get; set; }
    }
}
