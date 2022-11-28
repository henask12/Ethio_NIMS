using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class PurchaseGroupResponse : OperationStatusResponse
    {
        public PurchaseGroupDTO Response { get; set; }
        public PurchaseGroupResponse()
        {
            Response = new PurchaseGroupDTO();
        }
    }
    public class PurchaseGroupsResponse : OperationStatusResponse
    {
        public List<PurchaseGroupDTO> Response { get; set; }
        public PurchaseGroupsResponse()
        {
            Response = new List<PurchaseGroupDTO>();
        }
    }

    public class PurchaseGroupDTO
    {
        public long Id { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }

}
