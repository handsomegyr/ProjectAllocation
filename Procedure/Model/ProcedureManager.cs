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

namespace Procedure.Model
{
    public class ProcedureManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<ProcedureEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, ProcedureSearchCondtion searchCondition = null)
        {
            List<ProcedureEntity> entityList = new List<ProcedureEntity>();

            string sql = "select ProcedureCode, ProcedureName, Percent FROM [Procedure] WHERE 1=1 and ProcedureCode like @ProcedureCode and ProcedureName like @ProcedureName ORDER BY ProcedureCode";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));

            string procedureCode = string.Empty;
            string procedureName = string.Empty;
            
            if (searchCondition != null)
            {
                procedureCode = searchCondition.ProcedureCode.Trim();
                procedureName = searchCondition.ProcedureName.Trim();
            }

            db.AddInParameter(cmd, "ProcedureCode", DbType.String, '%' + procedureCode + '%');
            db.AddInParameter(cmd, "ProcedureName", DbType.String, '%' + procedureName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ProcedureEntity item = new ProcedureEntity();
                    item.ProcedureCode = ConvertUtil.ToString(reader["ProcedureCode"]);
                    item.ProcedureName = ConvertUtil.ToString(reader["ProcedureName"]);
                    item.Percent = ConvertUtil.ToString(reader["Percent"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
        
        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<ProcedureEntity> entityList)
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
                    foreach (ProcedureEntity entity in entityList)
                    {
                        string strProcedureCode = ConvertUtil.ToString(entity.ProcedureCode);//Procedure Code
                        string strProcedureName = ConvertUtil.ToString(entity.ProcedureName);//Procedure Name
                        string strPercent = ConvertUtil.ToString(entity.Percent);//Percent
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [Procedure] WHERE [ProcedureCode]=@ProcedureCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT ProcedureCode FROM [Procedure] WHERE ProcedureCode=@ProcedureCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "ProcedureCode", DbType.String, strProcedureCode);

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
                                sql = "INSERT INTO [Procedure](ProcedureCode, ProcedureName,Percent,Create_dt,Create_User,Update_dt,Update_User) VALUES (@ProcedureCode, @ProcedureName,@Percent,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [Procedure] SET [ProcedureName] =@ProcedureName,[Percent] =@Percent,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [ProcedureCode]=@ProcedureCode";
                            }
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "ProcedureCode", DbType.String, strProcedureCode);
                        db.AddInParameter(userCommand, "ProcedureName", DbType.String, strProcedureName);
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

        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<ProcedureEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<ProcedureEntity> userDBList = GetDataFromDB(OnProgress);
            var userCodeDBList = from item in userDBList
                                 select item.ProcedureCode;
            ListRangeValidator<string> userCodeListRangeValidator = new ListRangeValidator<string>(userCodeDBList.ToList<string>(), true, ProjectAllocationResource.Message.Procedure_ProcedureCode_Exists);


            var userCodeList = from item in entityList
                               select item.ProcedureCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(userCodeList.ToList<string>(), ProjectAllocationResource.Message.Procedure_ProcedureCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<ProcedureEntity> entityValidator = valFactory.CreateValidator<ProcedureEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (ProcedureEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = userCodeListRangeValidator.Validate(entity.ProcedureCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.ProcedureCode);
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
