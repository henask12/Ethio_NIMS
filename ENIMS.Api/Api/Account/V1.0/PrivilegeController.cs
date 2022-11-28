using ENIMS.Common;
using ENIMS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Api
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("Privilege/api/V1.0/[controller]")]
    public class PrivilegeController : ControllerBase
    {
        private IPrivilegeService _privilegeService;
        private readonly ILoggerManager _logger;
        public PrivilegeController(
            IPrivilegeService privilegeService,
            ILoggerManager logger)
        {
            _privilegeService = privilegeService;
            _logger = logger;
        }
        [HttpGet(nameof(GetAll))]
        public PrivilegesResponse GetAll()
        {
            return _privilegeService.GetAll();
        }

        [HttpGet(nameof(GetById))]
        public PrivilegeResponse GetById(long id)
        {
            return _privilegeService.GetById(id);
        }

        [HttpPost(nameof(Update))]
        public async Task<PrivilegeResponse> Update(PrivilegeRequest request)
        {
            return await _privilegeService.Update(request);
        }

        [HttpPost(nameof(Create))]
        public async Task<PrivilegeResponse> Create(PrivilegeRequest request)
        {

            return await _privilegeService.Create(request);
        }

        [HttpPost(nameof(Delete))]
        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            return await _privilegeService.Delete(bulkAction.Ids.FirstOrDefault());
        }
    }
}
