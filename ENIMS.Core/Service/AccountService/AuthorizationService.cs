using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ENIMS.Core
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly AppSettings _appSettings;
        private readonly ITokenProvider _tokenProvider;
        private readonly IRepositoryBase<UserToken> _userTokenRepository;
        private readonly IHttpContextAccessor _context;
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<UserRole> _userRoleRepository;
        private readonly IRepositoryBase<Privilege> _privilegeRepository;
        private readonly IRepositoryBase<RolePrivilege> _rolePrivilegeRepository;

        public AuthorizationService(IOptions<AppSettings> appSettings,
                ITokenProvider tokenProvider,
                IRepositoryBase<UserToken> userTokenRepositor,
                IRepositoryBase<User> userRepository,
                IRepositoryBase<UserRole> userRoleRepository,
                IRepositoryBase<Privilege> privilageRepository,
                IRepositoryBase<RolePrivilege> rolePrivilegeRepository,
                IHttpContextAccessor context)
        {
            _appSettings = appSettings.Value;
            _tokenProvider = tokenProvider;
            _userTokenRepository = userTokenRepositor;
            _context = context;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _privilegeRepository = privilageRepository;
            _rolePrivilegeRepository = rolePrivilegeRepository;
        }


        public bool IsAuthenticated(string token)
        {
            var securityToken = _tokenProvider.Dycrypt(token, _appSettings.Secret);
            if (securityToken != null)
            {
                //check if token is not expired and was not cleard for logout
                if (securityToken != null && securityToken.ValidTo != DateTime.MinValue && securityToken.ValidTo > DateTime.UtcNow)
                {
                    return true;
                    var userTokenInfo = _userTokenRepository.FirstOrDefault(t => t.AccessToken == token, new string[] { nameof(User) });
                    if (userTokenInfo != null)
                        return true;
                }
            }
            return false;
        }

        public OperationStatusResponse IsAuthorized(string username, string action)
        {
            //var userSubscription =  _accountSubscriptionUser.FirstOrDefault(u => u.Email == username);
            var user = _userRepository.FirstOrDefaultAsync(u => u.Username == username).Result;
           
            if (user == null)
                return new OperationStatusResponse { Message = Resources.InvalidUsernameOrPassword, Status = OperationStatus.ERROR };
            else if (user.RecordStatus != RecordStatus.Active || user.IsAccountLocked)
                return new OperationStatusResponse { Message = Resources.AccountIsInactive, Status = OperationStatus.ERROR };
            else
            {
                if (user.IsSuperAdmin)
                    return new OperationStatusResponse { Message = Resources.UserIsAuthorized, Status = OperationStatus.SUCCESS };
                else
                {
                    var privilege = _privilegeRepository.FirstOrDefault(p => p.Action == action);

                    if (privilege == null)
                        return new OperationStatusResponse { Message = Resources.BadRequest, Status = OperationStatus.ERROR };

                    //get all roles which are assigned to the current user
                    var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id).ToList();
                    
                    if (userRoles.Count == 0)
                        return new OperationStatusResponse { Message = Resources.UnauthorizedAccess, Status = OperationStatus.ERROR };

                    foreach (var userRole in userRoles)
                    {
                        var rolePrivilege = _rolePrivilegeRepository.Where(rp => rp.PrivilegeId == privilege.Id && rp.RoleId == userRole.RoleId).FirstOrDefault();

                        if (rolePrivilege != null)
                            return new OperationStatusResponse { Message = Resources.UserIsAuthorized, Status = OperationStatus.SUCCESS };
                    }
                }
            }

            return new OperationStatusResponse { Message = Resources.UnauthorizedAccess, Status = OperationStatus.ERROR };
        }

        public IEnumerable<Claim> GetClaim(string token)
        {
            var securityToken = _tokenProvider.Dycrypt(token, _appSettings.Secret);
            if (securityToken != null)
            {
                var identity = _context.HttpContext.User.Identity as ClaimsIdentity;

                IEnumerable<Claim> claims = identity.Claims;
                return claims;
            }

            return null;
        }
    }
}
