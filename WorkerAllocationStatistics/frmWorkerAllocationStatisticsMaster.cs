using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using WorkerAllocationStatistics.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using ProjectAllocationBusiness.Statistics;

namespace WorkerAllocationStatistics
{
    public partial class frmWorkerAllocationStatisticsMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected WorkerAllocationStatisticsDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "Project.xls";

        public frmWorkerAllocationStatisticsMaster()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            InitializeForm();

            Initialize();            
        }

        private void InitializeForm()
        {
            this.Font = Constant.ProjectAllocationFont;
            // 
            // dgvDataList
            //
            this.dgvDataList = new WorkerAllocationStatisticsDataGridView();
            this.splitContainer1.Panel2.Controls.Add(this.dgvDataList);
            this.dgvDataList.BringToFront();

            this.tsbClear.Click += new EventHandler(tsbClear_Click);
            this.tsbSave.Click += new EventHandler(tsbSave_Click);
            this.tsbSearch.Click += new EventHandler(tsbSearch_Click);

            this.tsbSave.Visible = false;
            this.tsbImport.Visible = false;
            this.tsbExport.Visible = false;
        }
          
        void tsbSearch_Click(object sender, EventArgs e)
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadWorkerAllocationStatisticsDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtWorkerCode.Text, this.txtWorkerName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {            
            
        }

        private void Work_RunWorkerCompleted(object sender, WorkerCompletedEventArgs e)
        {
            if (e.HasError)
            {
                return;
            }
            tsbSearch_Click(sender, e);
        }

        void tsbClear_Click(object sender, EventArgs e)
        {
            this.txtWorkerCode.Text = string.Empty;
            this.txtWorkerName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadWorkerAllocationStatisticsDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtWorkerCode.Text, this.txtWorkerName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.PROJECT_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
