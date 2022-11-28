using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class UserRoleRequest
	{
		public long Id { get; set; }

		[Required]
		public long UserId { get; set; }

		[Required]
		public long RoleId { get; set; }
	}
}
