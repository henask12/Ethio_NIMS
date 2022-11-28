using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class StationRequest
    {
        public long Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public long? CountryId { get; set; }
        public string CountryCode { get; set; } 
    }
    public class StationRequests
    {
        public StationRequests()
        {
            Requests = new List<StationDto>();
        }
        public List<StationDto> Requests{ get; set; }
    }
    public class StationDto
    {
        public long Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string Country { get; set; }
    }

}
