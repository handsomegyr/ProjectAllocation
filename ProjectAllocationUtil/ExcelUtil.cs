using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace ProjectAllocationUtil
{
    public class ExcelCompare : IEqualityComparer<Process>
    {
        public bool Equals(Process x, Process y)
        {
            return (x.Id == y.Id);
        }

        public int GetHashCode(Process obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ExcelUtil
    { 
        public static Process[] GetProcesses(){
            return Process.GetProcessesByName("EXCEL");
        }

        public static void KillProcess(Process[] processes){
            if(processes ==null) return;
            
            foreach(var p in GetProcesses()){
                if(processes.Contains(p,new ExcelCompare()) && !p.CloseMainWindow()){
                    p.Kill();
                    p.WaitForExit();
                    p.Close();
                }
            }
        }

        public static void ReleaseResource(Worksheet sheet, Workbook book, Application app)
        {
            if(sheet != null){
                Marshal.ReleaseComObject(sheet);
            }

            if(book != null){
                book.Close(book.Saved, book.Name,Type.Missing);
                Marshal.ReleaseComObject(book);
            }

            if(app != null){
                app.Workbooks.Close();
                app.Quit();
                Marshal.ReleaseComObject(app);
            }

            sheet = null;
            book = null;
            app = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
}
