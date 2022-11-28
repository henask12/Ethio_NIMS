using ENIMS.Common.ResponseModel;
using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;

namespace ENIMS.Common
{
    public class UserSignInResponse : OperationStatusResponse
	{
        public long Id { get; set; }
        public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ExpiryTime { get; set; }

        public bool IsDefaultOrganizationCreated { get; set; }
        public bool IsOldUser { get; set; }
        
        //
        public long UserId { get; set; }
        public List<UserRolesRes> UserRoles { get; set; }
        public long AccountSubscriptionId { get; set; }
        public long? CountryId { get; set; }
        public string CompanyName { get; set; }
        public SupplierDTO Supplier { get; set; }
        public PersonDTO Person { get; set; }
    }
}
