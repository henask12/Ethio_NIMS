using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public class PasswordService : IPasswordService
    {
        private readonly IServiceUtility _serviceUtility;
        private readonly IRepositoryBase<EmailTemplate> _emailTemplate;
        private readonly IRepositoryBase<User> _user;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepositoryBase<PasswordRecovery> _passwordRecovery;
        private readonly IAppUnitOfWork _appUnitOfWork;
        private readonly ITokenProvider _tokenProvider;
        private readonly IEmailSender _emailSender;
        private readonly AppSettings _appSettings;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
 

        public PasswordService(IOptions<AppSettings> appSettings,
            IRepositoryBase<User> user,
            IRepositoryBase<PasswordRecovery> passwordRecovery,
            IServiceUtility serviceUtility,
            ITokenProvider tokenProvider,
            IPasswordHasher<User> passwordHasher,
            IEmailSender emailSender, IHttpContextAccessor httpContextAccessor,
            IRepositoryBase<EmailTemplate> emailTemplate,
            IAppUnitOfWork appUnitOfWork,
            IAppDbTransactionContext appTransaction, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _user = user;
            _serviceUtility = serviceUtility;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
            _emailSender = emailSender;
            _emailTemplate = emailTemplate;
            _passwordRecovery = passwordRecovery;
            _appUnitOfWork = appUnitOfWork;
            _appTransaction = appTransaction;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<OperationStatusResponse> ChangePassword(ChangePasswordRequest request)
        {
            var userAccount = await _user.FirstOrDefaultAsync(u => u.Email == request.Username);
            if (userAccount != null)
            {
                if (!userAccount.IsAccountLocked)
                {
                    PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(userAccount, userAccount.Password, request.OldPassword);

                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        userAccount.Password = _passwordHasher.HashPassword(userAccount, request.NewPassword);
                        userAccount.LastUpdateDate = DateTime.UtcNow;
                        userAccount.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                        userAccount.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                        _user.Update(userAccount);
                        return new OperationStatusResponse { Status = OperationStatus.SUCCESS, Message = Resources.PasswordSucessfullyChanged };
                    }
                    else
                        return new OperationStatusResponse
                        {
                            Message = Resources.InvalidUsernameOrPassword,
                            Status = OperationStatus.SUCCESS
                        };
                }
                return new OperationStatusResponse
                {
                    Message = Resources.UserAccountIsLocked,
                    Status = OperationStatus.SUCCESS
                };
            }
            else
                return new OperationStatusResponse
                {
                    Message = Resources.UserAccountDoesNotExist,
                    Status = OperationStatus.SUCCESS
                };
        }

        public async Task<OperationStatusResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            //check if account already exist
            var userAccount = await _user.FirstOrDefaultAsync(u => u.Email == request.Username);
            if (userAccount != null)
            {
                //check user account is active
                if (userAccount.RecordStatus == RecordStatus.Active)
                {
                    //create new entry and send email 

                    var claim = new ClaimsIdentity(new Claim[]
                                {
                                        new Claim(Keys.JWT_CURRENT_USER_CLAIM,request.Username)
                                });

                    var recoverPassword = new PasswordRecovery
                    {
                        AccountSubscriptionUserId = userAccount.Id,
                        IsPasswordRecovered = false,
                        RecoveredOn = DateTime.MinValue,
                        RequestedOn = DateTime.UtcNow,
                        TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                        StartDate = DateTime.UtcNow,
                        LastUpdateDate = DateTime.UtcNow,
                        RecordStatus = RecordStatus.Active,
                        EndDate = DateTime.MaxValue,
                        VerificationToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(24), _appSettings.RecoverPasswordSecret, claim)
                    };

                    var result = _passwordRecovery.Add(recoverPassword);
                    if (/*await _appUnitOfWork.SaveChangesAsync() > 0*/result)
                    {
                        //send email
                        var sigUpEmailTemplate = await _emailTemplate.FirstOrDefaultAsync(e => e.TemplateType == EmailTemplateType.RecoverPassword);
                        if (sigUpEmailTemplate != null)
                        {
                            string Message = sigUpEmailTemplate.Template;
                            Message = Message.Replace("{{url}}", Keys.RECOVER_PASSWORD_URL);
                            Message = Message.Replace("{{fullname}}", string.Format("{0} {1}", userAccount.FirstName, userAccount.LastName));
                            Message = Message.Replace("{{activation_token}}", recoverPassword.VerificationToken);

                            await _emailSender.SendEmailAsync(Message, sigUpEmailTemplate.Subject, new string[] { request.Username }, null, null);
                        }
                        return new OperationStatusResponse { Status = OperationStatus.SUCCESS, Message = Resources.OperationSucessfullyCompleted };
                    }
                    else
                        return new OperationStatusResponse { Status = OperationStatus.ERROR, Message = Resources.OperationEndWithError };
                }
                else
                {
                    return new OperationStatusResponse { Status = OperationStatus.ERROR, Message = Resources.UserAccountIsLocked };
                }
            }
            else
                return new OperationStatusResponse { Status = OperationStatus.ERROR, Message = Resources.UserAccountDoesNotExist };
        }
        public async Task<RecoverPasswordResponse> ResetForgotPassword(ResetForgotPasswordRequest request)
        {
            var tokenVerification = await VerifyRecoveryToken(request.Token);
            if (tokenVerification.Status == OperationStatus.SUCCESS)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext(_configuration);

                using (var appUow = new AppUnitOfWork(dbContext))
                {
                    RepositoryBase<User> accSubscriptionUser = new RepositoryBase<User>(_configuration);
                    RepositoryBase<PasswordRecovery> passwordRecovery = new RepositoryBase<PasswordRecovery>(_configuration);

                    using (var transaction = appUow.BeginTrainsaction())
                    {
                        try
                        {
                            var recoverPasswordInfo = await passwordRecovery.FirstOrDefaultAsync(r => r.VerificationToken == request.Token);
                            if (recoverPasswordInfo?.IsPasswordRecovered != null)
                            {
                                var userAccount = await accSubscriptionUser.FirstOrDefaultAsync(u => u.Id == recoverPasswordInfo.AccountSubscriptionUserId);

                                //update password recovery info
                                recoverPasswordInfo.IsPasswordRecovered = true;
                                recoverPasswordInfo.RecoveredOn = DateTime.UtcNow;
                                recoverPasswordInfo.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                passwordRecovery.Update(recoverPasswordInfo);
                                await appUow.SaveChangesAsync();

                                //update password
                                userAccount.Password = _passwordHasher.HashPassword(userAccount, request.Password);
                                userAccount.LastUpdateDate = DateTime.UtcNow;
                                accSubscriptionUser.Update(userAccount);
                                await appUow.SaveChangesAsync();

                                transaction.Commit();

                                return new RecoverPasswordResponse
                                {
                                    Message = Resources.OperationSucessfullyCompleted,
                                    Status = OperationStatus.SUCCESS,
                                    Username = userAccount.Email
                                };
                            }
                            else
                            {
                                return new RecoverPasswordResponse
                                {
                                    Message = Resources.InvalidPasswordRecoveryToken,
                                    Status = OperationStatus.ERROR
                                };
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return new RecoverPasswordResponse
                            {
                                Message = Resources.DatabaseOperationFailed,
                                Status = OperationStatus.ERROR,
                            };
                        }
                    }

                }
            }
            else
                return tokenVerification;
        }

        public async Task<OperationStatusResponse> ResetPassword(ResetPasswordRequest request)
        {
            var userAccount = await _user.FirstOrDefaultAsync(u => u.Email == request.Username);
            if (userAccount != null)
            {
                userAccount.Password = _passwordHasher.HashPassword(userAccount, request.NewPassword);
                userAccount.LastUpdateDate = DateTime.UtcNow;
                userAccount.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                _user.Update(userAccount);
                return new OperationStatusResponse { Status = OperationStatus.SUCCESS, Message = Resources.PasswordSucessfullyChanged };
            }
            else
                return new OperationStatusResponse { Status = OperationStatus.ERROR, Message = Resources.UserAccountDoesNotExist };
        }

        public async Task<RecoverPasswordResponse> VerifyRecoveryToken(string token)
        {
            var passwordRecovery = await _passwordRecovery.FirstOrDefaultAsync(r => r.VerificationToken == token);
            if (passwordRecovery?.IsPasswordRecovered != null)
            {
                var securityToken = _tokenProvider.Dycrypt(token, _appSettings.RecoverPasswordSecret);
                if (securityToken != null && securityToken.ValidTo != DateTime.MinValue && securityToken.ValidTo > DateTime.UtcNow)
                {
                    var userAccount = await _user.FirstOrDefaultAsync(u => u.Id == passwordRecovery.AccountSubscriptionUserId);

                    return new RecoverPasswordResponse
                    {
                        Message = Resources.YourEmailAddressIsSucessfullyConfirmed,
                        Status = OperationStatus.SUCCESS,
                        Username = userAccount.Email
                    };
                }
                else
                {
                    return new RecoverPasswordResponse
                    {
                        Message = Resources.InvalidConfirmationToken,
                        Status = OperationStatus.ERROR
                    };
                }
            }
            else
            {
                return new RecoverPasswordResponse
                {
                    Message = Resources.InvalidClientCredential,
                    Status = OperationStatus.ERROR
                };
            }
        }
    }
}
