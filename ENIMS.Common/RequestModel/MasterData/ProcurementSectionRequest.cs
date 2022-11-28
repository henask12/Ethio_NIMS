using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class ProcurementSectionRequest
    {
        public long Id { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public long RequirmentPeriodId { get; set; }
    }
}
