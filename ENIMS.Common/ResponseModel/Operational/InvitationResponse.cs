using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class InvitationResponse :OperationStatusResponse
    {
        public InvitationDTO Response { get; set; }
        public InvitationResponse()
        {
            Response = new InvitationDTO();
        }
    }
    public class InvitationDTO
    {
        public long Id { get; set; }
        public bool IsPosted { get; set; }
        public string Description { get; set; }
        public List<SupplierDTO> Suppliers { get; set; }
        public List<SupplierDTO> SelectedSuppliers { get; set; }
        public DateTime ResponseDueDate { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
