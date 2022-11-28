using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class SubmitProposalRequest
    {
        public  long ProposalId { get; set; }
        public  List<IFormFile> TechnicalAttachements  { get; set; }
        public  List<IFormFile> FinancialAttachements  { get; set; }
    }
}
