using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ProposalResponses :OperationStatusResponse
    {
       public List<ProposalDTO> Response { get; set; }
        public ProposalResponses()
        {
            Response = new List<ProposalDTO>();
        }
    }

    public class ProposalDTO
    {
        public ProposalDTO()
        {
            Attachements = new List<AttachedFile>();
        }
        public long Id { get; set; }
        public string ProjectTitle { get; set; }
        public long ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? Deadline { get; set; }
        public List<AttachedFile> Attachements { get; set; }
        public string DetailSubject { get; set; }
        public string DetailBody { get; set; }
        public bool IsSubmited { get; set; }
    }
}
