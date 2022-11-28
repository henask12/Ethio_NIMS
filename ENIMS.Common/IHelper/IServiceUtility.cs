using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public interface IServiceUtility
	{
		DateTime GetCurrentTime(long orgId);
		string GetProjectSourcePrefix(ProjectProcessType processType);
	}
}
