using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.RequestModel.Operational
{
    public class UpdateNotificationRequest
    {
        public long Id { get; set; }
        public NotificationType NotificationType { get; set; }

    }
}
