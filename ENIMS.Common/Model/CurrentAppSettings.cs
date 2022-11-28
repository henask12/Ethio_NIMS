using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
	public static class CurrentAppSettings
	{
        public static string AppConnectionString { get; set; }
        public static string CurrentCompanyName { get; set; }
        public static string CurrentUsername { get; set; }
        public static bool IsDefaultOrganizationCreated { get; set; }
    }
}
