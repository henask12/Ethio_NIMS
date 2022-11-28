using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational.Negotiation
{
    public class GroupedNegotiationCommunicationResponse :OperationStatusResponse
    {
        public List<ProjectNegotiationDto> Response { get; set; }
        public GroupedNegotiationCommunicationResponse()
        {
            Response = new List<ProjectNegotiationDto>();
        }
    }

    public class ProjectNegotiationDto
    {
        public ProjectDTO Project { get; set; }
        public List<NegotiationCommunicationDto> Negotiation { get; set; }





        public ProjectNegotiationDto()
        {
            Negotiation = new List<NegotiationCommunicationDto>();
        }
    }
}
