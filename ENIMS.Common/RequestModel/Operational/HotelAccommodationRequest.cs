using ENIMS.Common.RequestModel.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class HotelAccommodationRequest
    {
        public long Id { get; set; }
        public string RequestName { get; set; }
        public string Section { get; set; }
        public HotelServiceType HotelServiceType { get; set; }
        public OriginatingSection OriginatingSection { get; set; }
        public long CostCenterId { get; set; }
        public long StationId { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public IFormFile SpecificationFile { get; set; }
        public DateTime? ContractExpiredate { get; set; }
        public DateTime Commencementdate { get; set; }
        public string CrewPattern { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string Approvers { get; set; }
        public string Delegates { get; set; }
        public ApprovalType ApprovalType { get; set; }

    }
    public class HotelARDelegateTeamRequest
    {
        public long PersonId { get; set; }//
    }
    public class HotelARApproversRequest
    {
        public long PersonId { get; set; }//
        public int Order { get; set; }//

    }
}
