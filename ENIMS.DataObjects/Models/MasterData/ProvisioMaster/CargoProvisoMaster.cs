using CargoProrationMicroservice.Models.DBModels.Master.LocationMaster;
using CargoProrationMicroservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CargoProrationMicroservice.Models.DBModels.Master.ProvisioMaster
{
    public class CargoProvisoMaster
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("CarrierMaster"), Required]
        public long CarrierCode { get; set; }
        [Required, Display(Name = "Effective From")]
        public DateTime EffectiveFromDate { get; set; }
        [Required, Display(Name = "Effective To")]
        public DateTime EffectiveToDate { get; set; }
        [Display(Name = "Proviso Number")]
        public int ProvisoNumber { get; set; }
        [StringLength(10)]
        public string Reference { get; set; }
        [Display(Name = "Priority Level")]
        public int PriorityLevel { get; set; }
        [Display(Name = "Old Priority")]
        public int OldPriority { get; set; }
        public ProvisoorRequirment ProvisoorRequirment { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }
        [Display(Name = "Seq.No.")]
        public int SequenceNumber { get; set; }
        [Required, Display(Name = "Area From")]
        public long FromCode { get; set; }
        [Required,Display(Name ="Area Type")]
        public AreaType FromAreaType { get; set; }
        [Required, Display(Name = "Area Type")]
        public AreaType ToAreaType { get; set; }
        [Required, Display(Name = "Area to")]
        public long ToCode { get; set; }
        public virtual CarrierMaster CarrierMaster { get; set; }
    }
}
