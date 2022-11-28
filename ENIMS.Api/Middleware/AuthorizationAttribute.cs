using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using ENIMS.Common;
using ENIMS.Core;
using Microsoft.Extensions.Options;

namespace ENIMS.Api
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly AppSettings _appSettings;
        private readonly IAuthorizationService _authorizationService;
        private IHttpContextAccessor _httpContextAccessor;
        public AuthorizationAttribute(IOptions<AppSettings> appSettings,
            IAuthorizationService authorizationService, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;

            _authorizationService = authorizationService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null && context?.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                string actionController = String.Format("{0}-{1}", descriptor.ControllerName, descriptor.ActionName);
                var applicationType = context.HttpContext.Request.Headers["ApplicationType"].ToString();

                if (!string.IsNullOrEmpty(applicationType))
                    _httpContextAccessor.HttpContext.Session.SetString("ApplicationType", applicationType);


                if (!AllowAnonymous.Contains(actionController))
                {
                    var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

                    var actionPrivilegies = context.HttpContext.Request.Headers["ActionPrivilegies"].ToString();

                    if (!string.IsNullOrEmpty(authHeader))
                    {
                        var token = authHeader.Replace("Bearer ", "");
                        var claims = _authorizationService.GetClaim(token);

                        if (claims != null && claims.Count() > 0)
                        {
                            var username = claims.Where(u => u.Type == Keys.JWT_CURRENT_USER_CLAIM).FirstOrDefault();

                            if (username != null)
                            {                                
                                _httpContextAccessor.HttpContext.Session.SetString("UserName", username.Value);
                                _httpContextAccessor.HttpContext.Session.SetString("CurrentUsername", username.Value);

                                var isAuthenticated = _authorizationService.IsAuthenticated(token);

                                if (isAuthenticated == true)
                                {
                                    //if (!(String.IsNullOrEmpty(actionPrivilegies)))
                                    //{
                                    //    var isAuthorized = _authorizationService.IsAuthorized(_httpContextAccessor.HttpContext.Session.GetString("UserName"), actionController);

                                    //    if (isAuthorized.Status != OperationStatus.SUCCESS)
                                    //        context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);

                                    //}
                                    //else 
                                    
                                    if (!AllowAnonymousValidToken.Contains(actionController))
                                    {
                                        var isAuthorized = _authorizationService.IsAuthorized(_httpContextAccessor.HttpContext.Session.GetString("UserName"), actionController);

                                        if (isAuthorized.Status != OperationStatus.SUCCESS)
                                            context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);
                                    }
                                }
                                else
                                    context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);
                            }
                        }
                        else
                            context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);
                    }
                    else
                        context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);
                }
            }
            else
                context.Result = new CustomUnauthorizedResult(Resources.UnautorizedAccess);
        }

        private readonly List<string> AllowAnonymous = new List<string>
        {
            "Subscription-SignUp",
            "Subscription-ConfirmEmail",
            "Password-ForgotPassword",
            "Account-SignIn",
            "Account-ResetForgotedPassword",
            "Account-ForgotPassword",
            "Account-GetPrivileges",
            "Menu-GetAll",
            "ResetForgotPassword",
            "VerifyRecoveryToken",
            "Payment-PaymentApproved",
            "Request-PrintRequestReport",
            "Requests-FilterRequests",
            "Requests-FilterNewRequests",
            "Requests-FilterNewRequests",
            "Requests-FilterAllRequests",
            "Streaming-SeedCreateSuperUserDatabase",
            "Streaming-SeedAllPrivilagesDatabase",
            "Password-ForgotPassword",
            "Password-ResetForgotPassword",
            "Account-ConfirmUser",
            "Account-SignIn",
            "Account-Save",
            "Supplier-Create",
            "Project-GetOpenBids",
            "Country-GetAll",
            "VendorType-GetAll",
            "SupplyBusinessCategoryType-GetAll",
            "SupplyBusinessCategory-GetAll",
            "Account-RegisterSupplier",
            "Supplier-Register",
            "Streaming-SeedCreateSuperUserDatabase",
            "Streaming-SeedAllPrivilagesDatabase",
            "Approval-GetApprovers",
            "Approval-UpdateApprovalStatus"
        };

        private readonly List<string> AllowAnonymousValidToken = new List<string>
        {
            "RefreshToken","Account-IsSessionAlive"
        };
    }
    public class CustomUnauthorizedResult : JsonResult
    {
        public CustomUnauthorizedResult(string message) : base(new ErrorDetails(message))
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}
