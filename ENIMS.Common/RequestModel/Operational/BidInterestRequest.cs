using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class BidInterestRequest
    {
        public long InvitationId { get; set; }
        public BidInterest BidInterest { get; set; }
        public string Remark { get; set; }
    }
}
