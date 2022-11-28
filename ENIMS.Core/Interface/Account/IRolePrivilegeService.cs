using ENIMS.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.Account
{
    public interface IRolePrivilegeService
    {
        RolePrivilegeResponse GetById(long Id);
        RolePrivilegesResponse GetAll();
        Task<RolePrivilegeResponse> Save(RolePrivilegeRequest request);
        RolePrivilegeResponse SaveRange(List<RolePrivilegeRequest> request);
        Task<OperationStatusResponse> Delete(BulkAction bulkAction);
    }
}
