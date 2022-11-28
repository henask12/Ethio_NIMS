using ENIMS.Common;
using ENIMS.Core.Interface.Account;
using ENIMS.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ENIMS.Core.Service.Account
{
    public class RolePrivilegeService : IRolePrivilegeService
    {
        private readonly IRepositoryBase<RolePrivilege> _rolePrivilegeRepository;
        public RolePrivilegeService(IRepositoryBase<RolePrivilege> rolePrivilegeRepository)
        {
            _rolePrivilegeRepository = rolePrivilegeRepository;
        }

        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            foreach (var id in bulkAction.Ids)
            {
                var rolePrivilege = await _rolePrivilegeRepository.FirstOrDefaultAsync(u => u.Id == id);
                if (rolePrivilege == null)
                    return new OperationStatusResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };
                _rolePrivilegeRepository.Remove(rolePrivilege);
            }
            return new OperationStatusResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
        }

        public RolePrivilegesResponse GetAll()
        {
            var rolePrivilegesResponse = new RolePrivilegesResponse();
            var rolepriviledges = _rolePrivilegeRepository.All();

            if (rolepriviledges != null)
            {
                foreach (var roleprivilege in rolepriviledges)
                {
                    RolePrivilegeRes rolePrivilegeRes = new RolePrivilegeRes();
                    rolePrivilegeRes.Id = roleprivilege.Id;
                    rolePrivilegeRes.RoleId = roleprivilege.RoleId;
                    rolePrivilegeRes.PrivilegeId = roleprivilege.PrivilegeId;
                    rolePrivilegesResponse.RolePrivileges.Add(rolePrivilegeRes);
                }
            }
            else
            {
                rolePrivilegesResponse.Status = OperationStatus.ERROR;
                rolePrivilegesResponse.Message = Resources.RecordDoesNotExist;
                return rolePrivilegesResponse;
            }
            rolePrivilegesResponse.Status = OperationStatus.SUCCESS;
            rolePrivilegesResponse.Message = Resources.OperationSucessfullyCompleted;
            return rolePrivilegesResponse;
        }

        public RolePrivilegeResponse GetById(long Id)
        {
            var rolePrivilegeResponse = new RolePrivilegeResponse();
            var rolepriviledges = _rolePrivilegeRepository.All();
            if (rolepriviledges != null)
            {
                foreach (var roleprivilege in rolepriviledges)
                {
                    rolePrivilegeResponse.RolePrivilege = new RolePrivilegeRes();
                    rolePrivilegeResponse.RolePrivilege.Id = roleprivilege.Id;
                    rolePrivilegeResponse.RolePrivilege.RoleId = roleprivilege.RoleId;
                    rolePrivilegeResponse.RolePrivilege.PrivilegeId = roleprivilege.PrivilegeId;
                }
            }
            else
            {
                rolePrivilegeResponse.Status = OperationStatus.ERROR;
                rolePrivilegeResponse.Message = Resources.RecordDoesNotExist;
                return rolePrivilegeResponse;
            }
            rolePrivilegeResponse.Status = OperationStatus.SUCCESS;
            rolePrivilegeResponse.Message = Resources.OperationSucessfullyCompleted;
            return rolePrivilegeResponse;
        }

        public async Task<RolePrivilegeResponse> Save(RolePrivilegeRequest request)
        {
            if (request.PrivilegeId == 0 && request.RoleId == 0)
                return new RolePrivilegeResponse { Message = Resources.InvalidClientCredential, Status = OperationStatus.ERROR };
            RolePrivilege rolePrivilege = new RolePrivilege();
            rolePrivilege.RoleId = request.RoleId;
            rolePrivilege.PrivilegeId = request.PrivilegeId;
            _rolePrivilegeRepository.Add(rolePrivilege);
            return new RolePrivilegeResponse
            {
                Message = Resources.OperationSucessfullyCompleted,
                Status = OperationStatus.SUCCESS
            };
        }

        public RolePrivilegeResponse SaveRange(List<RolePrivilegeRequest> requests)
        {
            foreach (var request in requests)
            {
                if (request.PrivilegeId == 0 && request.RoleId == 0)
                    return new RolePrivilegeResponse { Message = Resources.ErrorHasOccuredWhileProcessingYourRequest, Status = OperationStatus.ERROR };
                RolePrivilege rolePrivilege = new RolePrivilege
                {
                    RoleId = request.RoleId,
                    PrivilegeId = request.PrivilegeId
                };
                _rolePrivilegeRepository.Add(rolePrivilege);
            }
            return new RolePrivilegeResponse
            {
                Message = Resources.OperationSucessfullyCompleted,
                Status = OperationStatus.SUCCESS
            };
        }
    }
}
