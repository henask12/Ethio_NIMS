using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class FinancialEvaluationResponse : OperationStatusResponse
    {
        public FinancialEvaluationDTO Response { get; set; }
        public FinancialEvaluationResponse()
        {
            Response = new FinancialEvaluationDTO();
        }
    }
    public class FinancialEvaluationsResponse : OperationStatusResponse
    {
        public List<FinancialEvaluationDTO> Response { get; set; }
        public FinancialEvaluationsResponse()
        {
            Response = new List<FinancialEvaluationDTO>();
        }
    }
    public class FinancialCriteriaGroupResponse : OperationStatusResponse
    {
        public FinancialCriteriaGroupDTO Response { get; set; }
        public FinancialCriteriaGroupResponse()
        {
            Response = new FinancialCriteriaGroupDTO();
        }
    }

    public class FinancialCriteriaGroupsResponse : OperationStatusResponse
    {
        public List<FinancialCriteriaGroupDTO> Response { get; set; }
        public FinancialCriteriaGroupsResponse()
        {
            Response = new List<FinancialCriteriaGroupDTO>();
        }
    }
    public class FinancialCriteriaResponse : OperationStatusResponse
    {
        public FinancialCriteriaDTO Response { get; set; }
        public FinancialCriteriaResponse()
        {
            Response = new FinancialCriteriaDTO();
        }
    }
    public class FinancialCriteriasResponse : OperationStatusResponse
    {
        public List<FinancialCriteriaDTO> Response { get; set; }
        public FinancialCriteriasResponse()
        {
            Response = new List<FinancialCriteriaDTO>();
        }
    }
    public class FinancialCriteriaItemResponse : OperationStatusResponse
    {
        public FinancialCriteriaItemDTO Response { get; set; }
        public FinancialCriteriaItemResponse()
        {
            Response = new FinancialCriteriaItemDTO();
        }
    }
    public class FinancialCriteriaItemsResponse : OperationStatusResponse
    {
        public List<FinancialCriteriaItemDTO> Response { get; set; }
        public FinancialCriteriaItemsResponse()
        {
            Response = new List<FinancialCriteriaItemDTO>();
        }
    }
    public class FinancialEvaluationDTO
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string EvaluationName { get; set; }
        public double FinancialEvaluationValue { get; set; }
        public AwardFactor AwardFactor { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public List<EvaluationApprovalDto> FinancialEvaluationApprovals { get; set; }
        public List<FinancialCriteriaGroupDTO> FinancialCriteriaGroups { get; set; }
        public List<FinancialHeadersDto> FinancialHeaders { get; set; }
        public FinancialEvaluationDTO()
        {
            FinancialEvaluationApprovals = new List<EvaluationApprovalDto>();
        }
    }
    public class FinancialHeadersDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class FinancialCriteriaGroupDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public long FinancialEvaluationId { get; set; }
        public List<FinancialCriteriaDTO> FinancialCriterias { get; set; }
    }
    public class FinancialCriteriaDTO
    {
        public FinancialCriteriaDTO()
        {
            FinancialHeaderValue = new List<FinancialHeaderValueDto>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public long FinancialCriteriaGroupId { get; set; }
        public List<FinancialHeaderValueDto> FinancialHeaderValue { get; set; }

    }
    public class FinancialHeaderValueDto
    {
        public long Id { get; set; }
        //public string FiledName { get; set; }
        //public string DataType { get; set; }
        public string Value { get; set; }
        public long FinancialCriteriaId { get; set; }
        public FinancialHeadersDto FinancialHeaders { get; set; }
    }
    public class FinancialCriteriaItemDTO
    {
        public long Id { get; set; }
        public string FiledName { get; set; }
        public string DataType { get; set; }
        public string Value { get; set; }
        public long FinancialCriteriaId { get; set; }
    }
}
