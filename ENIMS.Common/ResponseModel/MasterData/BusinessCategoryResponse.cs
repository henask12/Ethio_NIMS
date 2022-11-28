using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class BusinessCategoryResponse:OperationStatusResponse
    {
        public BusinessCategoryDTO Response { get; set; }
        public BusinessCategoryResponse()
        {
            Response = new BusinessCategoryDTO();
        }
    }
    public class BusinessCategoriesResponse:OperationStatusResponse
    {
        public List<BusinessCategoryDTO> Response { get; set; }
        public BusinessCategoriesResponse()
        {
            Response = new List<BusinessCategoryDTO>();
        }
    }

    public class BusinessCategoryDTO
    {
        public long Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public BusinessCategoryTypeDTO SupplyBusinessCategoryType { get; set; }
    }
}
