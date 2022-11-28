using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.DataObjects
{
	public interface IAppDbTransactionContext
	{
		ApplicationDbContext GetDbContext();
	}
}
