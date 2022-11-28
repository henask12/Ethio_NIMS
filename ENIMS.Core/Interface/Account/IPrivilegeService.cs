using ENIMS.Common;
using ENIMS.Core.Interface.Helper;

namespace ENIMS.Core
{
    public interface IPrivilegeService : IBaseService<PrivilegeRequest, PrivilegeResponse, PrivilegesResponse>
    {
        GroupPrivilegesResponse GetGroupPrivilege();
    }
}
