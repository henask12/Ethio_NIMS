using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class FloatationResponse: OperationStatusResponse
    {
        public bool IsFloated { get; set; }
    }
    public class ProjectInitiationResponse:OperationStatusResponse
    {
        public ProjectDTO Response { get; set; }
        public ProjectInitiationResponse()
        {
            Response = new ProjectDTO();
        }
    } 
    public class ProjectInitiationsResponse : OperationStatusResponse
    {
        public List<ProjectDTO> Responses { get; set; }
        public ProjectInitiationsResponse()
        {
            Responses = new List<ProjectDTO>();
        }
    }
    public class ProjectDTO
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public bool IsBECMandatory { get; set; }
        public RequestType RequestType { get; set; }
        public ProjectProcessType ProjectProcessType { get; set; }
        public DateTime? BidClosingDate { get; set; }
        public ProjectTask ProjectStatus { get; set; }
        public long? SourcingId { get; set; }
        public DateTime? TechnicalOpeningDate { get; set; }
        public ApprovalStatus ProjectTeamApproval { get; set; }
        public ApprovalType ProjectTeamApprovalType { get; set; }
        public long? AssignedPerson { get; set; }
        public bool EvaluateFinancial { get; set; } = false;
        public bool IsBidPosted { get; set; } 
        public HotelAccommodationDTO HotelAccommodation { get; set; }
        public PurchaseRequisitionDTO PurchaseRequisition { get; set; }
        public RequestForDocDTO RequestForDocument { get; set; }
        public PersonDTO Person { get; set; }
        public List<ProjectTeamDTO> ProjectTeams { get; set; }
        public bool IsCancelled { get; set; } = false;
        public bool IsTwoStageBiding { get; set; } = false;
        public bool IsTwoStageBidingRoot { get; set; } = false;
        public long SecondStageId { get; set; }
        public bool IsTwoStageCompleted { get; set; }
        public List<ProjectUpdateRecordDTO> ProjectUpdateRecords { get; set; }
        public double ProjectStatusPercentage { get; set; }
    }
    public class ProjectUpdateRecordDTO
    {
        public long Id { get; set; }
        public ProjectProcessType ProjectProcessType { get; set; }
        public string Remark { get; set; }
        public string NotifiedUsers { get; set; }
        public string UpdatedBy { get; set; }
        public long ProjectId { get; set; }
        public DateTime BidClosingDate { get; set; }
        public DateTime TechnicalProposalOpeningDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
