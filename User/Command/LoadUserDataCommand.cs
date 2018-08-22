using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using User.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace User.Command
{
    public class LoadUserDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            UserSearchCondtion searchCondition = new UserSearchCondtion();
            searchCondition.UserCode = paras[0] as string;
            searchCondition.UserName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.User_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            UserManager manager = new UserManager();
            List<UserEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.USER_SEARCH] = data;
            return data;
        }
    }
}