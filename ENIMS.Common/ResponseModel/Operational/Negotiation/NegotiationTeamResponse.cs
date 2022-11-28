using ENIMS.Common.ResponseModel.MasterData;
using System.Collections.Generic;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class NegotiationTeamResponse :OperationStatusResponse
    {
       public NegotiationTeamDto Response { get; set; }
        public NegotiationTeamResponse()
        {
            Response = new NegotiationTeamDto();
        }
           
    }

    public class NegotiationTeamDto
    {
        public ApprovalStatus status { get; set; }
        public ApprovalType TeamApprovalType { get; set; }
        public List<NegotiationTeamMemberDto> Team { get; set; }
        public List<NegotiationTeamApproverDto> Approvers { get; set; }
        public NegotiationTeamDto()
        {
            Team = new List<NegotiationTeamMemberDto>();
            Approvers = new List<NegotiationTeamApproverDto>();
        }
    }
    public class NegotiationTeamMemberDto
    {
        public MemberRole Role { get; set; }
        public  PersonDTO Person { get; set; }
    }
    public class NegotiationTeamApproverDto
    {
        public bool IsApprover { get; set; }
        public ApprovalStatus Status { get; set; }
        public string ApprovalDateTime { get; set; }
        public PersonDTO Person { get; set; }
    }

}
