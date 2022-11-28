using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
   public  class TenderInvitationRequest
    {
        public string Description { get; set; }
        public ICollection<long> Suppliers { get; set; }
        public DateTime ResponseDueDate { get; set; }
        public long ProjectId { get; set; }
    }
}
