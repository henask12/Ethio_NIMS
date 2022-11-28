using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{

    public class ClarificationRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public long ProjectId { get; set; }
        public long? SupplierId { get; set; }
        public long? PersonId { get; set; }
        public MessageStatus MessageStatus { get; set; }

    }

}
