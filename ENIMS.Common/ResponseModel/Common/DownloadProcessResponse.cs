using System.IO;

namespace ENIMS.Common
{
    public class DownloadProcessResponse : OperationStatusResponse
    {
        public MemoryStream FileMemoryStream { get; set; }
        public string ContentType { get; set; }
        public string GetFileName { get; set; }
    } 
    public class DownloadResponse : OperationStatusResponse
    {
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
        public string GetFileName { get; set; }
    }
}
