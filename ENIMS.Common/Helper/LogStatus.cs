using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ENIMS.Common
{
    public class LogStatus
    {

        private TelemetryClient telemetry = new TelemetryClient();
        private HttpRequest _request;

        public LogStatus()
        {
            //_request = request;
           // telemetry.InstrumentationKey = "8ed07efc-eeb4-4129-863a-4d3145d31040";
            telemetry.InstrumentationKey = "795db06c-6cb0-4a6e-bfdf-8bb48f79e5b0";
        }
        public bool TrackTrace(LogModel logModel)
        {
            try
            {
#if DEBUG
                // remove for local test
                telemetry.InstrumentationKey = "795db06c-6cb0-4a6e-bfdf-8bb48f79e5b0";
#endif
                Guid guid = Guid.NewGuid();
                string request = String.Empty;

                //post message
                if (logModel.postmessage != null)
                {
                    request = JsonConvert.SerializeObject(logModel.postmessage);
                }

                logModel.properties.Add("logid", guid.ToString());
                //logModel.properties.Add("Host", _request != null ? _request.Scheme + "://" + _request.Host.Value + _request.Path.Value : "");
                logModel.properties.Add("Module", logModel.module);
                logModel.properties.Add("request", request);
                logModel.properties.Add("response", logModel.response);
                logModel.properties.Add("logtype", logModel.logtype.ToString());

                if (logModel.exception != null)
                {
                    logModel.properties.Add("Exception", logModel.exception.ToString());
                    logModel.properties.Add("ExceptionMessage", logModel.exception.Message);
                    logModel.properties.Add("ExceptionStackTrace", logModel.exception.TargetSite.Name);

                    telemetry.TrackException(logModel.exception, logModel.properties);
                    telemetry.Flush();
                    logModel.severityLevel = (SeverityLevel)Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Error;
                }

                if (logModel.ErrorList != null)
                {
                    List<string> errorLists = new List<string>();
                    foreach (var error in logModel.ErrorList)
                    {
                        errorLists.Add(error);
                    }
                    logModel.properties.Add("ErrorList", JsonConvert.SerializeObject(errorLists));
                }

                telemetry.TrackTrace(logModel.message, (Microsoft.ApplicationInsights.DataContracts.SeverityLevel)logModel.severityLevel, logModel.properties);
                telemetry.Flush();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        
       
    }
}
