using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class AssignRequest
    {
        public long RequestId { get; set; }
        public long PersonId { get; set; }
        public string Remark { get; set; }
    }
    public class SelfAssignRequest
    {
        public long RequestId { get; set; }
        public string Remark { get; set; }
    }   
}
