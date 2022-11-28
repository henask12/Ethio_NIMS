using FluentValidation;
using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Api.Validators.Account
{
    public class UserSigninValidator : AbstractValidator<UserSignInRequest>
    {
        public UserSigninValidator()
        {
            RuleFor(x => x.Username).EmailAddress();
            RuleFor(x => x.Password).PasswordRegx(); //At least 8 characters long 2 letters 2 digits 1 Upper case 1 Lower case 1 Symbol 
        }
    }

    public class UserSignOutValidator : AbstractValidator<UserSignOutRequest>
    {
        public UserSignOutValidator()
        {
            RuleFor(x => x.RefreshToken).NotNull().NotEmpty().MinimumLength(1);//Token
        }
    }
}
