using CargoProrationMicroservice.Models.DBModels.Master.CurrencyMaster;
using CargoProrationMicroservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace CargoProrationMicroservice.Models.DBModels.Master.ProvisioMaster
{
    public class ProvisioWeightBreaks
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int WgtBreackFrom { get; set; }
        [Required]
        public int WgtBreackTO { get; set; }
        [ForeignKey("Currency"),Display(Name ="Cur.")]
        public long? CurrencyCode { get; set; }
        public double? RatePCTOption { get; set; }
        [Display(Name = "Apl."),Required]
        public bool IsApplicable { get; set; }
        [ForeignKey("ProvisoMaster"),Display(Name ="Provisio")]
        public long ProvisioID { get; set; }
        public virtual CargoProvisoMaster ProvisoMaster { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
