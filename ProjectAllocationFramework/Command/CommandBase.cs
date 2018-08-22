using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;

namespace ProjectAllocationFramework.Command
{
    public abstract class CommandBase
    {
        public abstract object CommandBody(params object[] paras);

        public ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress { get; set; }
        public ProjectAllocationFramework.Statues.WorkerCompletedEventHandler OnWorkComplete { get; set; }

        public void ExecuteAsync(params object[] paras)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync(paras);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool hasError = false;
            try
            {
                if (e.Error != null)
                {
                    Core.ShowError(e.Error);
                    hasError = true;
                }

                ReportWorkCompleteInfo(hasError);

                if (OnWorkComplete != null)
                {
                    object result = null;
                    if (!hasError)
                    {
                        result = e.Result;
                    }
                    OnWorkComplete(null, new ProjectAllocationFramework.Statues.WorkerCompletedEventArgs(result, e.Error, e.Cancelled));
                }
            }
            catch
            {
                throw;
            }
        }

        private void ReportWorkCompleteInfo(bool hasError)
        {
            if (OnProgress != null)
            {
                string TaskName = "";
                if (hasError)
                {
                    //TaskName = "Failure Processed";
                    TaskName = ProjectAllocationResource.Message.Common_Process_Failure;
                }
                else
                {
                    //TaskName = "Success Processed";
                    TaskName = ProjectAllocationResource.Message.Common_Process_Success;
                }

                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
                e.Result = this.CommandBody(e.Argument as object[]);               
            //}
            //catch (ProjectAllocationFramework.RuntimeException ex)
            //{
            //    Core.ShowError(ex);
            //    e.Cancel = true;
            //}
            //catch (Exception ex2)
            //{
            //    //throw;
            //    Core.ShowError(ex2);
            //    e.Cancel = true;
            //}
            //finally
            //{

            //}
            
        }

        public object Execute(params object[] paras)
        {
            object result = null;
            bool hasError = false;
            Exception exception = null;
            bool cancelled = false;

            try
            {
                result = this.CommandBody(paras);
            }
            catch (RuntimeException ex)
            {
                hasError = true;
                exception = ex;
                Core.ShowError(ex);
                
            }
            catch (Exception ex2)
            {
                hasError = true;
                exception = ex2;
                throw;
                //Core.ShowError(ex2);
                
            }
            finally
            {
                ReportWorkCompleteInfo(hasError);

                if (OnWorkComplete != null)
                {
                    ProjectAllocationFramework.Statues.WorkerCompletedEventArgs args = new ProjectAllocationFramework.Statues.WorkerCompletedEventArgs(result, exception, cancelled);

                    OnWorkComplete(null, args);
                }
            }
            return result;

        }
 
    }
}
