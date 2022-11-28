using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class HotelAccommodationResponse :OperationStatusResponse
    {
        public HotelAccommodationDTO Response { get; set; }
        public HotelAccommodationResponse()
        {
            Response = new HotelAccommodationDTO();
        }
    } 
    public class HotelAccommodationsResponse: OperationStatusResponse
    {
        public List<HotelAccommodationDTO> Responses { get; set; }
        public HotelAccommodationsResponse()
        {
            Responses = new List<HotelAccommodationDTO>();
        }
    }
    public class HotelAccommodationDTO
    {
        public long Id { get; set; }
        public string RequestName { get; set; }
        public PRStatus PRStatus { get; set; }
        public string Section { get; set; }
        public HotelServiceType HotelServiceType { get; set; }
        public OriginatingSection OriginatingSection { get; set; }
        public CostCenterDTO CostCenter { get; set; }
        public StationDTO Station { get; set; } 
        public CountryDTO Country { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public DateTime? ContractExpiredate { get; set; }
        public DateTime Commencementdate { get; set; }
        public DateTime RequestDate { get; set; }
        public string CrewPattern { get; set; }
        public string AttachementPath { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public List<HotelARApproversDTO> Approvers { get; set; }
        public List<HotelARDelegateTeamDTO> DelegateTeams { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public bool isInitiated { get; set; }
        public string RejectionRemark { get; set; }
        public PersonDTO Requester { get; set; }
        public PersonDTO Rejector { get; set; }
        public PersonDTO AssignedAgent { get; set; }
        public PersonDTO Assigner { get; set; }
    }
    public class HotelARDelegateTeamDTO
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }//
    }
    public class HotelARApproversDTO
    {
        public long Id { get; set; }
        public PersonDTO Person { get; set; }
        public int Order { get; set; }
        public string ApprovalDateTime { get; set; }


    }
}

