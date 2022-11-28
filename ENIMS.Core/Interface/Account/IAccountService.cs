using ENIMS.Common;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public interface IAccountService
    {
        Task<UserSignInResponse> SignIn(UserSignInRequest request);
        Task<OperationStatusResponse> SignOut(UserSignOutRequest request);
        Task<OperationStatusResponse> ForgotPassword(ForgotPasswordRequest forwardPasswordRequest);
        Task<OperationStatusResponse> ResetPassword(ResetPasswordRequest resetPasswordRequest);
        Task<OperationStatusResponse> ResetForgotPassword(ResetPasswordRequest resetPasswordRequest);
        Task<UserSignInResponse> RefreshAccessToken(string refreshToken);
        Task<UserSignInResponse> GetAccessToken(string email);
        PrivilegesResponse GetPrivilages(string userName);
        Task<UserResponse> GetByUserName(string userName);
        //UserOfficeResponse GetUserOffice(long userId);
        OperationStatusResponse AccountLocking(AccountLocking accountLocking);
    }
}
