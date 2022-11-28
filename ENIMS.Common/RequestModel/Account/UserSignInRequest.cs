using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class UserSignInRequest
	{

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
