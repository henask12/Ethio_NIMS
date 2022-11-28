using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common.ResponseModel
{
    public class SupplierResponse : OperationStatusResponse
    {
        public SupplierDTO Response { get; set; }
        public SupplierResponse()
        {
            Response = new SupplierDTO();
        }
    }
    public class SuppliersResponse : OperationStatusResponse
    {
        public List<SupplierDTO> Response { get; set; }
        public SuppliersResponse()
        {
            Response = new List<SupplierDTO>();
        }
    }
    public class SupplierDTO
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactTelNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }  
        public string City { get; set; }
        public string Address { get; set; }      
        public string SupplyCategoryDescription { get; set; }
        public string StarType { get; set; }
        public string Remark { get; set; }
        public VendorTypeDTO VendorType { get; set; }
        public CountryDTO Country { get; set; }
        public List<BusinessCategoryDTO> BusinessCategories { get; set; }
    }
}
