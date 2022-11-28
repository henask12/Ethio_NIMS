using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.MasterData
{
    public class BusinessCategoryRequest
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public long BusinessCategoryTypeId { get; set; }
    }
}
