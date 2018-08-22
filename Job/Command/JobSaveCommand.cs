using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using Job.Model;

namespace Job.Command
{
    public class JobSaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<JobEntity> SaveData = paras[0] as List<JobEntity>;
            
            JobManager manager = new JobManager();

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Job_TaskMessage_Validate;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Job_TaskMessage_Save;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            return SaveData;
        }
    }
}