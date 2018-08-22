using System;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using BudgetUtil;
using System.Threading;
using BudgetFramework.Statues;
using System.IO;
using System.Windows.Forms;
using BudgetFramework;
using BudgetBusiness;
using Excel = Microsoft.Office.Interop.Excel;

namespace SalesPriceNoEnteredList.Model
{
    public class NoEnteredExportManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public void ExportDataToFile(BudgetProgressChangedEventHandler OnProgress, string fileName, string strBudgetYear)
        {
            string templateFilename = Path.Combine(Application.StartupPath, "ExcelTemplate", "SalesPriceNoEnteredList_Template.xls");

            List<NoEnteredExportEntity> entityList = GetDataFromDBExport(OnProgress, strBudgetYear);

            int count = entityList.Count;

            Excel.Application ExApp = new Excel.Application();
            Excel.Workbook ExBook = ExApp.Workbooks.Open(templateFilename);
            Excel.Worksheet ExSheet = ExBook.Worksheets.Item[1];
            Process[] excelList = ExcelUtil.GetProcesses();

            try
            {
                int rowIdx = 5;

                ExSheet.Range["A" + 2].Value = "BudgetYear:" + strBudgetYear;
                ExSheet.Range["N" + 2].Value = string.Format("DB:{0}", ConfigUtil.GetBudgetDB());//DB
                ExSheet.Range["N" + 3].Value = DateTime.Now.ToString();//Date

                for (int i = 0; i < count; i++)
                {
                    if (OnProgress != null)
                    {
                        string InfomationMessage = string.Format(BudgetResource.Message.Common_Master_ExportToExcel_Info, i + 1);
                        int Percentage = (int)((i + 1) * BudgetConstant.ProgressBarMaximum / count);
                        BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(InfomationMessage, Percentage, null);
                        OnProgress(this, args);
                    }

                    NoEnteredExportEntity entity = entityList[i];

                    ExSheet.Range["A" + rowIdx].Value = ConvertUtil.ToString(entity.CustomerCode);
                    ExSheet.Range["B" + rowIdx].Value = ConvertUtil.ToString(entity.CustomerName);
                    ExSheet.Range["C" + rowIdx].Value = ConvertUtil.ToString(entity.IcasCode);
                    ExSheet.Range["D" + rowIdx].Value = ConvertUtil.ToString(entity.Currency);
                    ExSheet.Range["E" + rowIdx].Value = ConvertUtil.ToString(entity.Apr);
                    ExSheet.Range["F" + rowIdx].Value = ConvertUtil.ToString(entity.May);
                    ExSheet.Range["G" + rowIdx].Value = ConvertUtil.ToString(entity.Jun);
                    ExSheet.Range["H" + rowIdx].Value = ConvertUtil.ToString(entity.Jul);
                    ExSheet.Range["I" + rowIdx].Value = ConvertUtil.ToString(entity.Aug);
                    ExSheet.Range["J" + rowIdx].Value = ConvertUtil.ToString(entity.Sep);
                    ExSheet.Range["K" + rowIdx].Value = ConvertUtil.ToString(entity.Oct);
                    ExSheet.Range["L" + rowIdx].Value = ConvertUtil.ToString(entity.Nov);
                    ExSheet.Range["M" + rowIdx].Value = ConvertUtil.ToString(entity.Dec);
                    ExSheet.Range["N" + rowIdx].Value = ConvertUtil.ToString(entity.Jan);
                    ExSheet.Range["O" + rowIdx].Value = ConvertUtil.ToString(entity.Feb);
                    ExSheet.Range["P" + rowIdx].Value = ConvertUtil.ToString(entity.Mar);

                    rowIdx++;

                    Thread.Sleep(10);
                }

                ExSheet.Range["A" + rowIdx].Value = BudgetResource.Resource.ExcelDataEnd;//End Flag

                ExBook.SaveCopyAs(fileName);

            }
            catch
            {
                throw;
            }
            finally
            {
                ExcelUtil.ReleaseResource(ExSheet, ExBook, ExApp);
                ExcelUtil.KillProcess(excelList);
            }
        }

        public List<NoEnteredExportEntity> GetDataFromDBExport(BudgetProgressChangedEventHandler OnProgress, string strBudgetYear)
        {
            List<NoEnteredExportEntity> entityList = new List<NoEnteredExportEntity>();
            string sql = "T01_NoEntered_Get";
            DbCommand cmd = db.GetStoredProcCommand(sql);

            db.AddInParameter(cmd, "BudgetYear", DbType.String, strBudgetYear);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    NoEnteredExportEntity item = new NoEnteredExportEntity();

                    item.BudgetYear = ConvertUtil.ToString(reader["BudgetYear"]);
                    item.CustomerCode = ConvertUtil.ToString(reader["CustomerCode"]);
                    item.CustomerName = ConvertUtil.ToString(reader["CustomerName"]);
                    item.IcasCode = ConvertUtil.ToString(reader["ICASCode"]);
                    item.Currency = ConvertUtil.ToString(reader["Currency"]);

                    item.Apr = ConvertUtil.ToString(reader["Apr"]);
                    item.May = ConvertUtil.ToString(reader["May"]);
                    item.Jun = ConvertUtil.ToString(reader["Jun"]);
                    item.Jul = ConvertUtil.ToString(reader["Jul"]);
                    item.Aug = ConvertUtil.ToString(reader["Aug"]);
                    item.Sep = ConvertUtil.ToString(reader["Sep"]);
                    item.Oct = ConvertUtil.ToString(reader["Oct"]);
                    item.Nov = ConvertUtil.ToString(reader["Nov"]);
                    item.Dec = ConvertUtil.ToString(reader["Dece"]);
                    item.Jan = ConvertUtil.ToString(reader["Jan"]);
                    item.Feb = ConvertUtil.ToString(reader["Feb"]);
                    item.Mar = ConvertUtil.ToString(reader["Mar"]);

                    item.Action = BudgetConstant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
    }
}
