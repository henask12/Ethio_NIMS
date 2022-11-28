using CargoProrationMicroservice.Models.DBModels.Master.CurrencyMaster;
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
    public class CargoProvisoInformations
    {
        [Key]
        public long Id { get; set; }  
        [ForeignKey("CargoProvisoMaster")]
        public long ProvisioId { get; set; }
        //proviso
        [Required,StringLength(1)]
        public string ProvisoRCL { get; set; }
        [Display(Name = "Share Flag")]
        public string ProvisoShareFlag { get; set; }
        [Required,ForeignKey("ProvisoCurr")]
        public long ProvisoCurrency { get; set; }
        [Required]
        public double ProvisoRatePCT { get; set; }
        [Required]
        public ProvisoApplWeight ApplWeight { get; set; }
        //value check
        public string ValueCheckRCL { get; set; }
        [Required, ForeignKey("ValueCheckCurr")]
        public long ValueCheckCurrency { get; set; }
        [Required]
        public double ValueCheckRatePCT { get; set; }
        [Required]
        public ProvisoMinMax MinMax { get; set; }
        public string Note { get; set; }
        public virtual CargoProvisoMaster CargoProvisoMaster { get; set; }
        public Currency ProvisoCurr { get; set; }
        public Currency ValueCheckCurr { get; set; }
    }
}
