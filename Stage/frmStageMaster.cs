using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using Stage.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Stage
{
    public partial class frmStageMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected StageDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "Stage.xls";

        public frmStageMaster()
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
            this.dgvDataList = new StageDataGridView();
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
            CommandBase command = CommandManager.GetCommand(typeof(LoadStageDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtStageCode.Text, this.txtStageName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {

            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.Stage_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }
            List<StageEntity> entityList = this.dgvDataList.GetData();
            CommandBase command = CommandManager.GetCommand(typeof(StageSaveCommand));
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
            this.txtStageCode.Text = string.Empty;
            this.txtStageName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadStageDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtStageCode.Text, this.txtStageName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.STAGE_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
