using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using Worker.Model;
using Worker;

namespace Worker.Command
{
    public class WorkerSaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<WorkerEntity> SaveData = paras[0] as List<WorkerEntity>;
            
            WorkerManager manager = new WorkerManager();

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Worker_TaskMessage_Validate;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Worker_TaskMessage_Save;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            return SaveData;
        }
    }
}