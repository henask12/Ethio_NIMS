using ENIMS.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENIMS.DataObjects.Models.MasterData
{
    [Table(name:"MasterData_CostCenter")]
    public class CostCenter : AuditLog
    {
        [Key]
        public long? CountryId { get; set; }

        [Display(Name ="Station/Section/Division Name"), Required(ErrorMessage = "Station is required.")]
        public string Station { get; set; }

        [Display(Name ="Cost center"),Required(ErrorMessage ="Cost-center is required.")]
        public string CostCenterName { get; set; }
    }
}
