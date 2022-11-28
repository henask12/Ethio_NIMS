using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
   public class BidClosingRequest
    {
        public long ProjectId { get; set; }
        public List<long> Recipents { get; set; }
        public DateTime  BidClosingDate { get; set; }
        public DateTime  TechnicalProposalOpeningDate { get; set; }
        public long ProjectProcessType { get; set; }
        public string Remark { get; set; }
        public List<string> NotifyTo { get; set; }
        public bool IsBidPosted { get; set; }

    }
}
