using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using WorkerAllocationStatistics.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

using ProjectAllocationBusiness.Statistics;

namespace WorkerAllocationStatistics.Command
{
    public class LoadWorkerAllocationStatisticsDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            WorkerAllocationStatisticsSearchCondtion searchCondition = new WorkerAllocationStatisticsSearchCondtion();
            searchCondition.WorkerCode = paras[0] as string;
            searchCondition.WorkerName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Project_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            WorkerAllocationStatisticsManager manager = new WorkerAllocationStatisticsManager();
            List<WorkerAllocationEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.WORKERALLOCATIONSTATISTICS_SEARCH] = data;
            return data;
        }
    }
}