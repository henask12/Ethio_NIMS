using ENIMS.Common.ResponseModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.ResponseModel.Operational
{
    public class NotificationResponse :OperationStatusResponse
    {
        public NotificationDto Response { get; set; }
    }
    public class NotificationDto
    {
        public int TenderInvitation { get; set; }
        public int Flotation { get; set; }
        public int Clarification { get; set; }
        public int Negotiation { get; set; }
        public int ResultNotification { get; set; }
    }

    public class ClarificationNotificationResponse : OperationStatusResponse
    {
        public int Clarification { get; set; }
    }
}
