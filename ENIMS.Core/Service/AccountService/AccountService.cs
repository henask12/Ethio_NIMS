using AutoMapper;
using ENIMS.Common;
using ENIMS.Common.ResponseModel;
using ENIMS.Common.ResponseModel.MasterData;
using ENIMS.DataObjects;
using ENIMS.DataObjects.Models.MasterData;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ENIMS.Core
{
    public class AccountService : IAccountService
    {
        private readonly IAppUnitOfWork _appUow;
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<Privilege> _privilegeRepository;
        private readonly IRepositoryBase<UserRole> _userRoleRepository;
        private readonly IRepositoryBase<RolePrivilege> _rolePrivilegeRepository;
        private readonly IRepositoryBase<UserToken> _userTokenRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailService;
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountService(IOptions<AppSettings> appSettings, IAppUnitOfWork uow,
            IRepositoryBase<User> userRepository,
            IRepositoryBase<UserRole> userRoleRepository,
            IRepositoryBase<UserToken> userTokenRepository,
            IAppDbTransactionContext appTransaction,
            ITokenProvider tokenProvider,
            IPasswordHasher<User> passwordHasher,
            IRepositoryBase<RolePrivilege> rolePrivilegeRepository,
            IRepositoryBase<Privilege> privilegeRepository, IEmailSender emailService,
            IConfiguration configuration, IMapper mapper, IUserRoleService userRoleService, IHttpContextAccessor httpContextAccessor)
        {
            _tokenProvider = tokenProvider;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _appUow = uow;
            _appTransaction = appTransaction;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _userRoleRepository = userRoleRepository;
            _rolePrivilegeRepository = rolePrivilegeRepository;
            _privilegeRepository = privilegeRepository;
            _mapper = mapper;
            _emailService = emailService;
            _userRoleService = userRoleService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserResponse> GetByUserName(string userName)
        {
            //var user = await _userRepository.Where(u => u.Username == userName).ToListAsync();

            //if (user != null)
            //{
            //    var userResponse = new UserResponse();

            //    var userRolesResponse = null;

            //    var userDetail = new UserRes
            //    {

            //    };

            //    userResponse.Status = OperationStatus.SUCCESS;
            //    userResponse.Message = Resources.OperationSucessfullyCompleted;

            //    var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id, new string[] { nameof(Role) }).ToList();

            //    if (userRoles != null && userRoles.Count > 0)
            //        foreach (var userRole in userRoles)
            //            userDetail.Roles.Add(new UserRoleRes
            //            {
            //                Id = userRole.RoleId,
            //                Name = userRole.Role.Name
            //            });

            //    userResponse.User = userDetail;
            //    return userResponse;
            //}
            return new UserResponse { Status = OperationStatus.ERROR, Message = Resources.RecordDoesNotExist };
        }

        public async Task<UserSignInResponse> SignIn(UserSignInRequest request)
        {
            var userAccount = await _userRepository.Where(u => u.Username == request.Username).FirstOrDefaultAsync();

            if (userAccount != null)
            {
                int applicationType = 0;

                //if (userAccount.SupplierId != null)
                //    applicationType = 2;
                //else
                //{
                //    if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("ApplicationType")))
                //    {
                //        applicationType = int.Parse(_httpContextAccessor.HttpContext.Session.GetString("ApplicationType"));
                //    }
                //}

                //var abc = $"{userAccount.AccountType}";

                if (true)
                {
                    if (userAccount.RecordStatus == RecordStatus.Active)
                    {
                        PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(userAccount, userAccount.Password, request.Password);
                        if (verificationResult == PasswordVerificationResult.Success)
                            return await GetAccessToken(request.Username);
                        else
                            return new UserSignInResponse
                            {
                                Message = Resources.InvalidUsernameOrPassword,
                                Status = OperationStatus.ERROR
                            };
                    }
                    else
                        return new UserSignInResponse
                        {
                            Message = Resources.UserAccountIsLocked,
                            Status = OperationStatus.ERROR
                        };
                }
                else
                {
                    return new UserSignInResponse
                    {
                        Message = "Your account is not subscribed for this service. Please contact the system admin and check your account type.",
                        Status = OperationStatus.ERROR
                    };
                }
            }
            else
            {
                LogModel logmodel = new LogModel();
                logmodel.message = "SignIn Account not found";
                //logmodel.exception = ex;
                //logmodel.postmessage = searchRequest;
                logmodel.module = "Account";
                logmodel.logtype = Logtype.API;

                LogStatus logStatus = new LogStatus();
                logStatus.TrackTrace(logmodel);

                return new UserSignInResponse
                {
                    Message = Resources.UserAccountDoesNotExist,
                    Status = OperationStatus.ERROR
                };
            }
        }
        public async Task<UserSignInResponse> GetAccessToken(string userName)
        {
            try
            {
                var userAccount = await _userRepository.Where(u => u.Username == userName).FirstOrDefaultAsync();

                if (userAccount != null)
                {
                    //Get Role Information with Priveldge
                    var userRolesResponse = _userRoleService.GetByUserId(userAccount.Id);

                    var userResponse = new UserSignInResponse
                    {
                        FirstName = userAccount.FirstName,
                        UserId = userAccount.Id,
                        LastName = userAccount.LastName,
                        Username = userAccount.Username,
                        CompanyName = "",
                        UserRoles = userRolesResponse?.UserRoles,
                        Message = Resources.SucessfullyLogedIn,
                        Status = OperationStatus.SUCCESS
                    };

                    #region Generate TOKEN
                    var claims = new ClaimsIdentity(new Claim[]
                                {
                                  new Claim(Keys.JWT_CURRENT_USER_CLAIM, userAccount.Username),
                                    //new Claim(Keys.JWT_ACCOUNT_SUBSCRIPTION_CLAIM, subscriptionInfo.AccountSubscription.CompanyName)
                                });

                    userResponse.AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_TOKEN_EXPIRY_HOUR), _appSettings.Secret, claims);
                    userResponse.RefreshToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.REFRESH_TOKEN_EXPIRY_HOUR), _appSettings.Secret, claims);
                    userResponse.IssuedTime = DateTime.UtcNow;
                    userResponse.ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_TOKEN_EXPIRY_HOUR);

                    //Save token
                    var userAccessToken = new UserToken
                    {
                        UserId = userAccount.Id,
                        AccessToken = userResponse.AccessToken,
                        RefreshToken = userResponse.RefreshToken,
                        IssuedTime = DateTime.UtcNow,
                        ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_TOKEN_EXPIRY_HOUR)
                    };

                    _userTokenRepository.Add(userAccessToken);
                    #endregion

                    return userResponse;
                }
                else
                {
                    return new UserSignInResponse
                    {
                        Message = Resources.UserAccountDoesNotExist,
                        Status = OperationStatus.ERROR
                    };
                }
            }
            catch (Exception)
            {
                return new UserSignInResponse
                {
                    Message = Resources.OperationEndWithError,
                    Status = OperationStatus.ERROR
                };
            }
            return null;
        }
        public OperationStatusResponse AccountLocking(AccountLocking accountLocking)
        {
            var user = _userRepository.Where(u => u.Id == accountLocking.UserId).FirstOrDefault();
            if (user == null)
                return new OperationStatusResponse()
                {
                    Message = Resources.RecordDoesNotExist,
                    Status = OperationStatus.ERROR
                };


            user.RecordStatus = accountLocking.Status;
            var result = _userRepository.Update(user);
            if (result)
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
            else
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
        }
        public async Task<OperationStatusResponse> ResetForgotPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var user = _userRepository.Where(u => u.Username == resetPasswordRequest.Username).FirstOrDefault();

            if (user == null)
                return new OperationStatusResponse()
                {
                    Message = Resources.RecordDoesNotExist,
                    Status = OperationStatus.ERROR
                };


            user.Password = _passwordHasher.HashPassword(user, resetPasswordRequest.NewPassword);
            var result = _userRepository.Update(user);

            if (result)
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
            else
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
        }
        public async Task<OperationStatusResponse> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var user = _userRepository.Where(u => u.Username == resetPasswordRequest.Username).FirstOrDefault();

            if (user == null)
                return new OperationStatusResponse()
                {
                    Message = Resources.RecordDoesNotExist,
                    Status = OperationStatus.ERROR
                };

            user.Password = _passwordHasher.HashPassword(user, resetPasswordRequest.NewPassword);

            var result = _userRepository.Update(user);
            if (result)
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
            else
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.ErrorHasOccuredWhileProcessingYourRequest,
                    Status = OperationStatus.ERROR
                };
            }

        }
        public async Task<OperationStatusResponse> ForgotPassword(ForgotPasswordRequest forwardPasswordRequest)
        {
            try
            {
                var user = _userRepository.Where(u => u.Username == forwardPasswordRequest.Username).FirstOrDefault();
                if (user == null)
                    return new OperationStatusResponse()
                    {
                        Message = Resources.RecordDoesNotExist,
                        Status = OperationStatus.ERROR
                    };

                await _emailService.SendEmailAsync("<p>Please reset your password by clicking <a href=\"" + forwardPasswordRequest.CallBackUrl + "\">here</a></p>", "Reset Password", new string[] { user.Email }, null, null);

                return new OperationStatusResponse()
                {
                    Message = Resources.OperationSucessfullyCompleted,
                    Status = OperationStatus.SUCCESS
                };
            }
            catch (Exception)
            {
                return new OperationStatusResponse()
                {
                    Message = Resources.ErrorHasOccuredWhileProcessingYourRequest,
                    Status = OperationStatus.ERROR
                };
            }
        }
        public async Task<OperationStatusResponse> SignOut(UserSignOutRequest request)
        {
            var userToken = await _userTokenRepository.FirstOrDefaultAsync(t => t.RefreshToken == request.RefreshToken);
            if (userToken != null)
            {
                    if (_userTokenRepository.Remove(userToken))
                        return new OperationStatusResponse { Status = OperationStatus.SUCCESS, Message = Resources.OperationSucessfullyCompleted };
                    else
                        return new OperationStatusResponse { Status = OperationStatus.ERROR, Message = Resources.OperationEndWithError };
            }
            return new OperationStatusResponse
            {
                Message = Resources.UserAlreadyLoggedOut,
                Status = OperationStatus.SUCCESS
            };
        }
        public async Task<UserSignInResponse> RefreshAccessToken(string refreshToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadToken(refreshToken) as JwtSecurityToken;

                if (token != null && token.ValidTo != DateTime.MinValue && token.ValidTo > DateTime.UtcNow)
                {
                    var userTokenInfo = await _userTokenRepository.FirstOrDefaultAsync(t => t.RefreshToken == refreshToken, new string[] { nameof(User) });

                    if (userTokenInfo != null)
                    {
                        var userInfo = await _userRepository.FirstOrDefaultAsync(u => u.Username == userTokenInfo.User.Username);

                        if (userInfo != null)
                        {
                            if (userInfo.RecordStatus == RecordStatus.Active)
                            {
                                var claim = new ClaimsIdentity(new Claim[]
                                {
                                        new Claim(Keys.JWT_CURRENT_USER_CLAIM,userTokenInfo.User.Username)
                                });

                                return new UserSignInResponse
                                {
                                    Username = userTokenInfo.User.Username,
                                    FirstName = userTokenInfo.User.FirstName,
                                    LastName = userTokenInfo.User.LastName,
                                    AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_TOKEN_EXPIRY_HOUR), _appSettings.Secret, claim),
                                    RefreshToken = refreshToken,
                                    Message = Resources.SucessfullyLogedIn,
                                    Status = OperationStatus.SUCCESS
                                };
                            }
                            else
                            {
                                return new UserSignInResponse
                                {
                                    Message = Resources.UserAccountIsLocked,
                                    Status = OperationStatus.ERROR
                                };
                            }
                        }
                        else
                        {
                            return new UserSignInResponse
                            {
                                Message = Resources.UserAccountDoesNotExist,
                                Status = OperationStatus.ERROR
                            };
                        }

                    }
                    else
                    {
                        return new UserSignInResponse
                        {
                            Message = Resources.InvalidRefreshToken,
                            Status = OperationStatus.ERROR
                        };
                    }
                }
                else
                {
                    return new UserSignInResponse
                    {
                        Message = Resources.InvalidRefreshToken,
                        Status = OperationStatus.ERROR
                    };
                }
            }
            catch (Exception)
            {
                return new UserSignInResponse
                {
                    Message = Resources.BusinessErrorWhileProcessingYourRequest,
                    Status = OperationStatus.ERROR
                };
            }
        }
        public PrivilegesResponse GetPrivilages(string userName)
        {
            var user = _userRepository.Where(c => c.Username == userName).FirstOrDefault();
            PrivilegesResponse privilegesResponse = new PrivilegesResponse();
            if (user != null)
            {
                var roleIds = _userRoleRepository.Where(c => c.UserId == user.Id).Select(c => c.RoleId).ToList();
                if (roleIds.Count == 0)
                    return new PrivilegesResponse
                    {
                        Message = Resources.UserAccountDoesNotExist,
                        Status = OperationStatus.ERROR
                    };
                List<long> privilegeIds = _rolePrivilegeRepository.Where(c => roleIds.Contains(c.RoleId)).Select(c => c.PrivilegeId).ToList();
                var privileges = _privilegeRepository.Where(c => privilegeIds.Contains(c.Id)).ToList();
                foreach (var privilege in privileges)
                {
                    PrivilegeRes privilegeRes = new PrivilegeRes();
                    privilegeRes.Action = privilege.Action;
                    privilegeRes.Module = privilege.Module;
                    privilegeRes.Description = privilege.Description;
                    privilegesResponse.Privileges.Add(privilegeRes);
                }
                privilegesResponse.Status = OperationStatus.SUCCESS;
                privilegesResponse.Message = Resources.OperationSucessfullyCompleted;
                return privilegesResponse;
            }
            else
                return new PrivilegesResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };
        }
    }
}
