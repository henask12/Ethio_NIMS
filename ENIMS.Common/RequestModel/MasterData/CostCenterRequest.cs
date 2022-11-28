using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class CostCenterRequest
    {
        public long Id { get; set; }
        public long? CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Station { get; set; }
        public string CostCenterName { get; set; }
    }
    public class CostCenterRequests
    {
        public List<CostCenterRequest> Requests { get; set; }
    }
}
