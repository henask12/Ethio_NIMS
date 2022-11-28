using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public class AccountSubscriptionsResponse: OperationStatusResponse
	{
		public List<AccountSubscriptionResponse> AccountSubscriptions { get; set; }
		public AccountSubscriptionsResponse()
		{
			AccountSubscriptions = new List<AccountSubscriptionResponse>();
		}
	}
	public class AccountSubscriptionResponse : OperationStatusResponse
	{
		public long Id { get; set; }
		public string CompanyName { get; set; }
		public string ConnectionString { get; set; }
		public bool IsAccountActivated { get; set; }
		public bool IsDatabaseCreated { get; set; }
	}
}
