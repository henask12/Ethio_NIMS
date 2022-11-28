using ENIMS.Common;
using ENIMS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ENIMS.Api
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("UserRole/api/V1.0/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpGet(nameof(GetAll))]
        public UserRolesResponse GetAll()
        {
            return _userRoleService.GetAll();
        }
        [HttpGet(nameof(GetByUserId))]
        public UserRolesResponse GetByUserId(long userId)
        {
            return _userRoleService.GetByUserId(userId);
        }
    }
}
