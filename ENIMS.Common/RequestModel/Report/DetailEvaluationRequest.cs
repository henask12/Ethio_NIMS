using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Report
{
    public class DetailEvaluationRequest
    {
        public DetailEvaluationRequest()
        {
            Attachements = new List<IFormFile>();
        }
        public long ProjectId { get; set; }
        public string To { get; set; }//
        public string Subject { get; set; }
        public string Background { get; set; }
        public string TechnicalAndFinancialEvaluation { get; set; }
        public string ConclusionAndRecommendation { get; set; }
        public string Annexes { get; set; }
        public bool ShowTechnicalProposal { get; set; } = false;
        public bool ShowFinancialProposal { get; set; } = false;
        public string CopiedOffices { get; set; }// 
        public List<IFormFile> Attachements { get; set; }
    }
    public class NegotiationDetailEvaluationRequest
    {
        public long ProjectId { get; set; }
        public string To { get; set; }//
        public string Subject { get; set; }
        public string Background { get; set; }
        public string TechnicalAndFinancialEvaluation { get; set; }
        public string ConclusionAndRecommendation { get; set; }
        public string Annexes { get; set; }
        public string CopiedOffices { get; set; }// 
        public List<IFormFile> Attachements { get; set; }
        public NegotiationDetailEvaluationRequest()
        {
            Attachements = new List<IFormFile>();
        }
    }
}
 
