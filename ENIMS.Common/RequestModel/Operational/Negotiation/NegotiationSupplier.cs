using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class NegotiationSupplierRequest
    {
        public long ProjectId { get; set; }
        public List<long> SupplierIds { get; set; }
    }
}
