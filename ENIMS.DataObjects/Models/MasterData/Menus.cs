using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.DataObjects.Models.MasterData
{
    public class Menus : AuditLog
    {

        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        [ForeignKey("ParentMenuId")]
        public long? ParentId { get; set; }
        public string Privilages { get; set; }
        public virtual Menus ParentMenuId { get; set; }

    }
}
