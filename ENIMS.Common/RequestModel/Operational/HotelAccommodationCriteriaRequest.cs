using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class HotelAccommodationCriteriaRequest
    {
        public long Id { get; set; }
        public int DailyRoomNumber { get; set; }
        public int WeeklyFrequency { get; set; }
        public int YearlyFrequency { get; set; }
        public long ProjectId { get; set; }

    }
}
