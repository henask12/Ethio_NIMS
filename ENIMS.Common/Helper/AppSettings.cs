namespace ENIMS.Common
{
    public class AppSettings
	{
        public string Secret { get; set; }
        public string ClientSecret { get; set; } 
		public string UserSecret { get; set; } 
		public string EmailConfirmationSecret { get; set; }
		public string RecoverPasswordSecret { get; set; }
		public string InviteUserSecret { get; set; }
        public long SupplierRoleId { get; set; }
    }

	public class FileSettings
	{
		public string StoredFilesPath { get; set; }
		public  long FileSizeLimit { get; set; }
	}
}
