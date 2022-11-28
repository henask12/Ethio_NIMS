using System.Collections.Generic;

namespace ENIMS.Common
{
    public class UserRolesResponse : OperationStatusResponse
    {
        public List<UserRolesRes> UserRoles { get; set; }
        public UserRolesResponse()
        {
            UserRoles = new List<UserRolesRes>();
        }
    }
    public class UserRoleResponse : OperationStatusResponse
    {
        public UserRolesRes UserRole { get; set; }
    }
    public class UserRolesRes
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
    }
}
