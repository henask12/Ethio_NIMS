using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.MasterData
{
    public interface IBulkInsertion<Response, Request>
    {
        Task<Response> BulkInsertion(List<Request> request);
    }
}
