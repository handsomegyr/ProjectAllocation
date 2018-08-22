using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using ProjectAllocationCalc.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace ProjectAllocationCalc.Command
{
    public class LoadProjectAllocationCalcDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            ProjectAllocationCalcSearchCondtion searchCondition = new ProjectAllocationCalcSearchCondtion();
            searchCondition.ProjectCode = paras[0] as string;
            searchCondition.ProjectName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Project_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            ProjectAllocationCalcManager manager = new ProjectAllocationCalcManager();
            List<ProjectAllocationCalcEntity>  data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.PROJECTALLOCATIONCALC_SEARCH] = data;
            return data;
        }
    }
}