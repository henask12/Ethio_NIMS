using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ProjectCancelationResponse :OperationStatusResponse
    {
        public ProjectCancelationDto Response { get; set; }
    }


    public class ProjectCancelationDto
    {
        public ProjectCancelationDto()
        {
            Offices = new List<ProjectCancelRequestOfficeDto>();
            Approvers = new List<ProjectCancelRequestApproversDto>();
            Attachements = new List<ProjectCancelRequestAttachementDto>();
        }
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public ApprovalStatus Status { get; set; }
        public string ApprovalDate { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public List<ProjectCancelRequestAttachementDto> Attachements { get; set; }
        public List<ProjectCancelRequestApproversDto> Approvers { get; set; }
        public List<ProjectCancelRequestOfficeDto> Offices { get; set; }
    }
    public class ProjectCancelRequestAttachementDto
    {
        public long Id { get; set; }
        public long CancelRequestId { get; set; }
        public string FileName { get; set; }
        public string DisplayName { get; set; }

    }
    public class ProjectCancelRequestApproversDto
    {
        public long Id { get; set; }
        public ApprovalStatus Status { get; set; }
        public string ApprovalDate { get; set; }

        public PersonDTO Person { get; set; }
    }
    public class ProjectCancelRequestOfficeDto
    {
        public long Id { get; set; }
        public OfficeDTO Office { get; set; }
    }
}
