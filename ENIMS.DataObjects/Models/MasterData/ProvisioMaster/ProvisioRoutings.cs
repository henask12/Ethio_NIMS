using CargoProrationMicroservice.Models.DBModels.Master.CurrencyMaster;
using CargoProrationMicroservice.Models.DBModels.Master.LocationMaster;
using CargoProrationMicroservice.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
namespace CargoProrationMicroservice.Models.DBModels.Master.ProvisioMaster
{
    public class ProvisioRoutings
    {
        [Key]
        public long Id { get; set; }  
        [ForeignKey("ProvisioMaster"),Required]
        public long ProvisioId { get; set; }
        [Required]
        public RoutingAreaType RoutingAreaType { get; set; }
        [ForeignKey("Currency"),Display(Name = "Currency Code")]
        public long? CurrencyCode { get; set; }
        public double? RatePCTOption { get; set; }
        [Required,Display(Name ="Appl.")]
        public bool IsApplicable { get; set; }
        [Display(Name ="Via Area"),ForeignKey("Area")]
        public AreaType ViaAreaType { get; set; }
        public long? ViaCode { get; set; }
        public AreaType RoutingAreaFromType { get; set; }
        public long? FromCode { get; set; }
        public AreaType RoutingAreaToType { get; set; }
        public long? ToCode { get; set; }
        [ForeignKey("Carrier"), Display(Name = "Carrier Code")]
        public long? CarrierCode { get; set; }
        public virtual CargoProvisoMaster ProvisioMaster { get; set; }
        public virtual CarrierMaster Carrier { get; set; }        
        public virtual Currency Currency { get; set; }
    }
}
