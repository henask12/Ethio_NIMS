using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class RequestForDocRequest
    {
        public long Id { get; set; }
        public RequestDocumentType RequestDocumentType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long ProjectId { get; set; }
        public IEnumerable<IFormFile>? Attachements { get; set; }

    }

    public class DocumentApprovalRequest
    {
        public long RequestForDocumentId { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}
