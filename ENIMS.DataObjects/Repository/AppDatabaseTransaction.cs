using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ENIMS.DataObjects
{
	public class AppDatabaseTransaction : IDatabaseTransaction
	{
		private IDbContextTransaction _transaction;

		public AppDatabaseTransaction(ApplicationDbContext context)
		{
			_transaction = context.Database.BeginTransaction();
		}

		public void Commit()
		{
			_transaction.Commit();
		}

		public void Rollback()
		{
			_transaction.Rollback();
		}

		public void Dispose()
		{
			_transaction.Dispose();
		}
	}
}
