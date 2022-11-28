using ENIMS.Common.ResponseModel.MasterData;
using ENIMS.Common.ResponseModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Report
{
    public class DetailEvaluaitionResponse :OperationStatusResponse
    {
        public DetailEvaluaitionDto Response { get; set; }
        public DetailEvaluaitionResponse()
        {
            Response = new DetailEvaluaitionDto();
        }
    }
    public class DetailEvaluaitionDto
    {
        public long Id { get; set; }
        public string To { get; set; }
        public string Background { get; set; }
        public string TechnicalAndFinancialEvaluation { get; set; }
        public string ConclusionAndRecommendation { get; set; }
        public string Annexes { get; set; }
        public bool ShowTechnicalProposal { get; set; }
        public bool ShowFinancialProposal { get; set; }
        public string ReportFile { get; set; }
        public List<DetailEvaluationOfficeDto> OfficeApprovers { get; set; }
        public List<DetailEvaluationReportAttachementDto> FileAttachements { get; set; }
        public List<DetailEvaluationsSuplierDto> DetailEvaluationsSuplier { get; set; }
    }

    public class DetailEvaluationsSuplierDto
    {
        public DetailEvaluationsSuplierDto()
        {
            TechnicalAttachements = new List<string>();
            FinancialAttachements = new List<string>();
        }  
        public SupplierDTO Supplier { get; set; }
        public List<string> TechnicalAttachements { get; set; }
        public List<string> FinancialAttachements { get; set; }
    }
    public class DetailEvaluationReportAttachementDto
    {
        public long Id { get; set; }
        public string Attachment { get; set; }
    }
    public class DetailEvaluationOfficeDto
    {
        public long Id { get; set; }
        public OfficeDTO Office { get; set; }
    }
}
