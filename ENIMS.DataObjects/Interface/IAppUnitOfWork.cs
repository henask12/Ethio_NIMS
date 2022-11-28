using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.DataObjects
{
	public interface IAppUnitOfWork : IDisposable
	{
		ApplicationDbContext Context { get; }
		Task<long> SaveChangesAsync();
		long SaveChanges();
		IDatabaseTransaction BeginTrainsaction();
	}
}
