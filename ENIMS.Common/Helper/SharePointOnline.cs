namespace ENIMS.Common.Helper
{
    public class SharePointOnline // :ISharePointOnline
    { 
       //public async Task<bool> UploadFileToSharePointOnlineAsync(FileConfig fileConfig)
       // {
       //     try
       //     {
       //         using (var ctx = new AuthenticationManager().GetAzureADAppOnlyAuthenticatedContext(fileConfig.SiteUrl, "6fc0f5c0-62b7-4adb-9176-c1695defa6d2", "2c6a3169-d4de-4366-8e8b-7b6d7a42efcc",
       //             @"c:\Temp\EthiopianAirlines.pfx", "Abcd@1234"))
       //         {
       //             var fcInfo = new FileCreationInformation
       //             {
       //                 Url = fileConfig.FileName,
       //                 Overwrite = true,
       //                 Content = System.IO.File.ReadAllBytes(fileConfig.FilePath)
       //             };

       //             Web myWeb = ctx.Web;

       //             var folder = myWeb.GetFolderByServerRelativeUrl(@"Shared Documents/Pre-Approved");
       //             File uploadFile = folder.Files.Add(fcInfo);

       //             ctx.Load(uploadFile);
       //             ctx.ExecuteQuery();

       //             return true;
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         return false;
       //     }
       // }
    }
}
