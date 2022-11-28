using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational.Negotiation
{
    public class NegotiationResultDetailResponse : OperationStatusResponse
    {
        public NegotiationResultDetailResponseDto Response { get; set; }
        public NegotiationResultDetailResponse()
        {
            Response = new NegotiationResultDetailResponseDto();
        }
    }
    public class NegotiationResultDetailResponseDto
    {
        public NegotiationResultDetailResponseDto()
        {
            Groups = new List<NegotiationCriteriaResultGroupDto>();
        }
      
        public SupplierDTO Supplier { get; set; }
        public List<NegotiationCriteriaResultGroupDto> Groups { get; set; }
        public TermCondition FinancialTerm { get; set; }
        public TermCondition NegotiatinTerm { get; set; }
    }

    public class NegotiationCriteriaResultGroupDto
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public List<DetialResultResponse> Results { get; set; }
        public NegotiationCriteriaResultGroupDto()
        {
            Results = new List<DetialResultResponse>();
        }
    }
    public class DetialResultResponse
    {
        public NegotiationResultDto FinancialResult { get; set; }
        public NegotiationResultDto NegotiationResult { get; set; }
        public ResultDifference Difference { get; set; }
    }
    public class NegotiationResultDto
    {
        public long Id { get; set; }
        public double OfferedUnitPrice { get; set; }
        public double OfferedTotalPrice { get; set; }
        public string OfferedCurrency { get; set; }
        public double UnitPriceBaseCurrency { get; set; } //Base currency USD
        public double TotalPriceBaseCurrency { get; set; } //Base currency USD
        public string Remark { get; set; }
        public  FinancialCriteriaDTO FinancialCriteria { get; set; }
    }
    public class ResultDifference
    {
        public double OfferedUnitPrice { get; set; }
        public double OfferedTotalPrice { get; set; }
        public double UnitPriceBaseCurrency { get; set; } //Base currency USD
        public double TotalPriceBaseCurrency { get; set; } //Base currency USD
    }
    public class TermCondition
    {
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
    }
}

