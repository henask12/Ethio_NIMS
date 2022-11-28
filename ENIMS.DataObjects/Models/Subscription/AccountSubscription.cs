using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace 
	ENIMS.DataObjects
{
	public class AccountSubscription : AuditLog
	{
		[Key]
		public long Id { get; set; }
		public string CompanyName { get; set; }
		public bool IsAccountActivated { get; set; }//set when email is confirmed
	}
}
