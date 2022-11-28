using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.Model
{
    public class HelperDTO
    {

    }
    public class ProjectSourcingId
    {
        public long? SourceId { get; set; }
        public string ProjectCode { get; set; }
    }
    public class FileUploadResult
    {
        public bool  Result { get; set; }
        public string Path { get; set; }
    }
}
