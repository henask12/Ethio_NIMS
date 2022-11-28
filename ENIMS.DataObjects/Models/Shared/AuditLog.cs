using ENIMS.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ENIMS.DataObjects
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

