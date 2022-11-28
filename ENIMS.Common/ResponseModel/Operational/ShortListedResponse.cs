using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class ShortListedResponses : OperationStatusResponse
    {
        public ShortListedResponses()
        {
            ShortListResponses = new List<ShortListedResponse>();
           
        }
        public List<ShortListedResponse> ShortListResponses { get; set; }
        public long InvitationId { get; set; }

    }
    public class ShortListedResponse
    {
        public ShortListedResponse()
        {
            Attachements = new List<AttachedFile>();
        }
        public SupplierDTO Supplier { get; set; }
        public DateTime ResponseDate { get; set; }
        public List<AttachedFile> Attachements { get; set; }

    }
    public class AttachedFile
    {
        public string AttachementPath { get; set; }
        public string AttachementName { get; set; }
        public bool IsSent { get; set; } = false;
    }
}
