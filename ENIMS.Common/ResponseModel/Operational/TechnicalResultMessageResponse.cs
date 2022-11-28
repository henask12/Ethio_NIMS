using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class TechnicalResultMessageResponse : OperationStatusResponse
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
    }

    public class ResultMessageResponses :OperationStatusResponse
    {
        public ResultMessageResponses()
        {
            Response = new List<ResultMessageResponse>();
        }
        public List<ResultMessageResponse> Response { get; set; }
    }
    public class ResultMessageResponse
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public long ProjectId { get; set; }
        public string ResultType { get; set; }
    }
}
