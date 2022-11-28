using System;

namespace ENIMS.Common
{
    public class ClientTokenResponse:OperationStatusResponse
	{
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public long ClientId { get; set; }
    }
}
