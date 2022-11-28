using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class SupplierRegistrationRequest
    {
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactTelNumber { get; set; }
        public string ContactPerson { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public List<long> SupplyBusinessCategoryIds { get; set; }
        public string SupplyCategoryDescription { get; set; }
        public long? VendorTypeId { get; set; }
        public int? StarType { get; set; }
        public string Remark { get; set; }
        public SupplierUserRequest User { get; set; }        
    }

    public class SupplierUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long Person { get; set; }
        public List<UserRoleRequest> UserRole { get; set; }
    }
}
