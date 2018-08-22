using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using Project.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Project
{
    public partial class frmProjectMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected ProjectDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "Project.xls";

        public frmProjectMaster()
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
            this.dgvDataList = new ProjectDataGridView();
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
            CommandBase command = CommandManager.GetCommand(typeof(LoadProjectDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtProjectCode.Text, this.txtProjectName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {
            
            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.Project_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }
            List<ProjectEntity> entityList = this.dgvDataList.GetData();
            CommandBase command = CommandManager.GetCommand(typeof(ProjectSaveCommand));
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
            this.txtProjectCode.Text = string.Empty;
            this.txtProjectName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadProjectDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtProjectCode.Text, this.txtProjectName.Text);
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
