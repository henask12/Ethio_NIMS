using ENIMS.Common;
using ENIMS.Common.RequestModel.Account;
using ENIMS.Common.ResponseModel.Account;
using ENIMS.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ENIMS.Core.Interface.Helper;

namespace ENIMS.Core.Service.Account
{
    public class MenuService : IBaseService<MenuRequest, MenuResponse, MenusResponse>
    {
        private readonly IAppUnitOfWork _appUow;
        private readonly IRepositoryBase<Menu> _menuRepository;

        public MenuService(
            IRepositoryBase<Menu> menuRepository,
            IAppUnitOfWork appUow)
        {
            _menuRepository = menuRepository;
            _appUow = appUow;
        }

        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            if (bulkAction?.Ids == null || bulkAction.Ids.Count < 1)
            {
                return new OperationStatusResponse
                {
                    Message = Resources.PleaseSelectOneRecordToDelete,
                    Status = OperationStatus.ERROR,
                };
            }
            foreach (var menuId in bulkAction?.Ids)
            {
                var menu = await _menuRepository.Where(c => c.Id == menuId).FirstOrDefaultAsync();
                if (menu == null)
                    return new OperationStatusResponse
                    {
                        Message = Resources.RecordDoesNotExist,
                        Status = OperationStatus.ERROR,
                    };
                _menuRepository.Remove(menu);
                _appUow.SaveChanges();
            }
            return new OperationStatusResponse
            {
                Message = Resources.OperationSucessfullyCompleted,
                Status = OperationStatus.SUCCESS,
            };
        }
        public async Task<OperationStatusResponse> Delete(long id)
        {
            if (id < 1)
            {
                return new OperationStatusResponse
                {
                    Message = Resources.PleaseSelectOneRecordToDelete,
                    Status = OperationStatus.ERROR,
                };
            }

            var menu = await _menuRepository.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (menu == null)
                return new OperationStatusResponse
                {
                    Message = Resources.RecordDoesNotExist,
                    Status = OperationStatus.ERROR,
                };
            _menuRepository.Remove(menu);
            _appUow.SaveChanges();

            return new OperationStatusResponse
            {
                Message = Resources.OperationSucessfullyCompleted,
                Status = OperationStatus.SUCCESS,
            };
        }

        public MenusResponse GetAll()
        {
            var menus = _menuRepository.All().OrderBy(o => o.Name);
            MenusResponse menusResponse = new MenusResponse();
            foreach (var menu in menus)
            {
                MenuRes menuRes = new MenuRes();
                menuRes.Id = menu.Id;
                menuRes.Icon = menu.Icon;
                menuRes.Name = menu.Name;
                menuRes.Url = menu.Url;
                menuRes.ParentId = menu.ParentId;
                menuRes.Privilages = menu.Privilages;
                menusResponse.Menus.Add(menuRes);
            }
            menusResponse.Status = OperationStatus.SUCCESS;
            menusResponse.Message = Resources.OperationSucessfullyCompleted;
            return menusResponse;
        }

        public MenuResponse GetById(long id)
        {
            var menu = _menuRepository.Where(c => c.Id == id).FirstOrDefault();
            if (menu == null)
                return new MenuResponse { Status = OperationStatus.ERROR, Message = Resources.RecordDoesNotExist };
            MenuResponse menuResponse = new MenuResponse();
            menuResponse.Menu = new MenuRes();
            menuResponse.Menu.Id = menu.Id;
            menuResponse.Menu.Icon = menu.Icon;
            menuResponse.Menu.Name = menu.Name;
            menuResponse.Menu.Url = menu.Url;
            menuResponse.Menu.ParentId = menu.ParentId;
            menuResponse.Menu.Privilages = menu.Privilages;
            menuResponse.Status = OperationStatus.SUCCESS;
            menuResponse.Message = Resources.OperationSucessfullyCompleted;
            return menuResponse;
        }

        public async Task<MenuResponse> Create(MenuRequest request)
        {
            var previousMenu = await _menuRepository.Where(c => c.Url == request.Url).FirstOrDefaultAsync();
            if (previousMenu != null && !String.IsNullOrEmpty(request.Url))
                return new MenuResponse { Message = Resources.RecordAlreadyExist, Status = OperationStatus.ERROR };

            var newMenu = new Menu
            {
                Name = request.Name,
                Url = request.Url,
                Icon = request.Icon,
                ParentId = request.ParentId,
                Privilages = request.Privilages
            };
            _menuRepository.Add(newMenu);
            return new MenuResponse
            {
                Message = Resources.OperationSucessfullyCompleted,
                Status = OperationStatus.SUCCESS
            };

        }

        public async Task<MenuResponse> Update(MenuRequest request)
        {
            var menu = await _menuRepository.Where(c => c.Id == request.Id).FirstOrDefaultAsync();

            if (menu == null)
                return new MenuResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };

            menu.Name = request.Name;
            menu.Url = request.Url;
            menu.Icon = request.Icon;
            menu.ParentId = request.ParentId;
            menu.Privilages = request.Privilages;
            _menuRepository.Update(menu);
            return new MenuResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
        }

        public Task<OperationStatusResponse> UpdateStatus(BulkAction bulkAction)
        {
            throw new NotImplementedException();
        }      
    }
}
