using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{

    public class ProjectTeamRequest
    {
        public List<ProjectTeamRequestDTO> Requests { get; set; }
        public List<ProjectApprovalRequest> Approvers { get; set; }
        public List<ProjectApprovalRequest> CarbonCopies { get; set; }
        public ApprovalType ApprovalType { get; set; }

    }
    public class ProjectTeamRequestDTO
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? PersonId { get; set; }
        public MemberRole Role { get; set; }
    }
    public class ProjectApprovalRequest
    {
        public long PersonId { get; set; }
        public int Order { get; set; }

    }
}
