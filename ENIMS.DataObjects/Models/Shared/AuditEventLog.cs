using Audit.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
    [AuditIgnore]
    public class AuditEventLog
    {
        [Key]
        public long Id { get; set; }
		public string TableUniqueId { get; set; }
        public string LogTableName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JsonData { get; set; }
		public string Action { get; set; }
		public string CurrentUser { get; set; }

	}
}
