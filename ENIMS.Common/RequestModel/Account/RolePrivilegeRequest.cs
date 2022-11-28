using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class RolePrivilegeRequest
	{
		public long Id { get; set; }

		[Required]
		public long PrivilegeId { get; set; }

		[Required]
		public long RoleId { get; set; }
	}
}
