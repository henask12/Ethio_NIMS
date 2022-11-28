using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class SupplierTechnicalEvaluationUpdateRequest
    {
        public SupplierTechnicalEvaluationUpdateRequest()
        {
            CriateriaRequest = new List<CriateriaRequest>();
        }
        public long Id { get; set; }
        public List<CriateriaRequest> CriateriaRequest { get; set; }
    }
}
