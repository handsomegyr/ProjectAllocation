using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework
{
    public class Core
    {
        static NotifiedDictionary coreData;

        public static NotifiedDictionary CoreData
        {
            get { return coreData; }
            set { coreData = value; }
        }

        static Core()
        {
            CoreData = new NotifiedDictionary();
            InitCoreData();

        }

        public static void ShowError(RuntimeException ex)
        {
            ShowError(ex.TaskName,ex.ErrorInfo);
        }

        public static void ShowError(Exception ex)
        {
            RuntimeException bre = ex as RuntimeException;
            if (null != bre)
            {
                ShowError(bre);
            }
            else
            {
                ShowError(ex.Source, ex.Message);
            }
        }

        public static void ShowError(string taskName,string errorInfo)
        {
            frmExceptionBox exceptionBox = new frmExceptionBox();
            exceptionBox.SetErrorInfo(errorInfo);
            exceptionBox.SetTaskInfo(taskName);
            exceptionBox.ShowDialog();
        }

        static void InitCoreData()
        {
            foreach (CoreDataType Key in System.Enum.GetValues(typeof(CoreDataType)))
            {
                CoreData.Add(Key, null);
            }
        }
    }
}
