using 
    ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ExcutiveSummaryResponse :OperationStatusResponse
    {
        public ExcutiveSummaryDto Response { get; set; }
        public ExcutiveSummaryResponse()
        {
            Response = new ExcutiveSummaryDto();
        }
    }

    public class ExcutiveSummaryDto
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string Recommendation { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public DateTime ApprovalDate { get; set; }
        public  ProjectDTO Project { get; set; }
        public List<ExcutiveSummaryOfficeDto> OfficeApprovers { get; set; }
        public List<ExcutiveSummaryApprovalDto> EmployeeApprovers { get; set; }
        public List<ExcutiveSummaryAttachementDto> Attachements { get; set; }
        public ExcutiveSummaryDto()
        {
            OfficeApprovers = new List<ExcutiveSummaryOfficeDto>();
            EmployeeApprovers = new List<ExcutiveSummaryApprovalDto>();
            Attachements = new List<ExcutiveSummaryAttachementDto>();
        }


        public class ExcutiveSummaryOfficeDto
        {
            public long Id { get; set; }
            public bool isApprover { get; set; }
            public  OfficeDTO Office { get; set; }
        }
        public class ExcutiveSummaryApprovalDto
        {
            public long Id { get; set; }
            public bool IsApprover { get; set; }
            public ApprovalStatus ApprovalStatus { get; set; }
            public string ApprovalDateTime { get; set; }

            public PersonDTO Person { get; set; }

        }

        public class ExcutiveSummaryAttachementDto
        {
            public long Id { get; set; }
            public string Attachment { get; set; }
            public string AttachmentDisplay { get; set; }
        }
    }

}
