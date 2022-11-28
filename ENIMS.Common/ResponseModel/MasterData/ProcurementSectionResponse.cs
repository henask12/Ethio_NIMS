using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class ProcurementSectionResponse : OperationStatusResponse
    {
        public ProcurementSectionDTO Response { get; set; }
        public ProcurementSectionResponse()
        {
            Response = new ProcurementSectionDTO();
        }
    }
    public class ProcurementSectionsResponse : OperationStatusResponse
    {
        public List<ProcurementSectionDTO> Response { get; set; }
        public ProcurementSectionsResponse()
        {
            Response = new List<ProcurementSectionDTO>();
        }
    }

    public class ProcurementSectionDTO
    {
        public long Id { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public RequirmentPeriodDTO RequirmentPeriod { get; set; }
    }
}
