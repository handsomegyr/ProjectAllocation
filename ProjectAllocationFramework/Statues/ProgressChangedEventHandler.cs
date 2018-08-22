using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ProjectAllocationFramework.Statues
{
    public delegate void ProgressChangedEventHandler(object sender, ProgressChangedEventArgs e);
    public delegate void WorkerCompletedEventHandler(object sender, WorkerCompletedEventArgs e);

    public class ProgressChangedEventArgs : System.ComponentModel.ProgressChangedEventArgs
    {
        public ProgressChangedEventArgs(string progressInfo, int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
            this.ProgressInfo = progressInfo;
        }

        public ProgressChangedEventArgs(string TaskName)
            : base(0, null)
        {
            this.TaskName = TaskName;
            this.ProgressInfo = "";
        }

        public string ProgressInfo { get; set; }
        public string TaskName { get; set; }
    }

    public class WorkerCompletedEventArgs : System.EventArgs
    {
        public WorkerCompletedEventArgs():this(null,null,false,null)
        {

        }
        public WorkerCompletedEventArgs(object result, Exception error, bool cancelled)
            : this(result, error, cancelled, null)
        {
        }

        public WorkerCompletedEventArgs(object result, Exception error, bool cancelled, object userState)
        {
            this.Result = result;
            this.Error = error;
            this.Cancelled = cancelled;
            this.UserState = userState;
        }

        public bool Cancelled { get; set; }

        public Exception Error { get; set; }

        public object UserState { get; set; }

        public object Result { get; set; }

        public bool HasError 
        {
            get
            {
                return (Error != null);
            }
        }

    }
}
