using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class VendorTypeResponse:OperationStatusResponse
    {
        public VendorTypeDTO Response { get; set; }
        public VendorTypeResponse()
        {
            Response = new VendorTypeDTO();
        }
    }  
    public class VendorTypesResponse: OperationStatusResponse
    {
        public List<VendorTypeDTO> Response { get; set; }
        public VendorTypesResponse()
        {
            Response = new List<VendorTypeDTO>();
        }
    }  
    public class VendorTypeDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
