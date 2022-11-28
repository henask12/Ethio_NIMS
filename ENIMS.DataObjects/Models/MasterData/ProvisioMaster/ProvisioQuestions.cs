using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CargoProrationMicroservice.Models.DBModels.Master.ProvisioMaster
{
    public class ProvisioQuestions
    {
        [Key]
        public long Id { get; set; }       
        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; }
        [Display(Name ="Appl.")]
        public bool IsApplicable { get; set; }
        [ForeignKey("CargoProvisoMaster"),Required]
        public long ProvisioId { get; set; }
        public virtual CargoProvisoMaster CargoProvisoMaster { get; set; }
    }
}
