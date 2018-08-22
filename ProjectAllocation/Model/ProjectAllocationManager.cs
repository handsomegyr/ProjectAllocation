using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data;
using System.Data.Common;
using ProjectAllocationUtil;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using ProjectAllocationBusiness.Business;

namespace ProjectAllocation.Model
{
    public class ProjectAllocationManager
    {
        public bool Login(string UserCode, string Password, ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress = null)
        {
            Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
            
            bool ret = false;
            string sql = "select UserCode, UserName, Password FROM [User] WHERE UserCode = @UserCode and Password = @Password";
            DbCommand cmd = DatabaseUtil.GetCommand(db.GetSqlStringCommand(sql));

            db.AddInParameter(cmd, "UserCode", DbType.String, UserCode);
            db.AddInParameter(cmd, "Password", DbType.String, Password);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    UserEntity item = new UserEntity();
                    item.UserCode = ConvertUtil.ToString(reader["UserCode"]);
                    item.UserName = ConvertUtil.ToString(reader["UserName"]);
                    item.Password = ConvertUtil.ToString(reader["Password"]);
                    User.Operator = item;
                    ret = true;

                }
            }
            return ret;
        }
    }
}
