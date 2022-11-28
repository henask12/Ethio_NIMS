using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational.Negotiation
{
    public class CreatNegotiatonSubjectRequest
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public long NegotiationSupplierId { get; set; }
    }
}
