using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationFramework.Statues;
using System.Data.Common;
using System.Data;
using ProjectAllocationFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ProjectAllocationUtil;
using ProjectAllocationBusiness.Business;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.SqlClient;

namespace ProjectAllocationBusiness
{
    public class BusinessFacade
    {
        

        public static int GetProjectAllocationVersionByYear(double ProjectAllocationYear)
        {
            if (2000>ProjectAllocationYear)
            {
                throw new ArgumentException("yearMonth");
            }
            //2006---->143
            return 143 + (int)ProjectAllocationYear - 2006;
        }


        public static List<string> GetDbInstance(
           string ProjectAllocationServer,
           string ProjectAllocationDB,
           string SQLUserID,
           string SQLPwd,
           string TimeOut,
           ProjectAllocationFramework.Statues.ProgressChangedEventHandler OnProgress = null)
        {

            string sql = "select name from master.dbo.sysdatabases where cmptlevel >= '80' and dbid>=5 order by name ";
            string connectionString = string.Format(Constant.CONNECTIONSTRING, ProjectAllocationServer, ProjectAllocationDB, SQLUserID, SQLPwd, TimeOut);
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;

            List<string> listDb = new List<string>();

            using (IDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    listDb.Add(ConvertUtil.ToString(reader["Name"]));

                }
            }
            return listDb;
        }

    }
}
