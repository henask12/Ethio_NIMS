using ENIMS.Common;
using ENIMS.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENIMS.DataObjects.Models.MasterData
{
    [Table(name:"MasterData_Person")]
    public class Person: AuditLog
    {
        public long Id { get; set; }
        public string EmployeeId { get; set; }

        [Display(Name = "First Name"), Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name"), Required(ErrorMessage = "Middle name is required")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name"), Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "E-mail"), Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Display(Name = "Ext. Number"),Required(ErrorMessage = "Ext. Number is required")]
        public string ExtensionNumber { get; set; }

        [Display(Name ="Job title/Position")]
        public string Position { get; set; }

        [Display (Name ="Cost Ceneter"),Required(ErrorMessage ="Cost center is required.")]
        public long CostCenterId { get; set; }// Forign key for  costCenter

        public CostCenter CostCenter { get; set; }
    }
}
