using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data;
using System.Data.Common;
using ProjectAllocationUtil;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Text;
using System.Globalization;
using ProjectAllocationBusiness.Validation;
using WorkerAllocationStatistics;

using ProjectAllocationBusiness.Statistics;

namespace WorkerAllocationStatistics.Model
{
    public class WorkerAllocationStatisticsManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<WorkerAllocationEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, WorkerAllocationStatisticsSearchCondtion searchCondition = null)
        {
            List<WorkerAllocationEntity> entityList = new List<WorkerAllocationEntity>();

            string sql = "select WorkerCode, WorkerName,count(distinct ProjectCode) As ProjectCount,sum(WorkerWorth) as WorthTotal FROM [ProjectAllocationCalc] WHERE 1=1 and WorkerCode like @WorkerCode and WorkerName like @WorkerName GROUP BY WorkerCode,WorkerName ORDER BY WorkerCode,WorkerName Asc";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
            
            string workerCode = string.Empty;
            string workerName = string.Empty;
            
            if (searchCondition != null)
            {
                workerCode = searchCondition.WorkerCode.Trim();
                workerName = searchCondition.WorkerName.Trim();
            }

            db.AddInParameter(cmd, "WorkerCode", DbType.String, '%' + workerCode + '%');
            db.AddInParameter(cmd, "WorkerName", DbType.String, '%' + workerName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    WorkerAllocationEntity item = new WorkerAllocationEntity();
                    item.WorkerCode = ConvertUtil.ToString(reader["WorkerCode"]);
                    item.WorkerName = ConvertUtil.ToString(reader["WorkerName"]);
                    item.ProjectCount = ConvertUtil.ToInt(reader["ProjectCount"]);
                    item.WorthTotal = ConvertUtil.ToDouble(reader["WorthTotal"]);

                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }

    }
}
