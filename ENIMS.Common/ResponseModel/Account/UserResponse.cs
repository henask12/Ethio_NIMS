using ENIMS.Common.ResponseModel;
using ENIMS.Common.ResponseModel.MasterData;
using System.Collections.Generic;

namespace ENIMS.Common
{
    public class UsersResponse: OperationStatusResponse
	{
		public List<UserRes> Users { get; set; }
		public UsersResponse()
		{
			Users = new List<UserRes>();
		}
	}

	public class UserResponse:OperationStatusResponse
	{
		public UserRes User { get; set; }
	}

	public class UserRes
	{
		public long Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool IsSuperAdmin { get; set; }
		public bool IsAccountLocked { get; set; }
		public RecordStatus RecordStatus { get; set; }
		public List<UserRoleRes> Roles { get; set; }
		public bool IsConfirmationEmailSent { get; set; }
		public bool IsReadOnly { get; set; }
		public string PhoneNumber { get; set; }
		public AccountType AccountType { get; set; }

		//
		public long UserId { get; set; }
		public long AccountSubscriptionId { get; set; }
		public long? CountryId { get; set; }
		public string CompanyName { get; set; }
		public SupplierDTO Supplier { get; set; }
		public PersonDTO Person { get; set; }

		public UserRes()
		{
			Roles = new List<UserRoleRes>();
		}
	}

	public class UserRoleRes
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
