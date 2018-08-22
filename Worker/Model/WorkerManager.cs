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
using Worker;

namespace Worker.Model
{
    public class WorkerManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<WorkerEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, WorkerSearchCondtion searchCondition = null)
        {
            List<WorkerEntity> entityList = new List<WorkerEntity>();

            string sql = "select WorkerCode, WorkerName FROM [Worker] WHERE 1=1 and WorkerCode like @WorkerCode and WorkerName like @WorkerName ORDER BY WorkerCode";
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
                    WorkerEntity item = new WorkerEntity();
                    item.WorkerCode = ConvertUtil.ToString(reader["WorkerCode"]);
                    item.WorkerName = ConvertUtil.ToString(reader["WorkerName"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }

        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<WorkerEntity> entityList)
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
                    foreach (WorkerEntity entity in entityList)
                    {
                        string strWorkerCode = ConvertUtil.ToString(entity.WorkerCode);//Project Code
                        string strWorkerName = ConvertUtil.ToString(entity.WorkerName);//Project Name
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [Worker] WHERE [WorkerCode]=@WorkerCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT WorkerCode FROM [Worker] WHERE WorkerCode=@WorkerCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "WorkerCode", DbType.String, strWorkerCode);

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
                                sql = "INSERT INTO [Worker](WorkerCode, WorkerName,Create_dt,Create_User,Update_dt,Update_User) VALUES (@WorkerCode, @WorkerName,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [Worker] SET [WorkerName] =@WorkerName,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [WorkerCode]=@WorkerCode";
                            }
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "WorkerCode", DbType.String, strWorkerCode);
                        db.AddInParameter(userCommand, "WorkerName", DbType.String, strWorkerName);
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

        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<WorkerEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<WorkerEntity> userDBList = GetDataFromDB(OnProgress);
            var WorkerCodeDBList = from item in userDBList
                                   select item.WorkerCode;
            ListRangeValidator<string> WorkerCodeListRangeValidator = new ListRangeValidator<string>(WorkerCodeDBList.ToList<string>(), true, ProjectAllocationResource.Message.Worker_WorkerCode_Exists);


            var WorkerCodeList = from item in entityList
                                   select item.WorkerCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(WorkerCodeList.ToList<string>(), ProjectAllocationResource.Message.Worker_WorkerCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<WorkerEntity> entityValidator = valFactory.CreateValidator<WorkerEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (WorkerEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = WorkerCodeListRangeValidator.Validate(entity.WorkerCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.WorkerCode);
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
