using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ENIMS.Common
{
    public class LogModel
    {
        public LogModel()
        {
            severityLevel = SeverityLevel.Information;
            properties = new Dictionary<string, string>();
        }

        public object postmessage { get; set; }
        public string response { get; set; }
        
        [Required]
        public string message { get; set; }
        public string module { get; set; }
        public List<string> ErrorList { get; set; }
        public Exception exception { get; set; }
        public SeverityLevel severityLevel { get; set; }
        public Dictionary<string, string> properties { get; set; }
        public Logtype logtype { get; set; }
    }

    public enum Logtype
    {
        SABRE = 1,
        API
    }

    public enum SeverityLevel
    {
        //
        // Summary:
        //     Verbose severity level.
        Verbose = 0,
        //
        // Summary:
        //     Information severity level.
        Information = 1,
        //
        // Summary:
        //     Warning severity level.
        Warning = 2,
        //
        // Summary:
        //     Error severity level.
        Error = 3,
        //
        // Summary:
        //     Critical severity level.
        Critical = 4
    }
}
