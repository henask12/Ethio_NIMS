using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class CountryResponse:OperationStatusResponse
    {
        public CountryDTO Response { get; set; }
        public CountryResponse()
        {
            Response = new CountryDTO();
        }

    }
    public class CountriesResponse:OperationStatusResponse
    {
        public List<CountryDTO> Response { get; set; }
        public CountriesResponse()
        {
            Response = new List<CountryDTO>();
        }

    }
    public class CountryDTO
    {
        public long Id { get; set; }
        public string ShortName { get; set; }
        public string CountryName { get; set; }

    }
}
