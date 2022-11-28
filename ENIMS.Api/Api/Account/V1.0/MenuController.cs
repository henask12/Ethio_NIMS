using ENIMS.Common;
using ENIMS.Common.RequestModel.Account;
using ENIMS.Common.ResponseModel.Account;
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
    [Route("api/V1.0/[controller]")]
    public class MenuController : ControllerBase
    {
        private IBaseService<MenuRequest, MenuResponse, MenusResponse> _menuService;
        private readonly ILoggerManager _logger;
        public MenuController(
            IBaseService<MenuRequest, MenuResponse, MenusResponse> menuService,
            ILoggerManager logger)
        {
            _menuService = menuService;
            _logger = logger;
        }
        [HttpGet(nameof(GetAll))]
        public MenusResponse GetAll()
        {
            return _menuService.GetAll();
        }

        [HttpGet(nameof(GetById))]
        public MenuResponse GetById(long id)
        {
            return _menuService.GetById(id);
        }

        [HttpPut(nameof(Update))]
        public async Task<MenuResponse> Update(MenuRequest request)
        {
            return await _menuService.Update(request);
        }

        [HttpPost(nameof(Create))]
        public async Task<MenuResponse> Create(MenuRequest request)
        {
            return await _menuService.Create(request);
        }

        [HttpPost(nameof(Delete))]
        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            return await _menuService.Delete(bulkAction.Ids.FirstOrDefault());
        }
    }
}
