using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using Stage.Model;

namespace Stage.Command
{
    public class StageSaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<StageEntity> SaveData = paras[0] as List<StageEntity>;
            
            StageManager manager = new StageManager();

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Stage_TaskMessage_Validate;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Stage_TaskMessage_Save;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            return SaveData;
        }
    }
}