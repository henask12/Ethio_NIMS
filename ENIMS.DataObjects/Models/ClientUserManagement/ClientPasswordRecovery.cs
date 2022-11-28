using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
	public class ClientPasswordRecovery : AuditLog
	{
		[Key]
		public long Id { get; set; }
		public string VerificationToken { get; set; }
		public long UserId { get; set; }
		public bool IsPasswordRecovered { get; set; }
		public DateTime RequestedOn { get; set; }
		public DateTime RecoveredOn { get; set; }
		public virtual ClientUser User { get; set; }
	}
}
