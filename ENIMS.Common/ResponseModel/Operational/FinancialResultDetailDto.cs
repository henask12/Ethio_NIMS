using ENIMS.Common.RequestModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class FinancialResultDetailResponse :OperationStatusResponse
    {
        public FinancialResultDetailResponseDto Response { get; set; }
        public FinancialResultDetailResponse()
        {
            Response = new FinancialResultDetailResponseDto();
        }
    }
    public class FinancialResultDetailResponseDto
    {
        public FinancialResultDetailResponseDto()
        {
            Groups = new List<FinancialCriteriaResultGroupDto>();
        }
        public long Id { get; set; }
        public int Rank { get; set; }
        public double ResultPercentage { get; set; }
        public double BidAmount { get; set; }
        public double MonetaryAmountOne { get; set; } //Calculation = ((Min DLTV - DLTVo)/365)*BAo*0.075
        public double MonetaryAmountTwo { get; set; } //Calculation = (DLTV *PTV*BA*0.075)/365)
        public double NetPrice { get; set; }
        public string PaymentTerm { get; set; }
        public double PaymentTermValue { get; set; }
        public string DeliveryLeadTime { get; set; }
        public double DeliveryLeadTimeValue { get; set; }
        public string DeliveryTermandPlace { get; set; }
        public string Warranty { get; set; }
        public string TermAndConditions { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string Remark { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<FinancialHeadersDto> Headers { get; set; }
        public List<FinancialCriteriaResultGroupDto> Groups { get; set; }
        public List<SupplierFinancialEvaluationResultTermDto> Terms { get; set; }
    }
}
