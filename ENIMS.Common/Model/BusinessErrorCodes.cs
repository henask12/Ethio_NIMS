using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public class BusinessErrorCodes
	{
		public static string BAD_REQUEST { get { return "BAD_REQUEST"; } }
		public static string TOKEN_ALREADY_CONFIRMED { get { return "TOKEN_ALREADY_CONFIRMED"; } }
		public static string INALID_CONFIRMATION_TOKEN { get { return "INALID_CONFIRMATION_TOKEN"; } }
	}
}
