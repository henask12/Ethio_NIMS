using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class SupplierTenderInvitationResponse : OperationStatusResponse
    {
        public List<SupplierTenderInvitationDTO> Response { get; set; }
        public int TotalInvitedSupplier { get; set; }
        public int TotalInterstedSupplier { get; set; }
        public int TotalPendingSupplier { get; set; }
        public string Approval { get; set; } = string.Empty;
        public SupplierTenderInvitationResponse()
        {
            Response = new List<SupplierTenderInvitationDTO>();
        }
    }
    public class SupplierTenderInvitationDTO
    {
        public long Id { get; set; }
        public BidInterest BidInterest { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool ShortListed { get; set; }
        public string Remark { get; set; }
        public virtual TenderInvitationDTO TenderInvitation { get; set; }
        public virtual SupplierDTO Supplier { get; set; }
    }
}
