using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using Worker.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Worker
{
    public partial class frmWorkerMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected WorkerDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "Worker.xls";

        public frmWorkerMaster()
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
            this.dgvDataList = new WorkerDataGridView();
            this.splitContainer1.Panel2.Controls.Add(this.dgvDataList);
            this.dgvDataList.BringToFront();

            this.tsbClear.Click += new EventHandler(tsbClear_Click);
            this.tsbSave.Click += new EventHandler(tsbSave_Click);
            this.tsbSearch.Click += new EventHandler(tsbSearch_Click);

            this.tsbImport.Visible = false;
            this.tsbExport.Visible = false;
        }
          
        void tsbSearch_Click(object sender, EventArgs e)
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadWorkerDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtWorkerCode.Text, this.txtWorkerName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {

            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.Worker_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }
            List<WorkerEntity> entityList = this.dgvDataList.GetData();
            CommandBase command = CommandManager.GetCommand(typeof(WorkerSaveCommand));
            command.OnWorkComplete = Work_RunWorkerCompleted;
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(entityList);
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
            CommandBase command = CommandManager.GetCommand(typeof(LoadWorkerDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtWorkerCode.Text, this.txtWorkerName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.WORKER_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
