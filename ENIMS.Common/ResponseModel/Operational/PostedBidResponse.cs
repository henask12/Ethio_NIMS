using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class PostedBidsResponse :OperationStatusResponse
    {
        public List<PostedBid> Response { get; set; }
        public PostedBidsResponse()
        {
            Response = new List<PostedBid>();
        }
    }
    public class PostedBid
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime PublishedDate { get; set; }
        public BidStatus BidStatus { get; set; }
        public BidInterest BidInterest { get; set; }
    }
}
