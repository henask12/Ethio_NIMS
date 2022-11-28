using ENIMS.Common;
using System.Collections.Generic;
using System.Security.Claims;

namespace ENIMS.Core
{
    public interface IAuthorizationService
    {
        OperationStatusResponse IsAuthorized(string username, string action);
        bool IsAuthenticated(string token);
        IEnumerable<Claim> GetClaim(string token);
    }
}
