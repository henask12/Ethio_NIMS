using ENIMS.Common.ResponseModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Report
{
    public class OverallProjectReportResponse :OperationStatusResponse
    {
        public OverallProjectReportDto Response { get; set; }
        public OverallProjectReportResponse()
        {
            Response = new OverallProjectReportDto();
        }
    }

    public class OverallProjectReportDto
    {
        public OverallProjectReportDto()
        {
            Suppliers = new List<EvaluationSummary>();
        }
        public string RequestType { get; set; }
        public string RequestName { get; set; }
        public string RquestingDivision { get; set; }
        public string CostCenter { get; set; }
        public string RequestedBy { get; set; }
        public string DateOfRequest { get; set; }
        public string DateOfApproval { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectTeamDTO> BecTeam { get; set; }
        public string ProcurementMethod { get; set; }
        public string TechnicalEvaluation { get; set; }
        public string FinancialEvaluation { get; set; }
        public string AwardFactor { get; set; }
        public string TotalParticipatedSuppliers { get; set; }
        public string TotalShortListedSuppliers { get; set; }
        public string TotalProposalSubmitedSuppliers { get; set; }
        public string TotalTechnicalQualifiedSuppliers { get; set; }
        public List<EvaluationSummary> Suppliers { get; set; }
    }
    public class EvaluationSummary
    {
        public int Number { get; set; }
        public string SupplierName { get; set; }
        public string TechnicalResult { get; set; }
        public string FinancialResult { get; set; }
        public string TotalAmmount { get; set; }
        public string CombinedSum { get; set; }
        public string Rank { get; set; }
    }
}
