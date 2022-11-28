using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class CombinedSumResponse : OperationStatusResponse
    {
        public CombinedSumResponse()
        {
            Response = new List<CombinedSumDto>();
        }
        public List<CombinedSumDto> Response { get; set; }
    }

    public class CombinedSumDto
    {
        public SupplierDTO Supplier { get; set; }
        public TechnicalResult TechnicalQualificaton { get; set; }
        public double TechnicalResult { get; set; }
        public double FinancialResult { get; set; }
        public double Total { get; set; }
        public int Rank { get; set; }
        public bool IsResultSent { get; set; } = false;
    }
}
