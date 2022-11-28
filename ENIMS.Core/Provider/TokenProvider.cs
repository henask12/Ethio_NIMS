using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ENIMS.Core
{
    public class TokenProvider : ITokenProvider
    {
        public SecurityToken Dycrypt(string token, string secrate)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secrate);
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken securityToken = null;
            try
            {
                var claims = handler.ValidateToken(token, validations, out securityToken);
            }
            catch (Exception)
            {
            }
            return securityToken;
        }

        public string Generate(DateTime expiryDate, string secrate, ClaimsIdentity claim)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secrate);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claim,
                Expires = expiryDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var value1 = Dycrypt(tokenHandler.WriteToken(token), secrate);

            return tokenHandler.WriteToken(token);
        }
    }
}
