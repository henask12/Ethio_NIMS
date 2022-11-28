using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class TechnicalResultDetailResponse : OperationStatusResponse
    {
        public TechnicalResultDetailDto Response { get; set; }
        public TechnicalResultDetailResponse()
        {
            Response = new TechnicalResultDetailDto();
        }
    }
    public class TechnicalResultDetailDto
    {
        public TechnicalResultDetailDto()
        {
            Groups = new List<TechnicalCritreaResultGroupDto>();
        }
        public long Id { get; set; }//key
        public int Rank { get; set; }
        public SupplierDTO Supplier { get; set; }
        public List<string> Attachments { get; set; }
        public TechnicalResult Status { get; set; }
        public DateTime EvaluationDate { get; set; }
        public List<TechnicalCritreaResultGroupDto> Groups { get; set; }
    }
    public class TechnicalCritreaResultGroupDto
    {
        public TechnicalCritreaResultGroupDto()
        {
            Results = new List<CriteriaResultDto>();
        }
        public long Id { get; set; }
        public string GroupName { get; set; }
        public List<CriteriaResultDto> Results { get; set; }
    }

}
