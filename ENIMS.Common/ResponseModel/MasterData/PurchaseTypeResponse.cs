using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class PurchaseTypeResponse : OperationStatusResponse
    {
        public PurchaseTypeDTO Response { get; set; }
        public PurchaseTypeResponse()
        {
            Response = new PurchaseTypeDTO();
        }
    }
    public class PurchaseTypesResponse : OperationStatusResponse
    {
        public List<PurchaseTypeDTO> Response { get; set; }
        public PurchaseTypesResponse()
        {
            Response = new List<PurchaseTypeDTO>();
        }
    }

    public class PurchaseTypeDTO
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

}
