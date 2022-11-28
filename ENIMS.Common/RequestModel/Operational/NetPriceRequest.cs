using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class NetPriceRequest
    {
        public long ProjectId { get; set; }
        public bool IncludeMonetaryFine { get; set; }

    }
}
