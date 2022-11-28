using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class TechnicalEvaluationUpdateRequest
    {
        public long Id { get; set; }
        public string EvaluationName { get; set; }
        public double CutOffPoint { get; set; }
        public double TechnicalEvaluationValue { get; set; }
        public long ProjectId { get; set; }
    }
    public class TechnicalEvaluationRequest
    {
        public long Id { get; set; }
        public string EvaluationName { get; set; }
        public List<CriteriaGroupRequest> CriteriaGroup { get; set; }
        public double CutOffPoint { get; set; }
        public double TechnicalEvaluationValue { get; set; }
        public long ProjectId { get; set; }
    }
    public class CriteriaGroupUpdateRequest
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public double Sum { get; set; }
        public long TechnicalEvaluationId { get; set; }
    }
    public class CriteriaGroupRequest
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public double Sum { get; set; }
        public double TechnicalEvaluationId { get; set; }
        public List<CriterionRequest> Criteria { get; set; }
    }
    public class CriterionRequest
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public MeasurmentTypes Measurment { get; set; }
        public string Value { get; set; }
        public Necessity Necessity { get; set; }
        public long TechnicalCriteriaGroupId { get; set; }
    }
}
