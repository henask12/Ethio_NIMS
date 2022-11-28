using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;

namespace ENIMS.Core
{
    public interface ITokenProvider
    {
        string Generate(DateTime expiryDate, string secrate, ClaimsIdentity claim);
        SecurityToken Dycrypt(string token, string secrate);
    }
}
