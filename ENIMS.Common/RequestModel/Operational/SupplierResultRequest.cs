using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class SupplierResultRequest
    {
        public long ProjectId { get; set; }
        public long SupplierId { get; set; }
        public ResultType Result { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
    public class SupplierResultUpdateRequest
    {
        public long Id { get; set; }
        public ResultType Result { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
    public class ResultNotificationDetailRequest
    {
        public long ProjectId { get; set; }
        public long SupplierId { get; set; }

    }
}
