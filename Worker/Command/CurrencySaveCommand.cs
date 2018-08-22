using System;
using BudgetFramework.Command;
using BudgetFramework.Statues;
using System.ComponentModel;
using BudgetFramework;
using System.Data;
using BudgetBusiness;
using System.Collections.Generic;
using Currency.Model;

namespace Currency.Command
{
    public class CurrencySaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<CurrencyEntity> SaveData = paras[0] as List<CurrencyEntity>;
            
            CurrencyManager manager = new CurrencyManager();

            if (OnProgress != null)
            {
                string TaskName = BudgetResource.Message.Currency_TaskMessage_Validate;
                BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = BudgetResource.Message.Currency_TaskMessage_Save;
                BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            //Get Data from Db Again
            SaveData = manager.GetDataFromDB(OnProgress);

            Core.CoreData[CoreDataType.CURRENCY_SAVE] = SaveData;
            return SaveData;
        }
    }
}