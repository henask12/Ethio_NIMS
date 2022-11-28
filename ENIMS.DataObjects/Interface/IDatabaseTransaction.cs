using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.DataObjects
{
	public interface IDatabaseTransaction: IDisposable
	{
		void Commit();
		void Rollback();
	}
}
