using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ClarificationResponse : OperationStatusResponse
    {
       public List<ClarificationDTO> Response { get; set; }
        public ClarificationResponse()
        {
            Response = new List<ClarificationDTO>();
        }
    }

    public class ClarificationDTO 
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long? SupplierId { get; set; }
        public long? ProjectId { get; set; }
        public long? PersonId { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string RegisteredBy { get; set; }
        public MessageStatus MessageStatus { get; set; }
        public DateTime ResponseDueDate { get; set; }
        public ProjectDTO Project { get; set; }
        public SupplierDTO Supplier { get; set; }

    }
}
