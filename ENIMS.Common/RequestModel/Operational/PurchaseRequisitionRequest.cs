using ENIMS.Common.RequestModel.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class PurchaseRequisitionRequest
    {
        public long Id { get; set; }
        public string RequestedGood { get; set; }
        public string ApprovedBudgetAmmount { get; set; }
        public ENIMS.Common.PurchaseType PurchaseType { get; set; }
        public long PurchaseGroupId { get; set; } //
        public long RequirementPeriodId { get; set; } //
        public long ProcurementSectionId { get; set; } //
        public string Division { get; set; }
        public long CostCenterId { get; set; } //     
        public string Specification { get; set; }
        public List<IFormFile> SpecificationFiles { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string contentType { get; set; }
        public string DelegateTeams { get; set; }//optional
        public PurchaseRequisitionRequest()
        {
            SpecificationFiles= new List<IFormFile>();
        }

    }
    public class PRDelegateTeamRequest
    {
        public long PersonId { get; set; }//
    }
public class PurchaseRequisitionApprovalRequest
    {
        public long PurchaseRequestId { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public List<PRApproversRequest> Approvers { get; set; }
        public PurchaseRequisitionApprovalRequest()
        {
            Approvers = new List<PRApproversRequest>();
        }
    }
    public class PRApproversRequest
    {
        public long PersonId { get; set; } //
        public int Order { get; set; } //

    }
    public class UpdateSpecificationRequest
    {
        public long Id { get; set; }
        public string Specification { get; set; }
    }
    public class RequsitionCancelRequest
    {
        public long Id { get; set; }
        public string Remark { get; set; }
    }
}
