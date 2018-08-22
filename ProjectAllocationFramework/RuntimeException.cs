using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework
{
    public class RuntimeException: System.Exception
    {
        public RuntimeException():base()
        {
        }

        public RuntimeException(string taskName, string errorInfo)
            : base()
        {
            this.TaskName = taskName;
            this.ErrorInfo = errorInfo;
        }

        public string TaskName { get; set; }
        public string ErrorInfo { get; set; }
    }
}
