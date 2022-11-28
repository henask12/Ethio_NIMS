using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class RejectRequest
    {
        public long RequestId { get; set; }
        public string Remark { get; set; }
    }
}
