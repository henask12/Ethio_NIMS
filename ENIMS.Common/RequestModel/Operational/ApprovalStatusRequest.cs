using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class ApprovalStatusRequest
    {
        public string status { get; set; }
        public string actionTakenDate { get; set; }
        public string actionTakenBy { get; set; }
        public string fileName { get; set; }
    }
}
