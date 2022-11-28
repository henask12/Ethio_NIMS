using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common
{
   public class UploadProcessResponse : OperationStatusResponse 
    {
        public KeyValueAccumulator formAccumulator { get; set; }
        public string FileName { get; set; }
        public List<FileAttachementType>  fileAttachementNames { get; set; }
        public string ext { get; set; } 
    }
    public class FileAttachementType
    {
        public string FileName { get; set; }
        public string keyId { get; set; }
    }

    public class StoredFileResponse : OperationStatusResponse
    {
        public long Id { get; set; }
        public string TrustedName { get; set; }
        public string UnTrustedName { get; set; }
    }
}
