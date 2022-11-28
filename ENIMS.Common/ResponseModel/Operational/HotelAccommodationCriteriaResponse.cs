using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class HotelAccommodationCriteriaResponse :OperationStatusResponse
    {
        public HotelAccommodationCriteriaDTO Response { get; set; }
        public HotelAccommodationCriteriaResponse()
        {
            Response = new HotelAccommodationCriteriaDTO();
        }
    }
     public class HotelAccommodationCriteriasResponse :OperationStatusResponse
    {
        public List<HotelAccommodationCriteriaDTO> Response { get; set; }
        public HotelAccommodationCriteriasResponse()
        {
            Response = new List<HotelAccommodationCriteriaDTO>();
        }
    }

    public class HotelAccommodationCriteriaDTO
    {
        public long Id { get; set; }
        public int DailyRoomNumber { get; set; }
        public int WeeklyFrequency { get; set; }
        public int YearlyFrequency { get; set; }
        public  ProjectDTO Project { get; set; }
    }

}
