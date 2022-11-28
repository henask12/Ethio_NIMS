using ENIMS.Common;
using ENIMS.Core.Interface.Account;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ENIMS.Api
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("RolePrivilege/api/V1.0/[controller]")]
    public class RolePrivilegeController : ControllerBase
    {
        private IRolePrivilegeService _rolePrivilegeService;
        public RolePrivilegeController(IRolePrivilegeService rolePrivilegeService)
        {
            _rolePrivilegeService = rolePrivilegeService;
        }
        [HttpGet(nameof(GetAll))]
        public RolePrivilegesResponse GetAll()
        {
            return _rolePrivilegeService.GetAll();
        }
        [HttpGet(nameof(GetById))]
        public RolePrivilegeResponse GetById(long id)
        {
            return _rolePrivilegeService.GetById(id);
        }
        [HttpPost(nameof(Save))]
        public async Task<RolePrivilegeResponse> Save(RolePrivilegeRequest request)
        {
            return await _rolePrivilegeService.Save(request);
        }
        [HttpPost(nameof(SaveRange))]
        public RolePrivilegeResponse SaveRange(List<RolePrivilegeRequest> requests)
        {
            return  _rolePrivilegeService.SaveRange(requests);
        }
        [HttpPost(nameof(Delete))]
        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            return await _rolePrivilegeService.Delete(bulkAction);
        }
    }
}
