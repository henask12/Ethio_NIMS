using ENIMS.Common.RequestModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class FinancialResultResponse : OperationStatusResponse
    {
        public FinancialResultDto Response { get; set; }
        public FinancialResultResponse()
        {
            Response = new FinancialResultDto();
        }
    }
    public class FinancialResultDto
    {
        public FinancialResultDto()
        {
            SupplierResult = new List<SupplierFinancialResultDto>();
        }
        public FinancialEvaluationDTO FinancialEvaluation { get; set; }
        public List<SupplierFinancialResultDto> SupplierResult { get; set; }
        public List<EvaluationResultApprovalDto> FinancialEvaluationResultApprovals { get; set; }
    }

    public class SupplierFinancialResultDto
    {

        public SupplierFinancialResultDto()
        {
            Groups = new List<FinancialCriteriaResultGroupDto>();
            Attachement = new List<AttachementDto>();
        }
        public long Id { get; set; } = 0;
        public int Rank { get; set; } = 0;
        public double ResultPercentage { get; set; } = 0;
        public double BidAmount { get; set; } = 0;
        public double MonetaryAmountOne { get; set; } = 0;//Calculation = ((Min DLTV - DLTVo)/365)*BAo*0.075
        public double MonetaryAmountTwo { get; set; } = 0; //Calculation = (DLTV *PTV*BA*0.075)/365)
        public double NetPrice { get; set; } = 0;
        public string PaymentTerm { get; set; }
        public double PaymentTermValue { get; set; }
        public string DeliveryLeadTime { get; set; }
        public double DeliveryLeadTimeValue { get; set; }
        public string DeliveryTermandPlace { get; set; }
        public string Warranty { get; set; }
        public string TermAndConditions { get; set; }
        public DateTime EvaluationDate { get; set; } = DateTime.MinValue;
        public string Remark { get; set; } = string.Empty;
        public SupplierDTO Supplier { get; set; }
        public FinancialResult Status { get; set; } = FinancialResult.NotEvaluated;
        public List<AttachementDto> Attachement { get; set; }
        public List<FinancialCriteriaResultGroupDto> Groups { get; set; }
        public List<SupplierFinancialEvaluationResultTermDto> Terms { get; set; }
    }
    public class FinancialCriteriaResultGroupDto
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public List<FinancialCriteriaResultDto> Results { get; set; }
    }

    public class FinancialCriteriaResultDto
    {
        public long Id { get; set; }
        public double OfferedUnitPrice { get; set; }
        public double OfferedTotalPrice { get; set; }
        public string OfferedCurrency { get; set; }
        public double UnitPriceBaseCurrency { get; set; } //Base currency USD
        public double TotalPriceBaseCurrency { get; set; } //Base currency USD
        public string Remark { get; set; }
        public virtual FinancialCriteriaDTO FinancialCriteria { get; set; }
    }
}
