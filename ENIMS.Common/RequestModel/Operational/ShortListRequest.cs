using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class ShortListRequest
    {
        public long TenderInvitationId { get; set; }
        public List<long> SupplierInvitationIds { get; set; }
        public List<long> Approvers { get; set; }
        public List<long> CarbonCopies { get; set; }
        public List<long> Offices { get; set; }
        public string  Subject { get; set; }
        public string  Body { get; set; }
        public ApprovalType ApprovalType { get; set; }
    }

}
