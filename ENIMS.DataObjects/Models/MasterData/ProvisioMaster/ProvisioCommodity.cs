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
    public class ProvisioCommodity
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("ProvisioMaster"),Required]
        public long ProvisioId { get; set; }
        [Display(Name = "IATA/Own"),Required]
        public IATAorOWN IATAorOWN { get; set; }
        [ForeignKey("CommodityMaster"),Required]
        public long CommodityCode { get; set; }
        [ForeignKey("Currency"), Display(Name = "Currency Code")]
        public long? CurrencyCode { get; set; }
        public double? RatePCTOption { get; set; }
        [Required, Display(Name = "Appl.")]
        public bool IsApplicable { get; set; }
        public virtual CargoProvisoMaster ProvisioMaster { get; set; }
        public virtual CommodityMaster CommodityMaster { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
