using ENIMS.Common;

namespace ENIMS.Core
{
    public interface IUserRoleService
    {
        UserRolesResponse GetAll();
        UserRolesResponse GetByUserId(long userId);
    }
}
