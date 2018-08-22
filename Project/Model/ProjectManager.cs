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
using Project;

namespace Project.Model
{
    public class ProjectManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<ProjectEntity> GetDataFromDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, ProjectSearchCondtion searchCondition = null)
        {
            List<ProjectEntity> entityList = new List<ProjectEntity>();

            string sql = "select ProjectCode, ProjectName FROM [Project] WHERE 1=1 and ProjectCode like @ProjectCode and ProjectName like @ProjectName ORDER BY ProjectCode";
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
                    ProjectEntity item = new ProjectEntity();
                    item.ProjectCode = ConvertUtil.ToString(reader["ProjectCode"]);
                    item.ProjectName = ConvertUtil.ToString(reader["ProjectName"]);
                    item.Action = Constant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }

        public bool SaveDataToDB(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<ProjectEntity> entityList)
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
                    foreach (ProjectEntity entity in entityList)
                    {
                        string strProjectCode = ConvertUtil.ToString(entity.ProjectCode);//Project Code
                        string strProjectName = ConvertUtil.ToString(entity.ProjectName);//Project Name
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        string sql = string.Empty;
                        if (intAction == 2)
                        {
                            sql = "DELETE FROM [Project] WHERE [ProjectCode]=@ProjectCode";
                        }                        
                        else
                        {
                            intAction = 0;
                            sql = "SELECT ProjectCode FROM [Project] WHERE ProjectCode=@ProjectCode";
                            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                            cmd.Parameters.Clear();
                            db.AddInParameter(cmd, "ProjectCode", DbType.String, strProjectCode);

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
                                sql = "INSERT INTO [Project](ProjectCode, ProjectName,Create_dt,Create_User,Update_dt,Update_User) VALUES (@ProjectCode, @ProjectName,datetime(),@Create_User,datetime(),@Update_User)";
                            }
                            else if (intAction == 1)
                            {
                                sql = "UPDATE [Project] SET [ProjectName] =@ProjectName,[Update_dt] =datetime(),[Update_User] =@Update_User WHERE [ProjectCode]=@ProjectCode";
                            }
                        }

                        DbCommand userCommand = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));
                        userCommand.Parameters.Clear();

                        db.AddInParameter(userCommand, "ProjectCode", DbType.String, strProjectCode);
                        db.AddInParameter(userCommand, "ProjectName", DbType.String, strProjectName);
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

        public void DataValidation(ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress, List<ProjectEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            List<ProjectEntity> userDBList = GetDataFromDB(OnProgress);
            var ProjectCodeDBList = from item in userDBList
                                   select item.ProjectCode;
            ListRangeValidator<string> ProjectCodeListRangeValidator = new ListRangeValidator<string>(ProjectCodeDBList.ToList<string>(), true, ProjectAllocationResource.Message.Project_ProjectCode_Exists);


            var ProjectCodeList = from item in entityList
                                   select item.ProjectCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(ProjectCodeList.ToList<string>(), ProjectAllocationResource.Message.Project_ProjectCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<ProjectEntity> entityValidator = valFactory.CreateValidator<ProjectEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (ProjectEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                if (!entity.ReadOnly)
                {
                    ValidationResults userExistCheckResults = ProjectCodeListRangeValidator.Validate(entity.ProjectCode);
                    results.AddAllResults(userExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.ProjectCode);
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
