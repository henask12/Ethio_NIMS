using CargoProrationAPI.DataObjects.Models.MasterData;
using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.MasterData
{
    public interface ISupplier 
    {
        SuppliersResponse GetForInvitation();
        Task<UserSignInResponse> UpdateUserInformation(UserInformationRequest request);
        Task<UserSignInResponse> UpdateCompanyInformation(CompanyInformationRequest request);
        Task<UserSignInResponse> UpdateAddressInformation(AddressInformationRequest request);
    }
}
