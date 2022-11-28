using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class FloatRequest
    {
        public long TenderInvitationId { get; set; }
        public List<string> FileNames { get; set; }

    }
    public class DocumentFloationRequest
    {
        public DocumentFloationRequest()
        {
            SupplierFlotations=new List<SupplierFlotation>();
        }
        public long TenderInvitationId { get; set; }
        public List<SupplierFlotation> SupplierFlotations { get; set; }
    }
    public class SupplierFlotation
    {
        public long SupplierId { get; set; }
        public List<string> Attachements { get; set; }
    }
}
