using System.Collections.Generic;

namespace ENIMS.Common
{
    public class UserRequest
	{
		public long Id { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		
		//public long RoleId { get; set; }
		public List<long> Roles { get; set; }

		public long? PersonId { get; set; }
		public long? SupplierId { get; set; }
		public long ClientId { get; set; }
		public AccountType accountType { get; set; }
	}

	public class UserDeleteRequest
	{
		public long Id { get; set; }
	}


	public class ClientUserRequest
	{
		public long Id { get; set; }
		public string Password { get; set; }
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool IsSuperAdmin { get; set; }
		public long ClientRoleId { get; set; }
	}
}
