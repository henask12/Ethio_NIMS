using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class SubmitedPropsalResponse : OperationStatusResponse
    {
        public List<SubmitedProposalDTO> Response { get; set; }
        public SubmitedPropsalResponse()
        {
            Response = new List<SubmitedProposalDTO>();
        }
    }
    public class SubmitedProposalDTO
    {
        public SubmitedProposalDTO()
        {
            TechnicalAttachements = new List<string>();
            FinancialAttachements = new List<string>();
        }
        public long Id { get; set; }
        public string  SupplierName { get; set; }
        public DateTime  SubmitionDate { get; set; }
        public List<string> TechnicalAttachements{ get; set; }
        public List<string> FinancialAttachements{ get; set; }
    }
}
