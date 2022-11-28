using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class BidClosingUpdatRequest
    {
        public long ProjectId { get; set; }
        public List<long>  Recipents { get; set; }
        public DateTime BidClosingDate { get; set; }
        public DateTime TechnicalProposalOpeningDate { get; set; }
    }
}
