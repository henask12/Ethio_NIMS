using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public class ServiceUtility : IServiceUtility
	{
		public DateTime GetCurrentTime(long orgId)
		{
			//fetch timezone and calculate datetime
			return DateTime.UtcNow;
		}

        public string GetProjectSourcePrefix(ProjectProcessType processType)
        {
            try
            {
                string sourceCode = "";
                switch (processType)
                {
                    case ProjectProcessType.RestrictedBid:
                        sourceCode = "ETRB";
                        break;
                    case ProjectProcessType.OpenBid:
                        sourceCode = "ETOB";
                        break;
                    case ProjectProcessType.TwoStageBidding:
                        sourceCode = "ETTS";
                        break;
                    case ProjectProcessType.SourcingProcess:
                        sourceCode = "ETSP";
                        break;
                    case ProjectProcessType.RFQ:
                        sourceCode = "ETRFQ";
                        break;
                    case ProjectProcessType.DirectPurchase:
                        sourceCode = "ETDP";
                        break;
                    default:
                        sourceCode = "Undefined";
                        break;
                }
                return sourceCode;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
