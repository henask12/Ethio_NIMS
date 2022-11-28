using ENIMS.Common.RequestModel.Operational;
using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ProjectTeamResponse : OperationStatusResponse
    {
        public ProjectTeamResponseDTO Response { get; set; }
        public ProjectTeamResponse()
        {
            Response = new ProjectTeamResponseDTO();
        }  
    }
    public class ProjectTeamResponseDTO : OperationStatusResponse
    {
        public List<ProjectTeamDTO> Teams { get; set; }
        public List<ProjectApprovalDTO> Approvers { get; set; }
        public ProjectTeamResponseDTO()
        {
            Teams = new List<ProjectTeamDTO>();
            Approvers = new List<ProjectApprovalDTO>();
        }
    }

    public class ProjectTeamDTO
    {
        public long Id { get; set; }
        //public ProjectDTO projectDTO { get; set; }
        public PersonDTO Person { get; set; }
        public MemberRole Role { get; set; }
    }
    public class ProjectApprovalDTO 
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }
        public bool IsApprover { get; set; }
        public ApprovalStatus Status { get; set; }
        public string ApprovalDateTime { get; set; }

    }
}
