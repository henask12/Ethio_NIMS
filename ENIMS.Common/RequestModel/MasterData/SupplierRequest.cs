using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class SupplierRequest
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        //public string ContactTelNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public long CountryId { get; set; }  // Foreign key for Country
        public string City { get; set; }
        public string Address { get; set; }
        public  List<long> SupplyBusinessCategoryIds { get; set; }//Foreign key for Supply Busines sCategory
        public string SupplyCategoryDescription { get; set; }//Foreign key for Supply Busines sCategory
        public long? VendorTypeId { get; set; }//Foreign key for Type of Vendor
        public int? StarType { get; set; }
        public string Remark { get; set; }
    }
    public class SupplierRequests
    {
        public List<SupplierRequest> Requests { get; set; }     

    }
}
