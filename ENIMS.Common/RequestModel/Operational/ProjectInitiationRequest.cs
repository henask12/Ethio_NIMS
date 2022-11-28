using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class ProjectInitiationRequest
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public bool IsBECMandatory { get; set; }
        public RequestType RequestType { get; set; }
        public long? HotelAccommodationId { get; set; }
        public long? PurchaseRequisitionId { get; set; }
    }
    public class PurchaseProcessTypeRequisition
    {
        public long ProjectId { get; set; }
        public ProjectProcessType ProjectProcessType { get; set; }
        public bool IsTwoStageBiding { get; set; }
    }
}
