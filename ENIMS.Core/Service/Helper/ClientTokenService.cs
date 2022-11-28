using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public class ClientTokenService : ITokenService<ClientTokenService>
    {
        private readonly IRepositoryBase<ClientUser> _userRepository;
        private readonly IRepositoryBase<ClientUserToken> _userTokenRepository;
        private readonly ITokenProvider _tokenProvider;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher<ClientUser> _passwordHasher;


        public ClientTokenService(IOptions<AppSettings> appSettings,
            IRepositoryBase<ClientUser> userRepository,
            IRepositoryBase<ClientUserToken> userTokenRepository,
            IAppDbTransactionContext appTransaction,
            ITokenProvider tokenProvider,
             IPasswordHasher<ClientUser> passwordHasher)
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
            var subscriptionInfo = await _userRepository.FirstOrDefaultAsync(u => u.Email == email);
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
                                        new Claim(Keys.JWT_CLIENT_CURRENT_USER_CLAIM, subscriptionInfo.Email),
                                            //new Claim(Keys.JWT_ACCOUNT_SUBSCRIPTION_CLAIM, subscriptionInfo.AccountSubscription.CompanyName)
                        });

                response.AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_CLIENT_TOKEN_EXPIRY_HOUR), _appSettings.ClientSecret, claims);
                response.RefreshToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.REFRESH_TOKEN_EXPIRY_HOUR), _appSettings.ClientSecret, claims);

                //save token
                var userAccessToken = new ClientUserToken
                {
                    UserId = subscriptionInfo.Id,
                    AccessToken = response.AccessToken,
                    RefreshToken = response.RefreshToken,
                    IssuedTime = DateTime.UtcNow,
                    ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_CLIENT_TOKEN_EXPIRY_HOUR)
                };

                if (_userTokenRepository.Add(userAccessToken) == false)
                    return new UserSignInResponse { Message = Resources.DatabaseOperationFailed, Status = OperationStatus.ERROR };

                return response;
            }
            else
                return new UserSignInResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };

        }

        public async Task<UserSignInResponse> GetAccessToken(ClientUser user)
        {
            if (user != null && user?.Id > 0)
            {
                var response = new UserSignInResponse
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = user.Id,
                    Username = user.Email,
                    Status = OperationStatus.SUCCESS,
                    Message = Resources.OperationSucessfullyCompleted
                };

                var claims = new ClaimsIdentity(new Claim[]
                        {
                                        new Claim(Keys.JWT_CLIENT_CURRENT_USER_CLAIM, user.Email),
                        });

                response.AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_CLIENT_TOKEN_EXPIRY_HOUR), _appSettings.ClientSecret, claims);
                response.RefreshToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.REFRESH_TOKEN_EXPIRY_HOUR), _appSettings.ClientSecret, claims);

                //save token
                var userAccessToken = new ClientUserToken
                {
                    UserId = user.Id,
                    AccessToken = response.AccessToken,
                    RefreshToken = response.RefreshToken,
                    IssuedTime = DateTime.UtcNow,
                    ExpiryTime = DateTime.UtcNow.AddHours(Keys.ACCESS_CLIENT_TOKEN_EXPIRY_HOUR)
                };

                if (_userTokenRepository.Add(userAccessToken) == false)
                    return new UserSignInResponse { Message = Resources.DatabaseOperationFailed, Status = OperationStatus.ERROR };

                return response;
            }
            else
                return new UserSignInResponse { Message = Resources.UserAccountDoesNotExist, Status = OperationStatus.ERROR };

        }

        public Task<UserSignInResponse> GetAccessToken(User user)
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
                                        new Claim(Keys.JWT_CLIENT_CURRENT_USER_CLAIM,userTokenInfo.User.Username)
                            });

                            return new UserSignInResponse
                            {
                                Username = userTokenInfo.User.Username,
                                FirstName = userInfo.FirstName,
                                LastName = userInfo.LastName,
                                UserId = userInfo.Id,
                                //CompanyName = userInfo.AccountSubscription.CompanyName,
                                AccessToken = _tokenProvider.Generate(DateTime.UtcNow.AddHours(Keys.ACCESS_CLIENT_TOKEN_EXPIRY_HOUR), _appSettings.ClientSecret, claim),
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
