using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
	public class ClientUser : AuditLog
	{
		[Key]
		public long Id { get; set; }
		[StringLength(30, MinimumLength = 2)]
		[Display(Name = nameof(Resources.Email), ResourceType = typeof(Resources))]
		public string Username { get; set; }
		[Display(Name = nameof(Resources.Email), ResourceType = typeof(Resources))]
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string VerificationToken { get; set; }
		public string Password { get; set; }
		public bool IsSuperAdmin { get; set; }
		public bool IsConfirmationEmailSent { get; set; }
		public bool IsAccountLocked { get; set; }
		public long? ClientRoleId { get; set; }
		public virtual ClientRole ClientRole { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
