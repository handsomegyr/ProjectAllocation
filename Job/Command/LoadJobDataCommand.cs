using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using Job.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace Job.Command
{
    public class LoadJobDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            JobSearchCondtion searchCondition = new JobSearchCondtion();
            searchCondition.JobCode = paras[0] as string;
            searchCondition.JobName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Job_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            JobManager manager = new JobManager();
            List<JobEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.JOB_SEARCH] = data;
            return data;
        }
    }
}