using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Api
{
	public static class RuleBuilderExtensions
	{
		public static IRuleBuilder<T, string> PasswordRegx<T>(this IRuleBuilder<T, string> ruleBuilder)
		{
			var options = ruleBuilder
						  .NotEmpty()
						  .NotNull()
						  .MinimumLength(8)
						  .MaximumLength(16)
						  .Matches(@"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$");
			return options;
		}
	}
}
