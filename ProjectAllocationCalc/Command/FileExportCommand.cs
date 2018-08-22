using System;
using BudgetFramework.Command;
using BudgetFramework.Statues;
using SalesPriceNoEnteredList.Model;

namespace SalesPriceNoEnteredList.Command
{
    public class FileExportCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            string strFileName = paras[0] as string;
            string strBudgetYear = paras[1] as string;
            
            if (OnProgress != null)
            {
                string TaskName = BudgetResource.Message.NoEntered_TaskMessage_Export;
                BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            NoEnteredExportManager manager = new NoEnteredExportManager();
            manager.ExportDataToFile(OnProgress, strFileName, strBudgetYear);

            return true;
        }
    }
}