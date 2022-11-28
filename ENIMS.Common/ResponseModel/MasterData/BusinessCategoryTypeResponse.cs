using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class BusinessCategoryTypeResponse:OperationStatusResponse
    {
        public BusinessCategoryTypeDTO Response { get; set; }
        public BusinessCategoryTypeResponse()
        {
            Response = new BusinessCategoryTypeDTO();
        }
    } 
    public class BusinessCategoryTypesResponse:OperationStatusResponse
    {
        public List<BusinessCategoryTypeDTO> Response { get; set; }
        public BusinessCategoryTypesResponse()
        {
            Response = new List<BusinessCategoryTypeDTO>();
        }
    }
    public class BusinessCategoryTypeDTO
    {
        public long Id { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }
    }
}
