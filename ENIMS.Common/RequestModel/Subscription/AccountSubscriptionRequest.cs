using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public class AccountSubscriptionRequest
	{
		public long Id { get; set; }
		public string CompanyName { get; set; }
		public string ConnectionString { get; set; }
		public bool IsAccountActivated { get; set; }
		public bool IsDatabaseCreated { get; set; }
	}
}
