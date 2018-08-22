using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using Stage.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace Stage.Command
{
    public class LoadStageDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            StageSearchCondtion searchCondition = new StageSearchCondtion();
            searchCondition.StageCode = paras[0] as string;
            searchCondition.StageName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Stage_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            StageManager manager = new StageManager();
            List<StageEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.STAGE_SEARCH] = data;
            return data;
        }
    }
}