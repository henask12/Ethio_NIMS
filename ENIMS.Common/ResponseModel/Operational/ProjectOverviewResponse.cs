using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ProjectOverviewResponse : OperationStatusResponse
    {
        public ProjectOverviewDTO Response { get; set; }
    }
    public class ProjectOverviewDTO
    {
        public string ProjectName { get; set; }
        public string ProjectReferenceCode { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public string RequestedCostCenter { get; set; }
        public List<BECTeamMember> BecTeamMembers { get; set; }
        public string PurchaseMethodType { get; set; }
        public string DocumentType { get; set; }
        public string TechnicalEvaluation { get; set; }
        public string FinancialEvaluation { get; set; }
        public string AwardFactor { get; set; }
        public DateTime BidClosingDate { get; set; }
        public DateTime TechnicalProposalOpeningDate { get; set; }
    }
    public class BECTeamMember
    {
        public string Name { get; set; }
        public string Role { get; set; }

    }

}
