using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.MasterData
{
    public class PersonResponse : OperationStatusResponse
    {
        public PersonDTO Response { get; set; }
        public PersonResponse()
        {
            Response = new PersonDTO();
        }
    }
    public class PersonsResponse: OperationStatusResponse
    {
        public List<PersonDTO> Response { get; set; }
        public PersonsResponse()
        {
            Response = new List<PersonDTO>();
        }
    }
   public class PersonDTO
    {
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ExtensionNumber { get; set; }
        public string Position { get; set; }
        public CostCenterDTO CostCenter { get; set; }// Forign key for  costCenter
    }
}
