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
   
    public class CargoProvisoAreaDetail
    {
        [Key]
        public long Id { get; set; }       
        [Display(Name ="Seq.No.")]
        public int SequenceNumber { get; set; }
        [Display(Name = "Proviso Area Type")]
        public ProvisioAreaType AreaType { get; set; }
        [Required]
        [Display(Name = "Area Type")]
        public AreaType FromAreaType { get; set; }
        [Display(Name = "Area From")]
        public long FromCode { get; set; }
        [Required]
        [Display(Name = "Area Type")]
        public AreaType ToAreaType { get; set; }
        [Display(Name = "Area To")]
        public long ToCode { get; set; }

        [ForeignKey("CargoProvisoMaster")]
        public long ProvisioId { get; set; }
        public virtual CargoProvisoMaster CargoProvisoMaster { get; set; }
    }
}
