using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ENIMS.Common
{
    public class DycryptResponse
    {
        public SecurityToken  SecurityToken { get; set; } 
        public IEnumerable<Claim>  Claims { get; set; } 
    }
}
