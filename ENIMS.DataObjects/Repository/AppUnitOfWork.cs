using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.DataObjects
{
	public class AppUnitOfWork : IAppUnitOfWork
	{
		public ApplicationDbContext Context { get; }
		public AppUnitOfWork(ApplicationDbContext context)
		{
			Context = context;
		}
		public async Task<long> SaveChangesAsync()
		{
				return await Context.SaveChangesAsync();
		}
		public void Dispose()
		{
			Context.Dispose();
		}
		public IDatabaseTransaction BeginTrainsaction()
		{
			return new AppDatabaseTransaction(Context);
		}
        public long SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
