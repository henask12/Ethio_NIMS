using ENIMS.Common.RequestModel.Operational;
using ENIMS.Common.ResponseModel.MasterData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class NegotiationSupplierResponses :OperationStatusResponse
    {
        public List<NegotiationSupplierDto> Response { get; set; }
        public NegotiationSupplierResponses()
        {
            Response = new List<NegotiationSupplierDto>();
        }
    }
    public class NegotiationSupplierResponse : OperationStatusResponse
    {
        public NegotiationSupplierDto Response { get; set; }
        public NegotiationSupplierResponse()
        {
            Response = new NegotiationSupplierDto();
        }
    }
    public class NegotiationSupplierDto
    {
        public long Id { get; set; }
        public double TechnicalResult { get; set; }
        public double FinancialResult { get; set; }
        public double Total { get; set; }
        public int Rank { get; set; }
        public virtual SupplierDTO Supplier { get; set; }
        public List<NegotiationCommunicationDto> Communications { get; set; }
        public NegotiationSupplierDto()
        {
            Communications = new List<NegotiationCommunicationDto>();
        }
    }

    public class NegotiationCommunicationDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime lastUpdate { get; set; }
        public int UnseenMessage { get; set; }
        public List<NegotiationCommunicationHistoryDto> Histories { get; set; }
        public NegotiationCommunicationDto()
        {
            Histories = new List<NegotiationCommunicationHistoryDto>();
        }
    }

    public class NegotiationCommunicationHistoryDto
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public string SentBy { get; set; }
        public string SentDate { get; set; }
        public bool Seen { get; set; }
        public long? SupplierId { get; set; }
        public long? PersonId { get; set; }
        public AccountType  Sender { get; set; }
        public  PersonDTO Person { get; set; }
        public  SupplierDTO Supplier { get; set; }
        public List<NegotiationCommunicationHistoryAttachementDto> Attachements { get; set; }
        public NegotiationCommunicationHistoryDto()
        {
            Attachements = new List<NegotiationCommunicationHistoryAttachementDto>();
        }
    }
    public class NegotiationCommunicationHistoryAttachementDto
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string ActualPath { get; set; }
        public bool Seen { get; set; } = false;
        public DateTime SeenDate { get; set; }
    }
}
