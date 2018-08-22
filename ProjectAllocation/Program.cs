using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Deployment.Application;
using ProjectAllocationUtil;
using System.Diagnostics;

namespace ProjectAllocation
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Handle unhandled exceptions
            Application.ThreadException +=
                new ThreadExceptionEventHandler(Application_ThreadException);

            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //CultureInfo currentCulture = new CultureInfo("en-US");
            CultureInfo currentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = currentCulture;
            Application.CurrentCulture = currentCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isCheckInstance = true;
            if (args.Length >= 1 && args[0] == "restart")
            {
                isCheckInstance = false;
            }
            if (isCheckInstance && HaveOtherInstance())
            {
                MessageBox.Show("has other instance");
                Application.Exit();
                return;
            }

            //AutoUpdater autoUpdate = new AutoUpdater();
            //autoUpdate.Update();

            //if (!InstallUpdateSyncWithInfo())
            //{
            //    Application.Exit();
            //    return;
            //}

            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmProjectAllocation());
            }
            else
            {
                Application.Exit();
                return;
            }
        }

        private static bool HaveOtherInstance()
        {
            bool ret = false;
            try
            {
                string processName = Process.GetCurrentProcess().ProcessName;
                Process[] instances = Process.GetProcessesByName(processName);
                ret = (instances.Length > 1);
            }
            catch (Exception ex)
            {
                ret = true;
                throw ex;
            }

            if (ret)
            {
                //AppMessage.ErrorMessage("不能重复启动！");
            }
            return ret;
        }

        private static bool InstallUpdateSyncWithInfo()
        {
            UpdateCheckInfo info = null;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment AD = ApplicationDeployment.CurrentDeployment;
                try
                {
                    info = AD.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException dde)
                {
                    MessageUtil.ErrorMessage(
                        "The new version of the application cannot be downloaded at this time."
                        + Environment.NewLine + Environment.NewLine +
                        "Please check your network connection, or try again later. Error:" + dde.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    MessageUtil.ErrorMessage(
                        "The application cannot be updated.It is likely not a ClickOnce application."
                        +
                        "Error:" + ioe.Message);
                }

                if (info.UpdateAvailable)
                {
                    bool doUpdate = true;
                    if (!info.IsUpdateRequired)
                    {

                    }
                    if (doUpdate)
                    {
                        try
                        {
                            AD.Update();
                            MessageUtil.InformationMessage("The application has been upgraded, and will now restart.");
                            Application.Restart();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageUtil.ErrorMessage(
                                "Cannot install the latest version of the application."
                                + Environment.NewLine + Environment.NewLine +
                                "Please check your network connection, or try again later. Error:" + dde.Message);

                            return false;
                        }
                    }
                }

            }

            return true;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is System.Exception)
            {
                HandleException((System.Exception)e.ExceptionObject, "Unhandled Policy");
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, "UI Policy");
        }

        public static void HandleException(Exception ex, string policy)
        {
            Boolean rethrow = false;
            try
            {
                var exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
                rethrow = exManager.HandleException(ex, policy);
            }
            catch (Exception innerEx)
            {
                string errorMsg = "An unexpected exception occured while " +
                    "calling HandleException with policy '" + policy + "'. ";
                errorMsg += Environment.NewLine + innerEx.ToString();

                MessageBox.Show(errorMsg, "Application Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

                throw ex;
            }

            if (rethrow)
            {
                // WARNING: This will truncate the stack of the exception
                throw ex;
            }
            else
            {
                MessageBox.Show("An unhandled exception occurred and has " +
                    "been logged. Please contact support.");
            }
        }
    }
}
