using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargoProrationAPI.DataObjects.Models.MasterData
{
    public class UserInformationResponse :OperationStatusResponse
    {
        public UserInformationRequest Response { get; set; }
        public UserInformationResponse()
        {
            Response = new UserInformationRequest();
        } 
    }
    public class CompanyInformationResponse : OperationStatusResponse
    {
        public CompanyInformationRequest Response { get; set; }
        public CompanyInformationResponse()
        {
            Response = new CompanyInformationRequest();
        } 
    }   
}
