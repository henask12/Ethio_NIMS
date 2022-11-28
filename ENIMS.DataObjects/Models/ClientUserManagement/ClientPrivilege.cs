using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
	public class ClientPrivilege : AuditLog
	{
		[Key]
		public long Id { get; set; }
		public string Action { get; set; }
		public string Module { get; set; }
		public string Description { get; set; }
		public virtual ICollection<ClientRolePrivilege> Privileges { get; set; }
	}
}
