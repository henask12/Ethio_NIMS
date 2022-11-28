using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational.Negotiation
{
    public class NegotiationCommunicatonResponse:OperationStatusResponse
    {
        public NegotiationCommunicationDto Response { get; set; }
        public NegotiationCommunicatonResponse()
        {
            Response = new NegotiationCommunicationDto();
        }
    }

}
