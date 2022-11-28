using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class ProjectCancelationRequest
    {
        public ProjectCancelationRequest()
        {
            Attachments = new List<IFormFile>();
        }
        public long ProjectId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public string To { get; set; }
        public string Office  { get; set; }
        public string Approvers  { get; set; }
        public ApprovalType ApprovalType { get; set; }
    }
}
