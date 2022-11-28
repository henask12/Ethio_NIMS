using ENIMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Core.Interface.Helper
{
	public interface IBaseService<Request, Response, ResponseList>
	{
		Response GetById(long id);
		ResponseList GetAll();
		Task<Response> Create(Request request);
		Task<Response> Update(Request request);
		Task<OperationStatusResponse> Delete(long Id);
	}
}
