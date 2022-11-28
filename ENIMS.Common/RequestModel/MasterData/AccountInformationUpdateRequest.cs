using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class UserInformationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class CompanyInformationRequest
    {
        public string CompanyName { get; set; }
        public string SupplyCategoryDescription { get; set; }
        public long VendorTypeId { get; set; }
        public int StarType { get; set; }
        public List<long> SupplyBusinessCategoryIds { get; set; }
        public string  Remark  { get; set; }
    }
    public class AddressInformationRequest
    {
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public long CountryId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
