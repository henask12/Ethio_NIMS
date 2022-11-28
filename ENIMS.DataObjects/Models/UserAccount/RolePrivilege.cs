using System.ComponentModel.DataAnnotations;

namespace ENIMS.DataObjects
{
    public class RolePrivilege : AuditLog
    {
		[Key]
		public long Id { get; set; }
		public long PrivilegeId { get; set; }		
		public long RoleId { get; set; }
		public virtual Role Role { get; set; }
		public virtual Privilege Privilege { get; set; }
	}
}
