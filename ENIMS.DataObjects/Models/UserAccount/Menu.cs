using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ENIMS.DataObjects
{
    public class Menu : AuditLog
    {

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        [ForeignKey("ParentMenuId")]
        public long? ParentId { get; set; }
        public string Privilages { get; set; }
        public virtual Menu ParentMenuId { get; set; }
    }
}
