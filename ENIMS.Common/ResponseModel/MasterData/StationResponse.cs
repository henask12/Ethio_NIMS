using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class StationResponse:OperationStatusResponse
    {
        public StationDTO Response { get; set; }
        public StationResponse()
        {
            Response = new StationDTO();
        }
    }
    public class StationsResponse: OperationStatusResponse
    {
        public List<StationDTO> Response { get; set; }
        public StationsResponse()
        {
            Response = new List<StationDTO>();
        }
    }

    public class StationDTO
    {
        public long Id { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public CountryDTO Country { get; set; }
    }

}
