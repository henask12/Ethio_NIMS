using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.DataObjects
{
    public class Privilege : AuditLog
	{
		[Key]
		public long Id { get; set; }
		public string Action { get; set; }
		public string Module { get; set; }
		public string Description { get; set; }
        public bool IsMorePermission { get; set; }
        public virtual ICollection<RolePrivilege> Privileges { get; set; }
	}
}
