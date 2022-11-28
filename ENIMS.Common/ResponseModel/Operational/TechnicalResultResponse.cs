using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class CriteriaResultResponse : OperationStatusResponse
    {
        public CriteriaResultDto Response { get; set; }
        public CriteriaResultResponse()
        {
            Response = new CriteriaResultDto();
        }
    }
    public class TechnicalResultResponse :OperationStatusResponse
    {
        public TechnicalResultDto Response { get; set; }
        public TechnicalResultResponse()
        {
            Response = new TechnicalResultDto();
        }
    }    
    public class TechnicalResultDto
    {
        public TechnicalResultDto()
        {
            SupplierResults = new List<SuppliersTechnicalResultDto>();
            Approvals = new List<EvaluationResultApprovalDto>();
        }
        public TechnicalEvaluationDTO TechnicalEvaluation { get; set; } //null
        public List<SuppliersTechnicalResultDto> SupplierResults { get; set; }
        public List<EvaluationResultApprovalDto> Approvals { get; set; }
    }
    public class SuppliersTechnicalResultDto
    {
        public SuppliersTechnicalResultDto()
        {
            Results = new List<CriteriaResultDto>();      
            Attachments = new List<AttachementDto>();      
        }
        public long Id { get; set; }//key
        public int Rank { get; set; }
        public bool? ResultSent { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<AttachementDto> Attachments { get; set; }              
        public TechnicalResult Status { get; set; }
        public DateTime EvaluationDate { get; set; }
        public List<CriteriaResultDto> Results { get; set; }
        public List<TechnicalResultMessageResponse> TechnicalResultMessageResponse { get; set; }

    }

    public class EvaluationResultApprovalDto
    {
        public long Id { get; set; }
        public ApprovalStatus Status { get; set; }
        public  PersonDTO Person { get; set; }
    }
    public class CriteriaResultDto
    {
        public long Id { get; set; }//key 
        public string Value { get; set; } // value
        public string Remark { get; set; } // value
        public bool DoPass { get; set; }
        public CriterionDTO TechnicalCriterion { get; set; }
    }

    public class QualificationResponse
    {
        public TechnicalResult Result { get; set; }
        public string Remark { get; set; }
        public bool isSuccess { get; set; }
    }

    public class AttachementDto
    {
        public string AttachementDisplayName { get; set; }
        public string AttachementName { get; set; }
    }
}
