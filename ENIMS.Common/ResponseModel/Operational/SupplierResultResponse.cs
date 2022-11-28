using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class SupplierResultResponse :OperationStatusResponse
    {
        public SupplierResultDto Response { get; set; }
    }

    public class SupplierResultDto
    {
        public long Id { get; set; }
        public ResultType Result { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; } = false;
        public string Subject { get; set; }
    }
}
