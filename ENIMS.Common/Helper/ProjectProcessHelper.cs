using ENIMS.Common.ResponseModel.Common;
using ENIMS.Common.ResponseModel.Operational;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIMS.Common.Helper
{
    public  class ProjectProcessResponse
    {
        public bool PerformTask { get; set; }
        public string Message { get; set; }
    }

    public class ProjectProcessTaskResponse :OperationStatusResponse
    {
        public ProjectProcessTaskResponse()
        {
            TaskMatrix = new List<ProjectProcessTaskDto>();
        }
        public List<ProjectProcessTaskDto> TaskMatrix { get; set; }
        public ProjectDTO Project { get; set; }

    }

    public class ProjectProcessTaskDto
    {
        public ProjectProcessType ProcessType { get; set; }
        public ProjectTask Task { get; set; }
        public int Order { get; set; }
        public Necessity Necessity { get; set; }
        public string Remark { get; set; }
        public bool IsRequiredForFirstStage { get; set; }
        public bool HasNoAction { get; set; }
    }
}
