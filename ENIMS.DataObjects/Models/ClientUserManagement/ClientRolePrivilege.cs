using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
	public class ClientRolePrivilege: AuditLog
    {
		[Key]
		public long Id { get; set; }
		public long PrivilegeId { get; set; }		
		public long RoleId { get; set; }
		public virtual ClientRole Role { get; set; }
		public virtual ClientPrivilege Privilege { get; set; }
	}
}
