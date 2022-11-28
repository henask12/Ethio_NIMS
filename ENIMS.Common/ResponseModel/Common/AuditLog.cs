using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Common
{
    public class AuditLog
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public string TimeZoneInfo { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public bool IsReadOnly { get; set; }
    }
}
