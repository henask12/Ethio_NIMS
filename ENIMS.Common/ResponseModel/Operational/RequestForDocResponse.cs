using ENIMS.Common;
using ENIMS.Common.ResponseModel.MasterData;
using ENIMS.Common.ResponseModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class RequestForDocResponse : OperationStatusResponse
    {
        public RequestForDocDTO Response { get; set; }
        public RequestForDocResponse()
        {
            Response = new RequestForDocDTO();
        }
    }
    public class RequestForDocsResponse : OperationStatusResponse
    {
        public List<RequestForDocDTO> Response { get; set; }
        public RequestForDocsResponse()
        {
            Response = new List<RequestForDocDTO>();
        }
    }

    public class RequestForDocDTO
    {
        public long Id { get; set; }
        public RequestDocumentType RequestDocumentType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<DocumentAttachementDTO> Attachements { get; set; }
        public List<RequestForDocumentApprovalDTO> Approvers { get; set; }
        public ProjectDTO Project { get; set; }
    }
    public class DocumentAttachementDTO
    {
        public long Id { get; set; }
        public long RequestForDocumentationionId { get; set; }
        public string AttachementPath { get; set; }
        public string AttachementName { get; set; }
    }

    public class RequestForDocumentApprovalDTO
    {
        public long Id { get; set; }
        public long Approver { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public long RequestForDocumentId { get; set; }
        public PersonDTO Person { get; set; }
    }

  

}
