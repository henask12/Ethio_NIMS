using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public class UserTokenService : ITokenService<UserTokenService>
    {
        private readonly IRepositoryBase<User> _userRepository;
        private readonly IRepositoryBase<UserToken> _userTokenRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<User> _passwordHasher;


        public UserTokenService(IOptions<AppSettings> appSettings,
            IRepositoryBase<User> userRepository,
            IRepositoryBase<UserToken> userTokenRepository,
            IAppDbTransactionContext appTransaction,
            ITokenProvider tokenProvider,
             IPasswordHasher<User> passwordHasher)
        {
            _tokenProvider = tokenProvider;
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
            _userTokenRepository = userTokenRepository;
            _appTransaction = appTransaction;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserSignInResponse> GetAccessToken(string email)
        {
            var subscriptionInfo = await _userRepository.FirstOrDefaultAsync(u => u.Email == email && u.RecordStatus == RecordStatus.Active, new string[] { nameof(AccountSubscription) });
            if (subscriptionInfo != null)
            {
                var response = new UserSignInResponse
                {
                    FirstName = subscriptionInfo.FirstName,
                    LastName = subscriptionInfo.LastName,
                    Username = subscriptionInfo.Email,
                    UserId = subscriptionInfo.Id,
                    Status = OperationStatus.SUCCESS,
                    Message = Resources.OperationSucessfullyCompleted
                };

                var claims = new ClaimsIdentity(new Claim[]
                        {
                                        new Claim(Keys.JWT_CURRENT_USER_CLAIM, subscriptionInfo.Email)
                        });

                response.AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_USER_TOKEN_EXPIRY_HOUR), _appSettings.UserSecret, claims);
                response.RefreshToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.REFRESH_TOKEN_EXPIRY_HOUR), _appSettings.UserSecret, claims);

                //save token
                var userAccessToken = new UserToken
                {
                    UserId = subscriptionInfo.Id,
                    AccessToken = response.AccessToken,
                    RefreshToken = response.RefreshToken,
                    IssuedTime = DateTime.UtcNow,
                    ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_USER_TOKEN_EXPIRY_HOUR)
                };

                if (_userTokenRepository.Add(userAccessToken) == false)
                    return new UserSignInResponse { Message = Resources.DatabaseOperationFailed, Status = OperationStatus.ERROR };

                return response;
            }
            else
                return new UserSignInResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };

        }

        public async Task<UserSignInResponse> GetAccessToken(User user)
        {
            if (user != null && user?.Id > 0)
            {
                var response = new UserSignInResponse
                {
                    //CompanyName = user.AccountSubscription.CompanyName,                    
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                    Username = user.Email,
                    Status = OperationStatus.SUCCESS,
                    Message = Resources.OperationSucessfullyCompleted
                };

                var claims = new ClaimsIdentity(new Claim[]
                        {
                           new Claim(Keys.JWT_CURRENT_USER_CLAIM, user.Username)
                        });

                response.AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_USER_TOKEN_EXPIRY_HOUR), _appSettings.UserSecret, claims);
                response.RefreshToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.REFRESH_TOKEN_EXPIRY_HOUR), _appSettings.UserSecret, claims);

                //save token
                var userAccessToken = new UserToken
                {
                    UserId = user.Id,
                    AccessToken = response.AccessToken,
                    RefreshToken = response.RefreshToken,
                    IssuedTime = DateTime.UtcNow,
                    ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_USER_TOKEN_EXPIRY_HOUR)
                };

                if (_userTokenRepository.Add(userAccessToken) == false)
                    return new UserSignInResponse { Message = Resources.DatabaseOperationFailed, Status = OperationStatus.ERROR };

                return response;
            }
            else
                return new UserSignInResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };

        }

        public Task<UserSignInResponse> GetAccessToken(ClientUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSignInResponse> RefreshAccessToken(string refreshToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(refreshToken) as JwtSecurityToken;
            if (token != null && token.ValidTo != DateTime.MinValue && token.ValidTo > DateTime.UtcNow)
            {

                var userTokenInfo = await _userTokenRepository.FirstOrDefaultAsync(t => t.RefreshToken == refreshToken, new string[] { nameof(User) });
                if (userTokenInfo != null)
                {
                    var userInfo = await _userRepository.FirstOrDefaultAsync(u => u.Email == userTokenInfo.User.Username, new string[] { nameof(AccountSubscription) });
                    if (userInfo != null)
                    {
                        if (!userInfo.IsAccountLocked)
                        {
                            var claim = new ClaimsIdentity(new Claim[]
                            {
                                        new Claim(Keys.JWT_CURRENT_USER_CLAIM,userTokenInfo.User.Username)
                            });

                            return new UserSignInResponse
                            {
                                Username = userInfo.Username,
                                FirstName = userInfo.FirstName,
                                LastName = userInfo.LastName,
                                UserId = userInfo.Id,
                                //CompanyName = userInfo.AccountSubscription.CompanyName,
                                AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_USER_TOKEN_EXPIRY_HOUR), _appSettings.UserSecret, claim),
                                RefreshToken = refreshToken,
                                Message = Resources.SucessfullyLogedIn,
                                Status = OperationStatus.SUCCESS
                            };
                        }
                        else
                            return new UserSignInResponse { Message = Resources.UserAccountIsLocked, Status = OperationStatus.ERROR };
                    }
                    else
                        return new UserSignInResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };

                }
                else
                    return new UserSignInResponse { Message = Resources.InvalidRefreshToken, Status = OperationStatus.ERROR };
            }
            else
                return new UserSignInResponse { Message = Resources.InvalidRefreshToken, Status = OperationStatus.ERROR };

        }
    }
}
