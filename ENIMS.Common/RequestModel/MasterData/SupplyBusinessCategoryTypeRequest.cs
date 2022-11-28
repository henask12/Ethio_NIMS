using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class SupplyBusinessCategoryTypeRequest
    {
        public long Id { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }
    }
}
