using System.Collections.Generic;

namespace ENIMS.Common
{
    public class PrivilegesResponse : OperationStatusResponse
	{
		public List<PrivilegeRes> Privileges { get; set; }
		public PrivilegesResponse()
		{
			Privileges = new List<PrivilegeRes>();
		}
	}


	public class PrivilegeResponse : OperationStatusResponse
	{
		public PrivilegeRes Privilege { get; set; }
    }

	public class PrivilegeRes
	{
		public long Id { get; set; }
		public string Action { get; set; }
		public string Module { get; set; }
        public string Controller { get; set; }
        public string Description { get; set; }
	}


    public class GroupPrivilegesResponse : OperationStatusResponse 
    {
        public List<PrivilegeModule> Modules { get; set; }
    }
    public class PrivilegeModule
    {
        public string Name { get; set; }
        public List<PrivilegeController> Controllers { get; set; }
    }
    public class PrivilegeController
    {
        public string Name { get; set; }
        public List<PrivilegeAction> Actions { get; set; }
        public List<PrivilegeAction> MorePermissions { get; set; } 
    }
    public class PrivilegeAction
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
