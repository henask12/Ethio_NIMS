using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common.RequestModel.Report
{
    public class ExcutiveSummaryApprovalRequest
    {
        public ExcutiveSummaryApprovalRequest()
        {
            ExcutiveApprovers = new List<ExcutiveApprover>();
            CarbonCopies = new List<CarbonCopy>();
        }
        public long Id { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public List<ExcutiveApprover> ExcutiveApprovers { get; set; }
        public List<CarbonCopy> CarbonCopies { get; set; }
    }

    public class ExcutiveApprover
    {
        public long PersonId { get; set; }
        public int OrderId { get; set; }
    }
    public class CarbonCopy
    {
        public long Personid { get; set; }
    }
}
