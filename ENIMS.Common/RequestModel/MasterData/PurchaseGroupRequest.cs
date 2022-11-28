using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class PurchaseGroupRequest
    {
        public long Id { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
