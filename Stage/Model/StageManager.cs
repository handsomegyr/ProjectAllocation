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

namespace Stage.Model
{
    public class StageManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<StageEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, StageSearchCondtion searchCondition = null)
        {
            List<StageEntity> entityList = new List<StageEntity>();

            string sql = "select StageCode, StageName, Percent FROM [Stage] WHERE 1=1 and StageCode like @StageCode and StageName like @StageName ORDER BY StageCode";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));

            string stageCode = string.Empty;
            string stageName = string.Empty;
            
            if (searchCondition != null)
            {
                stageCode = searchCondition.StageCode.Trim();
                stageName = searchCondition.StageName.Trim();
            }

            db.AddInParameter(cmd, "StageCode", DbType.String, '%' + stageCode + '%');
            db.AddInParameter(cmd, "StageName", DbType.String, '%' + stageName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    StageEntity item = new StageEntity();
                    item.StageCode = ConvertUtil.ToString(reader["StageCode"]);
                    item.StageName = ConvertUtil.ToString(reader["StageName"]);
                    item.Percent = ConvertUtil.ToString(reader["Percent"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
        
        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<StageEntity> entityList)
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
                    foreach (StageEntity entity in entityList)
                    {
                        string strStageCode = ConvertUtil.ToString(entity.StageCode);//Stage Code
                        string strStageName = ConvertUtil.ToString(entity.StageName);//Stage Name
                        string strPercent = ConvertUtil.ToString(entity.Percent);//Percent
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [Stage] WHERE [StageCode]=@StageCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT StageCode FROM [Stage] WHERE StageCode=@StageCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "StageCode", DbType.String, strStageCode);

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
                                sql = "INSERT INTO [Stage](StageCode, StageName,Percent,Create_dt,Create_User,Update_dt,Update_User) VALUES (@StageCode, @StageName,@Percent,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [Stage] SET [StageName] =@StageName,[Percent] =@Percent,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [StageCode]=@StageCode";
                            }
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "StageCode", DbType.String, strStageCode);
                        db.AddInParameter(userCommand, "StageName", DbType.String, strStageName);
                        db.AddInParameter(userCommand, "Percent", DbType.Double, strPercent);
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

        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<StageEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<StageEntity> userDBList = GetDataFromDB(OnProgress);
            var userCodeDBList = from item in userDBList
                                 select item.StageCode;
            ListRangeValidator<string> userCodeListRangeValidator = new ListRangeValidator<string>(userCodeDBList.ToList<string>(), true, ProjectAllocationResource.Message.Stage_StageCode_Exists);


            var userCodeList = from item in entityList
                               select item.StageCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(userCodeList.ToList<string>(), ProjectAllocationResource.Message.Stage_StageCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<StageEntity> entityValidator = valFactory.CreateValidator<StageEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (StageEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = userCodeListRangeValidator.Validate(entity.StageCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.StageCode);
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
