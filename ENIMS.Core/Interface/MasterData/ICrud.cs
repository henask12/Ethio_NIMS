using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.MasterData
{
    public interface ICrud<Response, Responses, Request>
    {
        Task<OperationStatusResponse> Delete(long id);
        Responses GetAll();
        Response GetById(long id);
        Task<Response> Create(Request request);
        Task<Response> Update(Request request);
    }
}



