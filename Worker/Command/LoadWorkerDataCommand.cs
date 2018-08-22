using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using Worker.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace Worker.Command
{
    public class LoadWorkerDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            WorkerSearchCondtion searchCondition = new WorkerSearchCondtion();
            searchCondition.WorkerCode = paras[0] as string;
            searchCondition.WorkerName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Worker_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            WorkerManager manager = new WorkerManager();
            List<WorkerEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.WORKER_SEARCH] = data;
            return data;
        }
    }
}