using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class AccountInformationResponse :OperationStatusResponse
    {
        public AccountInformation Response { get; set; }
        public AccountInformationResponse()
        {
            Response = new AccountInformation();
        }
    }
    public class AccountInformation
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactPerson { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

