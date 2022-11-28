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
    public class ProvisioSectorExceptions
    {
        [Key]
        public long Id { get; set; }
        public ProvisioAreaType AreaType { get; set; }
        public double? RatePCTOption { get; set; }
        [Required, ForeignKey("CargoProvisoMaster")]
        public long ProvisioId { get; set; }
        [ForeignKey("Currency")]
        public long? CurrencyCode { get; set; }
        [Display(Name = "Area Type")]
        public AreaType? AreaFrom { get; set; }
        [Display(Name = "Area Type")]
        public AreaType? AreaTo { get; set; }
        public long? FromCode { get; set; }
        public long? ToCode { get; set; }
        public bool IsApplicable { get; set; }
        public virtual CargoProvisoMaster CargoProvisoMaster { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
