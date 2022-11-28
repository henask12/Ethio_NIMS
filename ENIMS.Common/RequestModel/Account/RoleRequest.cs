using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class RoleRequest
    {
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public List<long> Privileges { get; set; }
	}
}
