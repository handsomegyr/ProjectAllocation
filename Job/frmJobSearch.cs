using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using Job.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using ProjectAllocationBusiness.Entity;

namespace Job
{
    public partial class frmJobSearch : ProjectAllocationLayout.frmMasterBase
    {
        protected JobDataGridView dgvDataList = null;

        public frmJobSearch()
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
            this.dgvDataList = new JobDataGridView();            
            this.dgvDataList.Tag = this.Name;
            this.dgvDataList.CellDoubleClick += new DataGridViewCellEventHandler(dgvDataList_CellDoubleClick);
            this.splitContainer1.Panel2.Controls.Add(this.dgvDataList);
            this.dgvDataList.BringToFront();

            this.tsbClear.Click += new EventHandler(tsbClear_Click);
            this.tsbSearch.Click += new EventHandler(tsbSearch_Click);

            this.tsbImport.Visible = false;
            this.tsbExport.Visible = false;
            this.tsbSave.Visible = false;
        }

        void dgvDataList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
          
        void tsbSearch_Click(object sender, EventArgs e)
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadJobDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtJobCode.Text, this.txtJobName.Text);
        }
        

        public override  DataGridViewSelectedRowCollection SelectedRows()
        {
            return this.dgvDataList.SelectedRows;       
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
            this.txtJobCode.Text = string.Empty;
            this.txtJobName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadJobDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtJobCode.Text, this.txtJobName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.JOB_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
