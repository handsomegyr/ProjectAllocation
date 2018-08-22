using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using User.Model;

namespace User.Command
{
    public class UserSaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<UserEntity> SaveData = paras[0] as List<UserEntity>;
            
            UserManager manager = new UserManager();

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.User_TaskMessage_Validate;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.User_TaskMessage_Save;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            return SaveData;
        }
    }
}