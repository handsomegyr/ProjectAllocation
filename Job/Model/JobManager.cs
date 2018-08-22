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

namespace Job.Model
{
    public class JobManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<JobEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, JobSearchCondtion searchCondition = null)
        {
            List<JobEntity> entityList = new List<JobEntity>();

            string sql = "select JobCode, JobName, Percent FROM [Job] WHERE 1=1 and JobCode like @JobCode and JobName like @JobName ORDER BY JobCode";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
            
            string jobCode = string.Empty;
            string jobName = string.Empty;
            
            if (searchCondition != null)
            {
                jobCode = searchCondition.JobCode.Trim();
                jobName = searchCondition.JobName.Trim();
            }

            db.AddInParameter(cmd, "JobCode", DbType.String, '%' + jobCode + '%');
            db.AddInParameter(cmd, "JobName", DbType.String, '%' + jobName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    JobEntity item = new JobEntity();
                    item.JobCode = ConvertUtil.ToString(reader["JobCode"]);
                    item.JobName = ConvertUtil.ToString(reader["JobName"]);
                    item.Percent = ConvertUtil.ToString(reader["Percent"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
        
        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<JobEntity> entityList)
        {
            // The default database service is determined through configuration
            // and passed to the method as a parameter that can be generated 
            // automatically through injection when the application initializes.
            if (entityList == null || entityList.Count == 0)
            {
                return true;
            }

            bool result = false;

            
            int count = entityList.Count;

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();

                try
                {
                    int i = 1;
                    foreach (JobEntity entity in entityList)
                    {
                        string strJobCode = ConvertUtil.ToString(entity.JobCode);//Job Code
                        string strJobName = ConvertUtil.ToString(entity.JobName);//Job Name
                        string strPercent = ConvertUtil.ToString(entity.Percent);//Percent
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [Job] WHERE [JobCode]=@JobCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT JobCode FROM [Job] WHERE JobCode=@JobCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "JobCode", DbType.String, strJobCode);

                            using (IDataReader reader = db.ExecuteReader(cmd))
                            {
                                while (reader.Read())
                                {
                                    intAction = 1;
                                    break;
                                }
                            }

                            if (intAction == 0)
                            {
                                sql = "INSERT INTO [Job](JobCode, JobName,Percent,Create_dt,Create_User,Update_dt,Update_User) VALUES (@JobCode, @JobName,@Percent,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [Job] SET [JobName] =@JobName,[Percent] =@Percent,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [JobCode]=@JobCode";
                            }                            
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "JobCode", DbType.String, strJobCode);
                        db.AddInParameter(userCommand, "JobName", DbType.String, strJobName);
                        db.AddInParameter(userCommand, "Percent", DbType.String, strPercent);
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
                        entity.ReadOnly = true;
                        i++;
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
        
        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<JobEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<JobEntity> userDBList = GetDataFromDB(OnProgress);
            var jobCodeDBList = from item in userDBList
                                   select item.JobCode;
            ListRangeValidator<string> jobCodeListRangeValidator = new ListRangeValidator<string>(jobCodeDBList.ToList<string>(), true ,ProjectAllocationResource.Message.Job_JobCode_Exists);


            var jobCodeList = from item in entityList
                                   select item.JobCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(jobCodeList.ToList<string>(), ProjectAllocationResource.Message.Job_JobCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<JobEntity> entityValidator = valFactory.CreateValidator<JobEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (JobEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = jobCodeListRangeValidator.Validate(entity.JobCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.JobCode);
                results.AddAllResults(uniqueCheckResult);

                bool isValid = results.IsValid;

                noError &= isValid;

                if (!isValid)
                {
                    builder.AppendLine(
                            string.Format(
                               CultureInfo.CurrentCulture,
                               ProjectAllocationResource.Message.Common_Row_Error,
                               entity.Row));

                    foreach (ValidationResult result in results)
                    {
                        builder.AppendLine(
                            string.Format(
                               CultureInfo.CurrentCulture,
                               ProjectAllocationResource.Message.Common_Field_Error,
                               result.Message));
                    }
                    
                }
                if (OnProgress != null)
                {
                    string InfomationMessage = string.Format(ProjectAllocationResource.Message.Common_Master_Validate_Info, i);
                    int Percentage = (int)(i * Constant.ProgressBarMaximum / count);
                    ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(InfomationMessage, Percentage, null);
                    OnProgress(this, args);
                }

                i++;
            }

            if (!noError)
            {
                throw new ProjectAllocationFramework.RuntimeException("Validation Error", builder.ToString());
            }

        }

    }
}
