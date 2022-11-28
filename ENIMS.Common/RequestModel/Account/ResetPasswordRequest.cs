namespace ENIMS.Common
{
    public class ResetPasswordRequest 
	{
		public string Username { get; set; }
		public string NewPassword { get; set; }
	}

	public class AccountLocking
	{
		public long UserId { get; set; }
		public RecordStatus Status { get; set; }
	}
}
