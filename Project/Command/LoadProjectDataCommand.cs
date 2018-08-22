using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using Project.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace Project.Command
{
    public class LoadProjectDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            ProjectSearchCondtion searchCondition = new ProjectSearchCondtion();
            searchCondition.ProjectCode = paras[0] as string;
            searchCondition.ProjectName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Project_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            ProjectManager manager = new ProjectManager();
            List<ProjectEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.PROJECT_SEARCH] = data;
            return data;
        }
    }
}