using System;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.DataObjects
{
    public class PasswordRecovery :AuditLog
	{
		[Key]
		public long Id { get; set; }
		public string VerificationToken { get; set; }
		public long AccountSubscriptionUserId { get; set; }
		public bool IsPasswordRecovered { get; set; }
		public DateTime RequestedOn { get; set; }
		public DateTime RecoveredOn { get; set; }
		public virtual User User { get; set; } 
	}
}
