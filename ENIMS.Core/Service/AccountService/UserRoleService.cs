using ENIMS.Common;
using ENIMS.DataObjects;
using System.Linq;

namespace ENIMS.Core
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepositoryBase<UserRole> _userRoleRepository;
        public UserRoleService(IRepositoryBase<UserRole> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public UserRolesResponse GetAll()
        {
            var userRoles = _userRoleRepository.Where(r=>r.RecordStatus== RecordStatus.Active).ToList();
            var userRolesResponse = new UserRolesResponse();
            foreach (var userRole in userRoles)
            {
                UserRolesRes userRolesRes = new UserRolesRes();
                userRolesRes.Id = userRole.Id;
                userRolesRes.UserId = userRole.UserId;
                userRolesRes.RoleId = userRole.RoleId;
                userRolesResponse.UserRoles.Add(userRolesRes);
            }
            userRolesResponse.Status = OperationStatus.SUCCESS;
            userRolesResponse.Message = Resources.OperationSucessfullyCompleted;

            return userRolesResponse;
        }

        public UserRolesResponse GetByUserId(long userId)
        {
            var userRoles = _userRoleRepository.Where(r => r.RecordStatus == RecordStatus.Active && r.UserId== userId).ToList();
            var userRolesResponse = new UserRolesResponse();
            foreach (var userRole in userRoles)
            {
                UserRolesRes userRolesRes = new UserRolesRes();
                userRolesRes.Id = userRole.Id;
                userRolesRes.UserId = userRole.UserId;
                userRolesRes.RoleId = userRole.RoleId;
                userRolesResponse.UserRoles.Add(userRolesRes);
            }
            userRolesResponse.Status = OperationStatus.SUCCESS;
            userRolesResponse.Message = Resources.OperationSucessfullyCompleted;
            return userRolesResponse;
        }
    }
}
