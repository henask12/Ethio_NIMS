using ENIMS.Common;
using ENIMS.DataObjects.Models.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.DataObjects
{
    public class User : AuditLog
    {
        [Key]
        public long Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        //[Display(Name = nameof(Resources.Email), ResourceType = typeof(Resources))]
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsAccountLocked { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }

        //Additional fields
        public string PhoneNumber { get; set; }
        public string VerificationToken { get; set; }
        public int LoginAttemptCount { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public bool IsConfirmationEmailSent { get; set; }
        //public bool FirstLogin { get; set; }
    }
}
