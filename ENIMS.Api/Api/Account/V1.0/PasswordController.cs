using ENIMS.Common;
using ENIMS.Core;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ENIMS.Api
{
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("Password/api/V1.0/[controller]")]
    public class PasswordController : ControllerBase
    {
        private IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        [HttpPost(nameof(ChangePassword))]
        public async Task<OperationStatusResponse> ChangePassword(ChangePasswordRequest request)
        {
            return await _passwordService.ChangePassword(request);
        }
        [HttpPost(nameof(ForgotPassword))]
        public async Task<OperationStatusResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            return await _passwordService.ForgotPassword(request);
        }
        [HttpPost(nameof(ResetPassword))]
        public async Task<OperationStatusResponse> ResetPassword(ResetPasswordRequest request)
        {
            return await _passwordService.ResetPassword(request);
        }
        [HttpPost(nameof(ResetForgotPassword))]
        public async Task<RecoverPasswordResponse> ResetForgotPassword(ResetForgotPasswordRequest request)
        {
            return await _passwordService.ResetForgotPassword(request);
        }
        [HttpPost(nameof(VerifyRecoveryToken))]
        public async Task<RecoverPasswordResponse> VerifyRecoveryToken(string token)
        {
            return await _passwordService.VerifyRecoveryToken(token);
        }
    }
}
