using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace 
    ENIMS.Common.RequestModel.Report
{
    public class ExcutiveSummaryRequest
    {
        public ExcutiveSummaryRequest()
        {
            FileAttachements = new List<IFormFile>();
        }
        [Required]
        public long ProjectId { get; set; }
        [Required]
        public string TO { get; set; }
        [Required]
        public string Body { get; set; }
        public string Recommendation { get; set; }
        public string ApproverOffices { get; set; }
        public string CarbonCopieOffices { get; set; }
        public bool IsNegotiation { get; set; }
        public List<IFormFile> FileAttachements { get; set; }
    }
}
