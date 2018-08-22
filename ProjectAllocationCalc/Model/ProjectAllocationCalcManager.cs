using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using System.Data;
using System.Collections.Generic;
using ProjectAllocationFramework;

namespace ProjectAllocationCalc.Model
{
    public class ProjectAllocationCalcManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();


        public List<ProjectAllocationCalcEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, ProjectAllocationCalcSearchCondtion searchCondition = null)
        {
            List<ProjectAllocationCalcEntity> entityList = new List<ProjectAllocationCalcEntity>();

            string sql = "select ProjectCode,ProjectName,ProjectWorth,ProjectDate FROM [ProjectAllocationCalc] WHERE 1=1 and ProjectCode like @ProjectCode and ProjectName like @ProjectName ORDER BY ProjectCode";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));

            string projectCode = string.Empty;
            string projectName = string.Empty;

            if (searchCondition != null)
            {
                projectCode = searchCondition.ProjectCode.Trim();
                projectName = searchCondition.ProjectName.Trim();
            }

            db.AddInParameter(cmd, "ProjectCode", DbType.String, '%' + projectCode + '%');
            db.AddInParameter(cmd, "ProjectName", DbType.String, '%' + projectName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {                               
                while (reader.Read())
                {                    
                    ProjectAllocationCalcEntity project = new ProjectAllocationCalcEntity(); 
                    project.ProjectCode = ConvertUtil.ToString(reader["ProjectCode"]);
                    project.ProjectName = ConvertUtil.ToString(reader["ProjectName"]);
                    project.Worth = ConvertUtil.ToDouble(reader["ProjectWorth"]);
                    project.ProjectDate = ConvertUtil.ToString(reader["ProjectDate"]);
                    
                    //throw new Exception();
                    entityList.Add(project);

                }
            }
            
            return entityList;
        }

        public ProjectAllocationCalcEntity GetProjectAllocationCalcEntity(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, string projectCode)
        {
            string sql = "select "  +
                        "ProjectCode,ProjectName,ProjectWorth,ProjectDate," +
                        "StageCode,StageName,StagePercent,StageWorth," +
                        "ProcedureCode,ProcedureName,ProcedurePercent,ProcedureWorth," +
                        "JobCode,JobName,JobPercent,JobWorth," +
                        "WorkerCode,WorkerName,WorkerPercent,WorkerWorth " +
                        "FROM [ProjectAllocationCalc] WHERE 1=1 and ProjectCode = @ProjectCode ORDER BY StageCode asc,ProcedureCode asc,JobCode asc,WorkerCode asc";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));

            db.AddInParameter(cmd, "ProjectCode", DbType.String,  projectCode);
            
            ProjectAllocationCalcEntity project = null;

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                Dictionary<string, StageAllocationCalcEntity> stageAllocationCalcEntityList = new Dictionary<string, StageAllocationCalcEntity>();
                Dictionary<string, ProcedureAllocationCalcEntity> procedureAllocationCalcEntityList = new Dictionary<string, ProcedureAllocationCalcEntity>();
                Dictionary<string, JobAllocationCalcEntity> jobAllocationCalcEntityList = new Dictionary<string, JobAllocationCalcEntity>();

                while (reader.Read())
                {
                    if (project == null)
                    {
                        project = new ProjectAllocationCalcEntity();
                        project.StageAllocationCalcEntityList = new List<StageAllocationCalcEntity>();
                        project.WorkerAllocationCalcEntityList = new List<WorkerAllocationCalcEntity>();
                    }

                    WorkerAllocationCalcEntity worker = new WorkerAllocationCalcEntity();
                    worker.WorkerCode = ConvertUtil.ToString(reader["WorkerCode"]);
                    worker.WorkerName = ConvertUtil.ToString(reader["WorkerName"]);
                    worker.Percent = ConvertUtil.ToDouble(reader["WorkerPercent"]);
                    worker.Worth = ConvertUtil.ToDouble(reader["WorkerWorth"]);

                    // 主师的话
                    if (string.IsNullOrEmpty(ConvertUtil.ToString(reader["StageCode"])))
                    {
                        project.WorkerAllocationCalcEntityList.Add(worker);
                    }
                    else
                    {
                        StageAllocationCalcEntity stage = new StageAllocationCalcEntity();
                        stage.StageCode = ConvertUtil.ToString(reader["StageCode"]);
                        stage.StageName = ConvertUtil.ToString(reader["StageName"]);
                        stage.Percent = ConvertUtil.ToDouble(reader["StagePercent"]);
                        stage.Worth = ConvertUtil.ToDouble(reader["StageWorth"]);
                        stage.ProcedureAllocationCalcEntityList = new List<ProcedureAllocationCalcEntity>();
                        if(stageAllocationCalcEntityList.ContainsKey(stage.StageCode)){
                            stage = stageAllocationCalcEntityList[stage.StageCode];
                        }else{
                            stageAllocationCalcEntityList.Add(stage.StageCode,stage);
                        }


                        ProcedureAllocationCalcEntity procedure = new ProcedureAllocationCalcEntity();
                        procedure.ProcedureCode = ConvertUtil.ToString(reader["ProcedureCode"]);
                        procedure.ProcedureName = ConvertUtil.ToString(reader["ProcedureName"]);
                        procedure.Percent = ConvertUtil.ToDouble(reader["ProcedurePercent"]);
                        procedure.Worth = ConvertUtil.ToDouble(reader["ProcedureWorth"]);
                        procedure.JobAllocationCalcEntityList = new List<JobAllocationCalcEntity>();

                        if(procedureAllocationCalcEntityList.ContainsKey(stage.StageCode+"_"+procedure.ProcedureCode)){
                            procedure = procedureAllocationCalcEntityList[stage.StageCode+"_"+procedure.ProcedureCode];
                        }else{
                            procedureAllocationCalcEntityList.Add(stage.StageCode+"_"+procedure.ProcedureCode,procedure);
                        }

                        JobAllocationCalcEntity job = new JobAllocationCalcEntity();
                        job.JobCode = ConvertUtil.ToString(reader["JobCode"]);
                        job.JobName = ConvertUtil.ToString(reader["JobName"]);
                        job.Percent = ConvertUtil.ToDouble(reader["JobPercent"]);
                        job.Worth = ConvertUtil.ToDouble(reader["JobWorth"]);
                        job.WorkerAllocationCalcEntityList = new List<WorkerAllocationCalcEntity>();

                        if(jobAllocationCalcEntityList.ContainsKey(stage.StageCode+"_"+procedure.ProcedureCode+"_"+job.JobCode)){
                            job = jobAllocationCalcEntityList[stage.StageCode + "_" + procedure.ProcedureCode + "_" + job.JobCode];
                        }else{
                            jobAllocationCalcEntityList.Add(stage.StageCode + "_" + procedure.ProcedureCode + "_" + job.JobCode, job);
                        }
                        
                        job.WorkerAllocationCalcEntityList.Add(worker);
                        procedure.JobAllocationCalcEntityList.Add(job);
                        stage.ProcedureAllocationCalcEntityList.Add(procedure);

                        project.ProjectCode = ConvertUtil.ToString(reader["ProjectCode"]);
                        project.ProjectName = ConvertUtil.ToString(reader["ProjectName"]);
                        project.Worth = ConvertUtil.ToDouble(reader["ProjectWorth"]);
                        project.ProjectDate = ConvertUtil.ToString(reader["ProjectDate"]);
                        project.StageAllocationCalcEntityList.Add(stage);
                    }

                }
            }

            return project;
        }

        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, ProjectAllocationCalcEntity projectAllocationCalcEntity)
        {
            // The default database service is determined through configuration
            // and passed to the method as a parameter that can be generated 
            // automatically through injection when the application initializes.
            if (projectAllocationCalcEntity == null)
            {
                return true;

            }
            if (projectAllocationCalcEntity.StageAllocationCalcEntityList==null)
            {
                projectAllocationCalcEntity.StageAllocationCalcEntityList = new List<StageAllocationCalcEntity>();
            }
            if (projectAllocationCalcEntity.WorkerAllocationCalcEntityList != null)
            {
                JobAllocationCalcEntity job = new JobAllocationCalcEntity();
                job.JobCode = "";
                job.JobName = "";
                job.Percent = 0.00;
                job.Worth = 0.00;
                job.WorkerAllocationCalcEntityList = new List<WorkerAllocationCalcEntity>();

                foreach (var item in projectAllocationCalcEntity.WorkerAllocationCalcEntityList)
                {
                    WorkerAllocationCalcEntity worker = new WorkerAllocationCalcEntity();
                    worker.WorkerCode = item.WorkerCode;
                    worker.WorkerName = item.WorkerName;
                    worker.Percent = item.Percent;
                    worker.Worth = item.Worth;                                        
                    job.WorkerAllocationCalcEntityList.Add(worker);
                }

                ProcedureAllocationCalcEntity procedure = new ProcedureAllocationCalcEntity();
                procedure.ProcedureCode = "";
                procedure.ProcedureName = "";
                procedure.Percent = 0.00;
                procedure.Worth = 0.00;
                procedure.JobAllocationCalcEntityList = new List<JobAllocationCalcEntity>();
                procedure.JobAllocationCalcEntityList.Add(job);

                StageAllocationCalcEntity stage = new StageAllocationCalcEntity();
                stage.StageCode = "";
                stage.StageName = "";
                stage.Percent = 0.00;
                stage.Worth = 0.00;
                stage.ProcedureAllocationCalcEntityList = new List<ProcedureAllocationCalcEntity>();
                stage.ProcedureAllocationCalcEntityList.Add(procedure);

                projectAllocationCalcEntity.StageAllocationCalcEntityList.Add(stage);
            }

            var stageAllocationCalcEntityList = projectAllocationCalcEntity.StageAllocationCalcEntityList;
            if (stageAllocationCalcEntityList == null || stageAllocationCalcEntityList.Count == 0)
            {
                return true;
            }

            bool result = false;

            int count = stageAllocationCalcEntityList.Count;

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();

                try
                {
                    string strProjectCode = ConvertUtil.ToString(projectAllocationCalcEntity.ProjectCode);//Project Code
                    string strProjectName = ConvertUtil.ToString(projectAllocationCalcEntity.ProjectName);//Project Name
                    double dblProjectWorth = ConvertUtil.ToDouble(projectAllocationCalcEntity.Worth);//Project Worth
                    string strProjectDate = ConvertUtil.ToString(projectAllocationCalcEntity.ProjectDate);//Project Date

                    // 删除 
                    string sql = "DELETE FROM [ProjectAllocationCalc] WHERE [ProjectCode]=@ProjectCode";
                    DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                    cmd.Parameters.Clear();
                    db.AddInParameter(cmd, "ProjectCode", DbType.String, strProjectCode);
                    db.ExecuteNonQuery(cmd, trans);

                    int i = 1;
                    foreach (var stage in stageAllocationCalcEntityList)
                    {
                        foreach (var procedure in stage.ProcedureAllocationCalcEntityList)
                        {
                            foreach (var job in procedure.JobAllocationCalcEntityList)
                            {
                                foreach (var worker in job.WorkerAllocationCalcEntityList)
                                {                                   

                                    string strStageCode = ConvertUtil.ToString(stage.StageCode);//Stage Code
                                    string strStageName = ConvertUtil.ToString(stage.StageName);//Stage Name
                                    double dblStagePercent = ConvertUtil.ToDouble(stage.Percent);//Stage Percent
                                    double dblStageWorth = ConvertUtil.ToDouble(stage.Worth);//Stage Worth

                                    string strProcedureCode = ConvertUtil.ToString(procedure.ProcedureCode);//Procedure Code
                                    string strProcedureName = ConvertUtil.ToString(procedure.ProcedureName);//Procedure Name
                                    double dblProcedurePercent = ConvertUtil.ToDouble(procedure.Percent);//Procedure Percent
                                    double dblProcedureWorth = ConvertUtil.ToDouble(procedure.Worth);//Procedure Worth


                                    string strJobCode = ConvertUtil.ToString(job.JobCode);//Job Code
                                    string strJobName = ConvertUtil.ToString(job.JobName);//Job Name
                                    double dblJobPercent = ConvertUtil.ToDouble(job.Percent);//Job Percent
                                    double dblJobWorth = ConvertUtil.ToDouble(job.Worth);//Job Worth

                                    string strWorkerCode = ConvertUtil.ToString(worker.WorkerCode);//Worker Code
                                    string strWorkerName = ConvertUtil.ToString(worker.WorkerName);//Worker Name
                                    double dblWorkerPercent = ConvertUtil.ToDouble(worker.Percent);//Worker Percent
                                    double dblWorkerWorth = ConvertUtil.ToDouble(worker.Worth);//Worker Worth

                                    string strUser = ConvertUtil.ToString(projectAllocationCalcEntity.User);//User
                                    int intAction = 0;//Action

                                    //string sql = string.Empty; 
                                    //sql = "SELECT ProjectCode FROM [ProjectAllocationCalc]  WHERE [ProjectCode]=@ProjectCode And [StageCode]=@StageCode And [ProcedureCode]=@ProcedureCode And [JobCode]=@JobCode And [WorkerCode]=@WorkerCode";
                                    //DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                                    //cmd.Parameters.Clear();
                                    //db.AddInParameter(cmd, "ProjectCode", DbType.String, strProjectCode);
                                    //db.AddInParameter(cmd, "StageCode", DbType.String, strStageCode);
                                    //db.AddInParameter(cmd, "ProcedureCode", DbType.String, strProcedureCode);
                                    //db.AddInParameter(cmd, "JobCode", DbType.String, strJobCode);
                                    //db.AddInParameter(cmd, "WorkerCode", DbType.String, strWorkerCode);

                                    //using (IDataReader reader = db.ExecuteReader(cmd))
                                    //{
                                    //    while (reader.Read())
                                    //    {
                                    //        intAction = 1;
                                    //        break;
                                    //    }
                                    //}

                                    if (intAction == 0)
                                    {
                                        sql = "INSERT INTO [ProjectAllocationCalc](" +
                                            "ProjectCode,ProjectName,ProjectWorth,ProjectDate," +
                                            "StageCode,StageName,StagePercent,StageWorth," +
                                            "ProcedureCode,ProcedureName,ProcedurePercent,ProcedureWorth," +
                                            "JobCode,JobName,JobPercent,JobWorth," +
                                            "WorkerCode,WorkerName,WorkerPercent,WorkerWorth," +
                                            "Create_dt,Create_User,Update_dt,Update_User) VALUES (" +
                                            "@ProjectCode,@ProjectName,@ProjectWorth,@ProjectDate," +
                                            "@StageCode,@StageName,@StagePercent,@StageWorth," +
                                            "@ProcedureCode,@ProcedureName,@ProcedurePercent,@ProcedureWorth," +
                                            "@JobCode,@JobName,@JobPercent,@JobWorth," +
                                            "@WorkerCode,@WorkerName,@WorkerPercent,@WorkerWorth," +
                                            "datetime(),@Create_User,datetime(),@Update_User)";
                                    }
                                    else if (intAction == 1)
                                    {
                                        sql = "UPDATE [ProjectAllocationCalc] SET " + 
                                            "[ProjectName] =@ProjectName,[ProjectWorth] =@ProjectWorth,[ProjectDate] =@ProjectDate," +
                                            "[StageName] =@StageName,[StagePercent] =@StagePercent,[StageWorth] =@StageWorth," +
                                            "[ProcedureName] =@ProcedureName,[ProcedurePercent] =@ProcedurePercent,[ProcedureWorth] =@ProcedureWorth," +
                                            "[JobName] =@JobName,[JobPercent] =@JobPercent,[JobWorth] =@JobWorth," +
                                            "[WorkerName] =@WorkerName,[WorkerPercent] =@WorkerPercent,[WorkerWorth] =@WorkerWorth," +
                                            "[Update_dt] =datetime(),[Update_User] =@Update_User " +
                                        " WHERE [ProjectCode]=@ProjectCode And [StageCode]=@StageCode And [ProcedureCode]=@ProcedureCode And [JobCode]=@JobCode And [WorkerCode]=@WorkerCode";
                                    }
                                    else if (intAction == 2)
                                    {
                                        //sql = "DELETE FROM [ProjectAllocationCalc] WHERE [ProjectCode]=@ProjectCode And [StageCode]=@StageCode And [ProcedureCode]=@ProcedureCode And [JobCode]=@JobCode And [WorkerCode]=@WorkerCode";
                                    }                                   

                                    DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                                    userCommand.Parameters.Clear();

                                    db.AddInParameter(userCommand, "ProjectCode", DbType.String, strProjectCode);
                                    db.AddInParameter(userCommand, "ProjectName", DbType.String, strProjectName);
                                    db.AddInParameter(userCommand, "ProjectWorth", DbType.Double, dblProjectWorth);
                                    db.AddInParameter(userCommand, "ProjectDate", DbType.String, strProjectDate);

                                    db.AddInParameter(userCommand, "StageCode", DbType.String, strStageCode);
                                    db.AddInParameter(userCommand, "StageName", DbType.String, strStageName);
                                    db.AddInParameter(userCommand, "StagePercent", DbType.Double, dblStagePercent);
                                    db.AddInParameter(userCommand, "StageWorth", DbType.Double, dblStageWorth);

                                    db.AddInParameter(userCommand, "ProcedureCode", DbType.String, strProcedureCode);
                                    db.AddInParameter(userCommand, "ProcedureName", DbType.String, strProcedureName);
                                    db.AddInParameter(userCommand, "ProcedurePercent", DbType.Double, dblProcedurePercent);
                                    db.AddInParameter(userCommand, "ProcedureWorth", DbType.Double, dblProcedureWorth);

                                    db.AddInParameter(userCommand, "JobCode", DbType.String, strJobCode);
                                    db.AddInParameter(userCommand, "JobName", DbType.String, strJobName);
                                    db.AddInParameter(userCommand, "JobPercent", DbType.Double, dblJobPercent);
                                    db.AddInParameter(userCommand, "JobWorth", DbType.Double, dblJobWorth);

                                    db.AddInParameter(userCommand, "WorkerCode", DbType.String, strWorkerCode);
                                    db.AddInParameter(userCommand, "WorkerName", DbType.String, strWorkerName);
                                    db.AddInParameter(userCommand, "WorkerPercent", DbType.Double, dblWorkerPercent);
                                    db.AddInParameter(userCommand, "WorkerWorth", DbType.Double, dblWorkerWorth);

                                    db.AddInParameter(userCommand, "Create_User", DbType.String, strUser);
                                    db.AddInParameter(userCommand, "Update_User", DbType.String, strUser);
                                    db.AddInParameter(userCommand, "Action", DbType.Int32, intAction);

                                    db.ExecuteNonQuery(userCommand, trans);

                                    if (OnProgress != null)
                                    {
                                        string InfomationMessage = string.Format(ProjectAllocationResource.Message.Common_Master_Save_Info, i);
                                        int Percentage = (int)(i * Constant.ProgressBarMaximum / count);

                                        ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(InfomationMessage, Percentage, null);
                                        OnProgress(this, args);
                                    }
                                    //if success
                                    worker.ReadOnly = true;
                                    i++;
                                }
                            }
                        }
                    }
                    // Commit the transaction.
                    trans.Commit();

                    result = true;
                }
                catch
                {
                    // Roll back the transaction. 
                    trans.Rollback();
                    throw;
                }
                conn.Close();

                return result;
            }

        }


        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, ProjectAllocationCalcEntity projectAllocationCalcEntity)
        {
            return;

        }

    }
}
