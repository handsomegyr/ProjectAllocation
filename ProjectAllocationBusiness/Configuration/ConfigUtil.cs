using System.Windows.Forms;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using ProjectAllocationUtil;
using ProjectAllocationFramework;

namespace ProjectAllocationBusiness
{
    public class ConfigUtil
    {
        private static string configPath = Path.Combine(Application.StartupPath, "ProjectAllocation.config");
        private static IConfigurationSource configSource = new FileConfigurationSource(configPath);
        private static AppSettingsSection appsettings = configSource.GetSection("appSettings") as AppSettingsSection;
        private static KeyValueConfigurationCollection settings = appsettings.Settings;
        
        public static string GetProjectAllocationServer()
        {
            return settings["ProjectAllocationServer"].Value;
        }

        public static string GetProjectAllocationDB()
        {
            return settings["ProjectAllocationDB"].Value;
        }

        public static string GetSQLUserID()
        {
            return settings["SQLUserID"].Value;
        }

        public static string GetSQLPwd()
        {
            return settings["SQLPwd"].Value;
        }

        public static string GetTimeOut()
        {
            return settings["TimeOut"].Value;
        }

        public static bool IsSetted()
        {
            return ConvertUtil.ToBoolean(settings["IsSetted"].Value);
        }

        public static string GetServerDBInfo()
        {
            string server = settings["ProjectAllocationServer"].Value;
            string databaseName = settings["ProjectAllocationDB"].Value;
            string ret = "Setting";
            if (IsSetted())
            {
                ret = string.Format("Server:{0} DB:{1}", server, databaseName);
            }
            return ret;
        }

        public static void SetServerDBInfo(
            string ProjectAllocationServer,
            string ProjectAllocationDB,
            string SQLUserID,
            string SQLPwd,
            string TimeOut)
        {
            ConnectionStringsSection current = configSource.GetSection("connectionStrings") as ConnectionStringsSection;
            current.ConnectionStrings[1].ConnectionString = string.Format(Constant.CONNECTIONSTRING, ProjectAllocationServer, ProjectAllocationDB, SQLUserID, SQLPwd, TimeOut);
            configSource.Add("connectionStrings", current);
                        
            settings["ProjectAllocationServer"].Value = ProjectAllocationServer;
            settings["ProjectAllocationDB"].Value = ProjectAllocationDB;
            settings["SQLUserID"].Value = SQLUserID;
            settings["SQLPwd"].Value = SQLPwd;
            settings["TimeOut"].Value = TimeOut;
            settings["IsSetted"].Value = true.ToString();
            configSource.Add("appSettings", appsettings);
        }

        public static string GetConnectionStrings()
        {
            string ConnectionStrings = string.Empty;

            if (IsSetted())
            {
                ConnectionStrings = string.Format(Constant.CONNECTIONSTRING, settings["ProjectAllocationServer"].Value, settings["ProjectAllocationDB"].Value,
                    settings["SQLUserID"].Value, settings["SQLPwd"].Value, settings["TimeOut"].Value);
            }
            return ConnectionStrings;
        }

    }
}
