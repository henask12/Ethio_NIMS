using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class PrivilegeRequest 
	{
		public long Id { get; set; }


		[Required]
		public string Action { get; set; }
		public string Module { get; set; }
		public string Description { get; set; }
	}
}
