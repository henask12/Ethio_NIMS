using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENIMS.DataObjects
{
   public class ClientUserToken 
	{
        [Key]
        public long Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public long UserId { get; set; }
        public virtual ClientUser User { get; set; }
    }
}
