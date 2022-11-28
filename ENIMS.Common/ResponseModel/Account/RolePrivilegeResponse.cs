using System.Collections.Generic;

namespace ENIMS.Common
{
    public class RolePrivilegesResponse : OperationStatusResponse
    {
        public List<RolePrivilegeRes> RolePrivileges { get; set; }
        public RolePrivilegesResponse()
        {
            RolePrivileges = new List<RolePrivilegeRes>();
        }
    }
    public class RolePrivilegeResponse : OperationStatusResponse
    {
        public RolePrivilegeRes RolePrivilege { get; set; }

    }
    public class RolePrivilegeRes
    {
        public long Id { get; set; }
        public long PrivilegeId { get; set; }
        public long RoleId { get; set; }
    }
}
