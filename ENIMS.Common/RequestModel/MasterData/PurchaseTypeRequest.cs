using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class PurchaseTypeRequest
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
