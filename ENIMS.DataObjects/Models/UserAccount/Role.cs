using System.ComponentModel.DataAnnotations;

namespace ENIMS.DataObjects
{
    public class Role : AuditLog
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
	}
}
