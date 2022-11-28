using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common.RequestModel.Report
{
    public class DetailEvaluationUpdateRequest
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Background { get; set; }
        public string TechnicalAndFinancialEvaluation { get; set; }
        public string ConclusionAndRecommendation { get; set; }
        public string Annexes { get; set; }
        public bool ShowTechnicalProposal { get; set; }
        public bool ShowFinancialProposal { get; set; }

        public List<IFormFile> Attachement  { get; set; }
        public string OfficeApprover { get; set; }
        public DetailEvaluationUpdateRequest()
        {
            Attachement = new List<IFormFile>();
        }
    }
    public class DetailNegotiationEvaluationUpdateRequest
    {

        [Required]
        public long Id { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Background { get; set; }
        public string TechnicalAndFinancialEvaluation { get; set; }
        public string ConclusionAndRecommendation { get; set; }
        public string Annexes { get; set; }
        public bool ShowTechnicalProposal { get; set; }
        public bool ShowFinancialProposal { get; set; }

        public List<IFormFile> Attachement { get; set; }
        public string OfficeApprover { get; set; }
    }
}
