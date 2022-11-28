using ENIMS.Common;
using ENIMS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ENIMS.Core.Interface.Helper;

namespace ENIMS.Api
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("Role/api/V1.0/[controller]")]
    public class RoleController : ControllerBase
    {
        //private readonly RoleService _roleService;
        private readonly IBaseService<RoleRequest,RoleResponse,RolesResponse> _roleService;
        private readonly ILoggerManager _logger;
        public RoleController(
            IBaseService<RoleRequest, RoleResponse, RolesResponse> roleService,
            ILoggerManager logger)
        {
            _roleService = roleService;
            _logger = logger;
        }
        [HttpGet(nameof(GetAll))]
        public RolesResponse GetAll()
        {
            return _roleService.GetAll();
        }

        [HttpGet(nameof(GetById))]
        public RoleResponse GetById(long id)
        {
            return _roleService.GetById(id);
        }

        [HttpPut(nameof(Update))]
        public async Task<RoleResponse> Update(RoleRequest request)
        {
            return await _roleService.Update(request);
        }

        [HttpPost(nameof(Create))]
        public async Task<RoleResponse> Create(RoleRequest request)
        {
            return await _roleService.Create(request);
        }

        [HttpPost(nameof(Delete))]
        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            return await _roleService.Delete(bulkAction.Ids.FirstOrDefault());
        }
    }
}
