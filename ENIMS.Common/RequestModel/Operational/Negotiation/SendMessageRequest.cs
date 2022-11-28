using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational.Negotiation
{
    public class SendMessageRequest
    {
        public SendMessageRequest()
        {
            Files = new List<IFormFile>();
        }
        [Required]
        public long Id { get; set; }
        [Required]
        public string Body { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
