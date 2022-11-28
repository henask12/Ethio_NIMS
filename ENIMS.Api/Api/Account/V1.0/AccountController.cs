using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ENIMS.Api
{
    [AllowAnonymous]
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("User/api/V1.0/[controller]")]
    public class AccountController : ControllerBase
    {
        private IPrivilegeService _privilegeService;

        private IAccountService _accountService;
        private IUserService _userService;
        //private readonly Core.IAuthorizationService _authorizationService;

        private readonly ILoggerManager _logger;
        public AccountController(IPrivilegeService privilegeService, IAccountService accountService,
            IUserService userService, ILoggerManager logger, Core.IAuthorizationService authorizationService)
        {
            _privilegeService = privilegeService;
            _accountService = accountService;
            _logger = logger;
            _userService = userService;
            //_authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(SignIn))]
        public async Task<UserSignInResponse> SignIn([FromBody] UserSignInRequest request)
        {
            //Assembly asm = Assembly.GetExecutingAssembly();
            //var controlleractionlist = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
            // .SelectMany(type => type.GetMethods())
            // .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));

            //var controlleractionlistforAll = asm.GetTypes()
            //.Where(type => typeof(Controller).IsAssignableFrom(type))
            //.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            //.Where(method => !method.IsDefined(typeof(NonActionAttribute)))
            //.Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            //.Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            //.OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            //var privilegeRequest = new List<PrivilegeRequest>();

            //var controller = string.Empty;

            //foreach (var controllerAndAction in controlleractionlistforAll)
            //{
            //    await _privilegeService.Create(new PrivilegeRequest
            //    {
            //        Action = $"{controllerAndAction.Controller.Replace("Controller", "")}-{controllerAndAction.Action}",
            //        Description = $"{controllerAndAction.Controller.Replace("Controller", "")}-{controllerAndAction.Action}",
            //    });
            //}

            return await _accountService.SignIn(request);
        }


        //[AllowAnonymous]
        //[HttpGet(nameof(IsSessionAlive))]
        //public bool IsSessionAlive(string token)
        //{
        //    return _authorizationService.IsAuthenticated(token);
        //}
        [AllowAnonymous]
        [HttpPost(nameof(SignOut))]
        public async Task<OperationStatusResponse> SignOut([FromBody] UserSignOutRequest request)
        {
            return await _accountService.SignOut(request);
        }
        [AllowAnonymous]
        [HttpPost(nameof(RefreshToken))]
        public async Task<UserSignInResponse> RefreshToken(string refreshToken)
        {
            return await _accountService.RefreshAccessToken(refreshToken);
        }
        [HttpGet(nameof(GetAll))]
        public ActionResult<UsersResponse> GetAll()
        {
            _logger.LogInfo(string.Format("AccountController GetAll"));

            return Ok(_userService.GetAll());
        }

        [HttpGet(nameof(GetAllSupervisors))]
        public ActionResult<UsersResponse> GetAllSupervisors()
        {

            return Ok(_userService.GetAllSupervisors());
        }

        [HttpGet(nameof(GetById))]
        public UserResponse GetById(long id)
        {
            return _userService.GetById(id);
        }


        [HttpGet(nameof(GetByUserName))]
        public async Task<UserResponse> GetByUserName(string userName)
        {
            return await _accountService.GetByUserName(userName);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Save))]
        public async Task<UserResponse> Save([FromBody] NewUserRequest request)
        {
            return await _userService.Save(request);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Update))]
        public async Task<UserResponse> Update([FromBody] UpdateUserRequest request)
        {
            return await _userService.Update(request);
        }

        [HttpPost(nameof(Delete))]
        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            return await _userService.Delete(bulkAction);
        }

        [HttpPost(nameof(AccountLocking))]
        public OperationStatusResponse AccountLocking(AccountLocking accountLocking)
        {
            return _accountService.AccountLocking(accountLocking);
        }


        [HttpPost(nameof(ForgotPassword))]
        public async Task<OperationStatusResponse> ForgotPassword(ForgotPasswordRequest forwardPasswordRequest)
        {
            return await _accountService.ForgotPassword(forwardPasswordRequest);
        }

        [HttpPost(nameof(ResetPassword))]
        public async Task<OperationStatusResponse> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            return await _accountService.ResetPassword(resetPasswordRequest);
        }

        [HttpPost(nameof(ResetForgotedPassword))]
        public async Task<OperationStatusResponse> ResetForgotedPassword(ResetPasswordRequest resetPasswordRequest)
        {
            return await _accountService.ResetForgotPassword(resetPasswordRequest);
        }
        [HttpPost(nameof(UpdateStatus))]
        public async Task<OperationStatusResponse> UpdateStatus(BulkAction bulkAction)
        {
            return await _userService.UpdateStatus(bulkAction);
        }

        [HttpGet(nameof(GetPrivileges))]
        public PrivilegesResponse GetPrivileges(string username)
        {
            return _accountService.GetPrivilages(username);
        }
    }
}