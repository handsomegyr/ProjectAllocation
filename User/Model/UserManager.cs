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

namespace User.Model
{
    public class UserManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<UserEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, UserSearchCondtion searchCondition = null)
        {
            List<UserEntity> entityList = new List<UserEntity>();

            string sql = "select UserCode, UserName, Password FROM [User] WHERE 1=1 and UserCode like @UserCode and UserName like @UserName ORDER BY UserCode";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
            
            string userCode = string.Empty;
            string userName = string.Empty;
            string password = string.Empty;
            
            if (searchCondition != null)
            {
                userCode = searchCondition.UserCode.Trim();
                userName = searchCondition.UserName.Trim();
                password = searchCondition.Password.Trim();
            }

            db.AddInParameter(cmd, "UserCode", DbType.String, '%' + userCode + '%');
            db.AddInParameter(cmd, "UserName", DbType.String, '%' + userName + '%');

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    UserEntity item = new UserEntity();
                    item.UserCode = ConvertUtil.ToString(reader["UserCode"]);
                    item.UserName = ConvertUtil.ToString(reader["UserName"]);
                    item.Password = ConvertUtil.ToString(reader["Password"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
        
        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<UserEntity> entityList)
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
                    foreach (UserEntity entity in entityList)
                    {
                        string strUserCode = ConvertUtil.ToString(entity.UserCode);//User Code
                        string strUserName = ConvertUtil.ToString(entity.UserName);//User Name
                        string strPassword = ConvertUtil.ToString(entity.Password);//Password
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [User] WHERE [UserCode]=@UserCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT UserCode FROM [User] WHERE UserCode=@UserCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "UserCode", DbType.String, strUserCode);

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
                                sql = "INSERT INTO [User](UserCode, UserName,Password,Create_dt,Create_User,Update_dt,Update_User) VALUES (@UserCode, @UserName,@Password,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [User] SET [UserName] =@UserName,[Password] =@Password,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [UserCode]=@UserCode";
                            }
                            //sql = "REPLACE INTO [User](UserCode, UserName,Password,Create_dt,Create_User,Update_dt,Update_User) values(@UserCode, @UserName,@Password,datetime(),@Create_User,datetime(),@Update_User)";
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "UserCode", DbType.String, strUserCode);
                        db.AddInParameter(userCommand, "UserName", DbType.String, strUserName);
                        db.AddInParameter(userCommand, "Password", DbType.String, strPassword);
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
        
        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<UserEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<UserEntity> userDBList = GetDataFromDB(OnProgress);
            var userCodeDBList = from item in userDBList
                                   select item.UserCode;
            ListRangeValidator<string> userCodeListRangeValidator = new ListRangeValidator<string>(userCodeDBList.ToList<string>(), true ,ProjectAllocationResource.Message.User_UserCode_Exists);


            var userCodeList = from item in entityList
                                   select item.UserCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(userCodeList.ToList<string>(), ProjectAllocationResource.Message.User_UserCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<UserEntity> entityValidator = valFactory.CreateValidator<UserEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (UserEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = userCodeListRangeValidator.Validate(entity.UserCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.UserCode);
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
