using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class NewUserRequest 
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
		public AccountType AccountType { get; set; }

		public long? PersonId { get; set; }
		public long? SupplierId { get; set; }
		public long ClientId { get; set; }
	}



	public class UpdateUserRequest
	{
		public long Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
		public bool IsSuperAdmin { get; set; }
		public List<long> Roles { get; set; }
	}

}
