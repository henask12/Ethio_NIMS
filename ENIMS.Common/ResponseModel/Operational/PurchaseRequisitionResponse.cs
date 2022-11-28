using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class PurchaseRequisitionResponse:OperationStatusResponse
    {
        public PurchaseRequisitionDTO Response { get; set; }
        public PurchaseRequisitionResponse()
        {
            Response = new PurchaseRequisitionDTO();
        }
    }
    public class PurchaseRequisitionsResponse: OperationStatusResponse
    {
        public List<PurchaseRequisitionDTO> Response { get; set; }
        public PurchaseRequisitionsResponse()
        {
            Response = new List<PurchaseRequisitionDTO>();
        }
    }
    public class PurchaseRequisitionDTO
    {
        public long Id { get; set; }
        public string RequestedGood { get; set; }
        public string ApprovedBudgetAmmount { get; set; }
        public ENIMS.Common.PurchaseType PurchaseType { get; set; }
        public PurchaseGroupDTO PurchaseGroup { get; set; }//
        public RequirmentPeriodDTO RequirementPeriod { get; set; }//
        public ProcurementSectionDTO ProcurementSection { get; set; }//
        public string Division { get; set; }
        public CostCenterDTO CostCenter { get; set; }//
        public List<PRDelegateTeamDTO> DelegateTeam { get; set; }
        public List<PRApproversDTO> Approvers { get; set; }
        public string Specification { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public PRStatus PRStatus { get; set; }
        public bool isInitiated { get; set; }
        public PersonDTO Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public string RejectionRemark { get; set; }
        public string RejectionDateTime { get; set; }
        public PersonDTO Rejector { get; set; }
        public PersonDTO AssignedAgent { get; set; }
        public PersonDTO Assigner { get; set; }
        public List<PrAttachement> Attachments { get; set; }
        public PurchaseRequisitionDTO()
        {
            Attachments = new List<PrAttachement>();
        }
    }
    public class PRDelegateTeamDTO
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }//
    }
    public class PRApproversDTO
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }//
        public int Order { get; set; }//
        public ApprovalStatus ApprovalStatus { get; set; }//
        public string ApprovalDateTime { get; set; }

    }
    public class PrAttachement
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
    }
}
