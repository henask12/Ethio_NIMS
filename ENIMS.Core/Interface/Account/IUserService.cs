using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.DataObjects.Models.MasterData;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public interface IUserService
    {
        UserResponse GetByUserName(string userName);
        UserResponse GetById(long Id);
        UsersResponse GetAll();
        UsersResponse GetAllSupervisors();
        Task<UserResponse> Save(NewUserRequest request);
        Task<UserResponse> Update(UpdateUserRequest request);
        Task<OperationStatusResponse> Delete(BulkAction bulkAction);
        Task<OperationStatusResponse> UpdateStatus(BulkAction bulkAction);
        Person GetPerson(string userName);
        Task<UserResponse> RegisterSupplier(SupplierRegistrationRequest request);
    }
}
