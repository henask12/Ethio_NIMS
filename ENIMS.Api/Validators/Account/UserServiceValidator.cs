using FluentValidation;
using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Api
{
    //public class InviteUserValidator : AbstractValidator<InviteUserRequest>
    //{
    //    public InviteUserValidator()
    //    {
    //        RuleFor(x => x.Email).EmailAddress();
    //        RuleFor(x => x.FirstName).MinimumLength(1).MaximumLength(20).NotEmpty().NotEmpty().Matches(@"^[a-zA-Z\s\/]+$");//letters only;
    //        RuleFor(x => x.LastName).MinimumLength(1).MaximumLength(20).NotEmpty().NotEmpty().Matches(@"^[a-zA-Z\s\/]+$");//letters only;
    //        RuleFor(x => x.RoleId).NotNull().NotEmpty().GreaterThan(0); //number greater than 0 only
    //    }
    //}

    //public class InviteUserConfimationValidator : AbstractValidator<InviteUserConfimationRequest>
    //{
    //    public InviteUserConfimationValidator()
    //    {
    //        RuleFor(x => x.Password).PasswordRegx(); //At least 8 characters long 2 letters 2 digits 1 Upper case 1 Lower case 1 Symbol 
    //        RuleFor(x => x.Token).NotNull().NotEmpty().MinimumLength(1);//Token
    //    }
    //}
}
