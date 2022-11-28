using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class FinancialEvaluationRequest
    {
        public FinancialEvaluationRequest()
        {
            FinancialCriteriaGroups = new List<FinancialCriteriaGroupRequest>();
        }
        public long Id { get; set; }
        public string EvaluationName { get; set; }
        public double FinancialEvaluationValue { get; set; }
        public long ProjectId { get; set; }
        public AwardFactor AwardFactor { get; set; }
        public List<string> FinancialHeaders    { get; set; }
        public List<FinancialCriteriaGroupRequest> FinancialCriteriaGroups { get; set; }
    }
    public class FinancialEvaluationUpdateRequest
    {
        public long Id { get; set; }
        public string EvaluationName { get; set; }
        public double FinancialEvaluationValue { get; set; }
        public long ProjectId { get; set; }
        public List<FinancialHeaderRequest> FinancialHeaders { get; set; }

        public AwardFactor AwardFactor { get; set; }
    }

    public class FinancialHeaderRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class FinancialCriteriaGroupRequest
    {
        public FinancialCriteriaGroupRequest()
        {
            FinancialCriterias = new List<FinancialCriteriaRequest>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public long FinancialEvaluationId { get; set; }
        public List<FinancialCriteriaRequest> FinancialCriterias { get; set; }
    } 
    public class FinancialCriteriaGroupUpdateRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public long FinancialEvaluationId { get; set; }
    }
    public class FinancialCriteriaRequest
    {
        public FinancialCriteriaRequest()
        {
            FinancialHeaderValues = new List<FinancialHeaderValueRequest>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public long FinancialCriteriaGroupId { get; set; }
        public List<FinancialHeaderValueRequest> FinancialHeaderValues { get; set; }
    }
    public class FinancialCriteriaUpdateRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public long FinancialCriteriaGroupId { get; set; }
        public List<FinancialHeaderValueRequest> FinancialHeaderValues { get; set; }
    }
    public class FinancialHeaderValueRequest
    {
        public string Value { get; set; }
        public long FinancialHeadersId { get; set; }
    }
}
