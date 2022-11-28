using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class NegotiationTeamFormationRequest
    {
        [Required]
        public long ProjectId { get; set; }
        public long FromOffice { get; set; }
        public List<long> CarbonCopyOffice { get; set; }
        public string NegotiationTeamBody { get; set; }
        public List<NegotiationApprovers> Approvers { get; set; }
        public List<NegotiatonTeamRequest> Team { get; set; }
        public List<NegotiationApprovers> CarbonCopies { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public NegotiationTeamFormationRequest()
        {
            Team = new List<NegotiatonTeamRequest>();
            Approvers = new  List<NegotiationApprovers>();
            CarbonCopies = new  List<NegotiationApprovers>();
        }
    }
    public class NegotiatonTeamRequest
    {
        public long? PersonId { get; set; }
        public MemberRole Role { get; set; }
    }
    public class NegotiationApprovers
    {
        public long PersonId { get; set; }
    } 
}
