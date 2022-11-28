using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class RequirmentPeriodRequest
    {
        public long Id { get; set; }
        public string Period { get; set; }
        public string Description { get; set; }
        public long PurchaseGroupId { get; set; }
    }
}
