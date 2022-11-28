using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{   
    public class SupplierTechnicalEvaluationRequest
    {
        public SupplierTechnicalEvaluationRequest(List<CriateriaRequest> criateriaRequest)
        {
            CriateriaRequest = criateriaRequest;
        }

        public long SupplierId { get; set; }
        public long ProjectId { get; set; }
        public List<CriateriaRequest> CriateriaRequest { get; set; }
    }
    public class CriateriaRequest
    {
        public long CriteriaId { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
    }
    public class CritreaResultUpdateRequest
    {
        public  long ProjectId { get; set; }
        public long CriteriaId { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
    }

    public class SupplierResultDetailRequest
    {
        public long ProjectId { get; set; }
        public long SupplierResultId { get; set; }
    } public class TechnicalResultMessageRequest
    {
        public long ProjectId { get; set; }
        public long SupplierId { get; set; }
    }
    public class NotifySupplierResultRequest
    {
        public long SupplierId { get; set; }
        public long ProjectId { get; set; }
        public string Body { get; set; }
    }
}
