using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework
{
    public enum CoreDataType
    {
        //private Guid keyGuid = Guid.NewGuid();
        //public Guid GUID
        //{
        //    get
        //    {
        //        return keyGuid;
        //    }
        //}

        #region ProjectAllocation
        /// <summary>
        /// menu
        /// </summary>
        MenuItemSelected,
        //public static CoreDataType MenuItemSelected = new CoreDataType(),
        #endregion

        #region User
        USER_SEARCH,
        #endregion

        
        #region Rate
        RATE_SEARCH,
        RATE_CURRENCY_GET,
        #endregion

        #region ICAS

        ICAS_SEARCH,
        ICAS_CATEGORY_GET,


        #endregion

        #region PurchaseIndex

        PurchaseIndex_SEARCH,

        #endregion

        #region PurchaseFix

        PurchaseFix_SEARCH,

        #endregion

        #region ProjectAllocationCompare

        ProjectAllocationCompare_SEARCH,

        #endregion

        #region PRODUCT

        PRODUCT_SEARCH,
        PRODUCT_ICAS_GET,

        #endregion

        #region SALESQUNTITYMODIFY

        SALESQUNTITYMODIFY_SEARCH,
        SALESQUNTITYMODIFY_GET,

        #endregion 

        #region SALESPLANAMOUNTMONTH

        SALESPLANAMOUNTMONTH_SEARCH,
        SALESPLANAMOUNTMONTH_GET,

        #endregion

        #region SALESPLANQUANTITYPERIOD

        SALESPLANQUANTITYPERIOD_SEARCH,
        SALESPLANQUANTITYPERIOD_GET,

        #endregion

        #region Category

        Category_SEARCH,
        Category_CATEGORY_GET,

        #endregion

        #region Customer

        Customer_SEARCH,
        Customer_CustomerType_GET,
        Customer_ActiveFlag_GET,

        #endregion

        #region SalesPrice

        SalesPrice_SEARCH,
        SalesPrice_CUSTOMER_GET,

        #endregion

        #region FobPrice

        FobPrice_SEARCH,
        FobPrice_CUSTOMER_GET,

        #endregion


        #region Version

        Version_SAVE,
        Version_SEARCH,
        Version_CLEAR,
        Version_SELECT,

        #endregion

        #region TradeGrossInput

        TradeGrossInput_SEARCH,

        #endregion

        #region PSS

        PSS_SEARCH,

        #endregion

        #region UI
        /// <summary>
        /// ActiveDockPanel
        /// </summary>
        ActiveDockPanel,
        /// <summary>
        /// DockContent
        /// </summary>
        ActiveDockContent,
        /// <summary>
        /// Main Form
        /// </summary>
        ApplicationForm,

        /// <summary>
        /// ProgressBar
        /// </summary>
        ProgressBarMaximum,
        ProgressBarValue,
        #endregion

        #region Update
        HasNewVersion,
        #endregion

        #region Task
        IsTaskProcessing,

        #endregion

        #region Project
        PROJECT_SEARCH,
        #endregion

        #region Stage
        STAGE_SEARCH,
        #endregion

        #region Procedure
        PROCEDURE_SEARCH,
        #endregion

        #region Job
        JOB_SEARCH,
        #endregion

        #region Worker
        WORKER_SEARCH,
        #endregion


        #region ProjectAllocationCalc
        PROJECTALLOCATIONCALC_SEARCH,
        #endregion

        #region WorkerAllocationStatistics
        WORKERALLOCATIONSTATISTICS_SEARCH
        #endregion
    }

}
