using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{

    public class SupplierFinancialEvaluationUpdateRequest
    {
        public long Id { get; set; }
        public string PaymentTerm { get; set; }
        public double PaymentTermValue { get; set; }
        public string DeliveryLeadTime { get; set; }
        public double DeliveryLeadTimeValue { get; set; }
        public string DeliveryTermandPlace { get; set; }
        public string TermAndConditions { get; set; }
        public string Warranty { get; set; }
        public List<SupplierFinancialEvaluationResultTermDto> Terms { get; set; }
        public List<FinancialCriateriaRequest> CriateriaRequest { get; set; }
        public SupplierFinancialEvaluationUpdateRequest()
        {
            CriateriaRequest = new List<FinancialCriateriaRequest>();
        }
    }
    public class ApprovalRequest
    {
        public long ProjectId { get; set; }
    }
    public class SupplierFinancialEvaluationRequest
    {
        public long SupplierId { get; set; }
        public long ProjectId { get; set; }
        public string PaymentTerm { get; set; }
        public double PaymentTermValue { get; set; }
        public string DeliveryLeadTime { get; set; }
        public double DeliveryLeadTimeValue { get; set; }
        public string DeliveryTermandPlace { get; set; }
        public string TermAndConditions { get; set; }
        public string Warranty { get; set; }
        public List<FinancialCriateriaRequest> FinancialCriateriaRequest { get; set; }
        public List<SupplierFinancialEvaluationResultTermDto> Terms { get; set; }
    }
    public class FinancialCriateriaRequest
    {
        public long FinancialCriteriaId { get; set; }
        public double OfferedUnitPrice { get; set; }
        public double OfferedTotalPrice { get; set; }
        public string OfferedCurrency { get; set; }
        public double UnitPriceBaseCurrency { get; set; } 
        public double TotalPriceBaseCurrency { get; set; }
        public string Remark { get; set; }

    }
    public class SupplierFinancialEvaluationResultTermDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
