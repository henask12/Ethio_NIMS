using System.Collections.Generic;

namespace ENIMS.Common
{
    public class RolesResponse : OperationStatusResponse
	{
		public List<RoleRes> Roles { get; set; }		
		public RolesResponse()
		{
			Roles = new List<RoleRes>();
		}
	}
	public class RoleResponse : OperationStatusResponse
	{
		public RoleRes Role { get; set; }
	}
	
	public class RoleRes
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<PrivilegeRes> Privileges { get; set; } 
		public RecordStatus RecordStatus { get; set; }
		public RoleRes()
		{
			Privileges = new List<PrivilegeRes>();
		}
	}

	//public class RolePrivilegeRes
	//{
	//	public long Id { get; set; }
	//	public string Action { get; set; }
	//}
}
