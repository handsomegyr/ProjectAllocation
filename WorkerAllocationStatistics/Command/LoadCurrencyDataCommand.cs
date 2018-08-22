using System;
using BudgetFramework.Command;
using BudgetFramework.Statues;
using System.ComponentModel;
using BudgetFramework;
using Currency.Model;
using System.Collections.Generic;
using BudgetBusiness;

namespace Currency.Command
{
    public class LoadCurrencyDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            CurrencySearchCondtion searchCondition = new CurrencySearchCondtion();
            searchCondition.CurrencyCode = paras[0] as string;
            searchCondition.CurrencyName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = BudgetResource.Message.Currency_TaskMessage_Load;
                BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            CurrencyManager manager = new CurrencyManager();
            List<CurrencyEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.CURRENCY_SEARCH] = data;
            return data;
        }
    }
}