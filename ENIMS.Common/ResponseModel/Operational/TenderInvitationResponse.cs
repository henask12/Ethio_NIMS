using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class TenderInvitationResponse :OperationStatusResponse
    {
        public TenderInvitationDTO Response { get; set; }
        public TenderInvitationResponse()
        {
            Response = new TenderInvitationDTO();
        }
    }

    public class TenderInvitationDTO
    {
        public long Id { get; set; }
        public bool IsPosted { get; set; }
        public string Description { get; set; }
        public List<SupplierDTO> Suppliers { get; set; }
        public DateTime ResponseDueDate { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
