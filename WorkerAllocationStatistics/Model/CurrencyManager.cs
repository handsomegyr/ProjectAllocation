using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Text;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;
using BudgetBusiness.Validation;

namespace Currency.Model
{
    public class CurrencyManager
    {
        private Database db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        public List<CurrencyEntity> GetDataFromDB(BudgetProgressChangedEventHandler OnProgress, CurrencySearchCondtion searchCondition = null)
        {
            List<CurrencyEntity> entityList = new List<CurrencyEntity>();
            string sql = "M05_CURRENCY_Get";
            DbCommand cmd = db.GetStoredProcCommand(sql);
            
            string currencyCode = string.Empty;
            string currencyName = string.Empty;
               
            if (searchCondition != null)
            {
                currencyCode = searchCondition.CurrencyCode;
                currencyName = searchCondition.CurrencyName;
            }

            db.AddInParameter(cmd, "CurrencyCode", DbType.String, currencyCode);
            db.AddInParameter(cmd, "CurrencyName", DbType.String, currencyName);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    CurrencyEntity item = new CurrencyEntity();
                    item.CurrencyCode = ConvertUtil.ToString(reader["CurrencyCode"]);
                    item.CurrencyName = ConvertUtil.ToString(reader["CurrencyName"]);
                    item.Action = BudgetConstant.ACTION_UPDATE;
                    item.ReadOnly = true;
                    //throw new Exception();
                    entityList.Add(item);

                }
            }
            return entityList;
        }
        
        public bool SaveDataToDB(BudgetProgressChangedEventHandler OnProgress, List<CurrencyEntity> entityList)
        {
            // The default database service is determined through configuration
            // and passed to the method as a parameter that can be generated 
            // automatically through injection when the application initializes.
            if (entityList == null || entityList.Count == 0)
            {
                return true;
            }

            bool result = false;

            string sql = "M05_CURRENCY_CreateUpdateDelete";
            DbCommand currencyCommand = db.GetStoredProcCommand(sql);
            int count = entityList.Count;

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();

                try
                {
                    int i = 1;
                    foreach (CurrencyEntity entity in entityList)
                    {

                        currencyCommand.Parameters.Clear();

                        string strCurrencyCode = ConvertUtil.ToString(entity.CurrencyCode);//Currency Code
                        string strCurrencyName = ConvertUtil.ToString(entity.CurrencyName);//Currency Name
                        string strUser = ConvertUtil.ToString(entity.User);//User
                        int intAction = entity.Action;//Action

                        db.AddInParameter(currencyCommand, "CurrencyCode", DbType.String, strCurrencyCode);
                        db.AddInParameter(currencyCommand, "CurrencyName", DbType.String, strCurrencyName);
                        db.AddInParameter(currencyCommand, "Create_User", DbType.String, strUser);
                        db.AddInParameter(currencyCommand, "Update_User", DbType.String, strUser);
                        db.AddInParameter(currencyCommand, "Action", DbType.Int32, intAction);

                        db.ExecuteNonQuery(currencyCommand, trans);

                        if (OnProgress != null)
                        {
                            string InfomationMessage = string.Format("you are saving No. {0} data", i);
                            int Percentage = (int)(i * BudgetConstant.ProgressBarMaximum / count);
                            BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(InfomationMessage, Percentage, null);
                            OnProgress(this, args);
                        }
                        //if success
                        entity.ReadOnly = true;
                        i++;
                    }

                    // Commit the transaction.
                    trans.Commit();

                    result = true;
                }
                catch
                {
                    // Roll back the transaction. 
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }

        }
        
        public void DataValidation(BudgetProgressChangedEventHandler OnProgress, List<CurrencyEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            //List<CategoryEntity> categoryDBList = GetAllCategoryDataFromDB(OnProgress);
            //var categoryCodeDBList = from item in categoryDBList
            //          select item.CategoryCode;
            //ListRangeValidator<string> categoryCodelistRangeValidator = new ListRangeValidator<string>(categoryCodeDBList.ToList<string>(), BudgetResource.Message.Currency_CategoryCode_NoExist);

            List<CurrencyEntity> currencyDBList = GetDataFromDB(OnProgress);
            var currencyCodeDBList = from item in currencyDBList
                                   select item.CurrencyCode;
            ListRangeValidator<string> currencyCodeListRangeValidator = new ListRangeValidator<string>(currencyCodeDBList.ToList<string>(), true ,BudgetResource.Message.Currency_CurrencyCode_Exists);


            var currencyCodeList = from item in entityList
                                   select item.CurrencyCode;
            UniqueValidator<string> UniqueValidator = new UniqueValidator<string>(currencyCodeList.ToList<string>(), BudgetResource.Message.Currency_CurrencyCode_Unique);
            
            ValidatorFactory valFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();
            Validator<CurrencyEntity> entityValidator = valFactory.CreateValidator<CurrencyEntity>();
            int i = 1;
            bool noError = true;
            int count = entityList.Count();
            StringBuilder builder = new StringBuilder();

            foreach (CurrencyEntity entity in entityList)
            {
                ValidationResults results = entityValidator.Validate(entity);
                
                //ValidationResults categoryExistCheckResults = categoryCodelistRangeValidator.Validate(entity.CategoryCode);
                //results.AddAllResults(categoryExistCheckResults);

                if (!entity.ReadOnly)
                {
                    ValidationResults currencyExistCheckResults = currencyCodeListRangeValidator.Validate(entity.CurrencyCode);
                    results.AddAllResults(currencyExistCheckResults);
                }

                ValidationResults uniqueCheckResult = UniqueValidator.Validate(entity.CurrencyCode);
                results.AddAllResults(uniqueCheckResult);

                bool isValid = results.IsValid;

                noError &= isValid;

                if (!isValid)
                {
                    builder.AppendLine(
                            string.Format(
                               CultureInfo.CurrentCulture,
                               BudgetResource.Message.Common_Row_Error,
                               entity.Row));

                    foreach (ValidationResult result in results)
                    {
                        builder.AppendLine(
                            string.Format(
                               CultureInfo.CurrentCulture,
                               BudgetResource.Message.Common_Field_Error,
                               result.Message));
                    }
                    
                }
                if (OnProgress != null)
                {
                    string InfomationMessage = string.Format("you are validating No. {0} data", i);
                    int Percentage = (int)(i * BudgetConstant.ProgressBarMaximum / count);
                    BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(InfomationMessage, Percentage, null);
                    OnProgress(this, args);
                }

                i++;
            }

            if (!noError)
            {
                throw new BudgetRuntimeException("Validation Error", builder.ToString());
            }

        }

        public List<CurrencyEntity> LoadDataFromFile(BudgetProgressChangedEventHandler OnProgress, string fileName)
        {
            Excel.Application ExApp = new Excel.Application();
            Excel.Workbook ExBook = ExApp.Workbooks.Open(fileName);
            Excel.Worksheet ExSheet = ExBook.Worksheets.Item[1];
            Process[] excelList = ExcelUtil.GetProcesses();
            List<CurrencyEntity> entityList = new List<CurrencyEntity>();
            int count = 1;
            try
            {
                int rowIdx = 3;

                string strKey = ConvertUtil.ToString(ExSheet.Range["A" + rowIdx].Value).Trim();

                while (!BudgetResource.Resource.ExcelDataEnd.Equals(strKey, StringComparison.OrdinalIgnoreCase) &&
                    !BudgetResource.Resource.ExcelDataBlank.Equals(strKey, StringComparison.OrdinalIgnoreCase))
                {
                    string strCurrencyCode = ConvertUtil.ToString(ExSheet.Range["A" + rowIdx].Value);//Currency Code
                    string strCurrencyName = ConvertUtil.ToString(ExSheet.Range["B" + rowIdx].Value);//Currency Name
                    string strPassword = ConvertUtil.ToString(ExSheet.Range["C" + rowIdx].Value);//Password
                    
                    CurrencyEntity entity = new CurrencyEntity();
                    entity.CurrencyCode = strCurrencyCode.Trim();//Currency Code
                    entity.CurrencyName = strCurrencyName.Trim();//Currency Name
                    entity.ReadOnly = true;
                    entity.Row = rowIdx;
                    entityList.Add(entity);

                    if (OnProgress != null)
                    {
                        string InfomationMessage = string.Format("you are importing No. {0} data", count);
                        int Percentage = (int)((count + 1) % BudgetConstant.ProgressBarMaximum);
                        BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(InfomationMessage, Percentage, null);
                        OnProgress(this, args);
                    }

                    rowIdx++;
                    count++;
                    strKey = ConvertUtil.ToString(ExSheet.Range["A" + rowIdx].Value).Trim();
                    Thread.Sleep(10);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ExcelUtil.ReleaseResource(ExSheet, ExBook, ExApp);
                ExcelUtil.KillProcess(excelList);
            }
            return entityList;
        }

        public void ExportDataToFile(BudgetProgressChangedEventHandler OnProgress, string fileName)
        {
            string templateFilename = Path.Combine(Application.StartupPath, "ExcelTemplate", "Currency_Template.xls");

            List<CurrencyEntity> entityList = GetDataFromDB(OnProgress);

            int count = entityList.Count;

            Excel.Application ExApp = new Excel.Application();
            Excel.Workbook ExBook = ExApp.Workbooks.Open(templateFilename);
            Excel.Worksheet ExSheet = ExBook.Worksheets.Item[1];
            Process[] excelList = ExcelUtil.GetProcesses();

            try
            {
                int rowIdx = 3;

                ExSheet.Range["E" + 1].Value = DateTime.Now.ToString();//Date

                for (int i = 0; i < count; i++)
                {
                    if (OnProgress != null)
                    {
                        string InfomationMessage = string.Format("you are processing No. {0} data", i + 1);
                        int Percentage = (int)((i + 1) * BudgetConstant.ProgressBarMaximum / count);
                        BudgetProgressChangedEventArgs args = new BudgetProgressChangedEventArgs(InfomationMessage, Percentage, null);
                        OnProgress(this, args);
                    }

                    CurrencyEntity entity = entityList[i];
                    ExSheet.Range["A" + rowIdx].Value = ConvertUtil.ToString(entity.CurrencyCode);//Currency Code
                    ExSheet.Range["B" + rowIdx].Value = ConvertUtil.ToString(entity.CurrencyName);//Currency Name                 

                    rowIdx++;

                    Thread.Sleep(10);
                }

                ExSheet.Range["A" + rowIdx].Value = BudgetResource.Resource.ExcelDataEnd;//End Flag

                ExBook.SaveCopyAs(fileName);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ExcelUtil.ReleaseResource(ExSheet, ExBook, ExApp);
                ExcelUtil.KillProcess(excelList);
            }        
        }

    }
}
