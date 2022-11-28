using Audit.EntityFramework;
using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
    public class EmailTemplate :AuditLog
    {
        [Key]
        public long Id { get; set; }
        public EmailTemplateType TemplateType { get; set; }
		public string Template { get; set; }
		public string Subject { get; set; }
		public string ClientLandingUri { get; set; } 

    }
}
