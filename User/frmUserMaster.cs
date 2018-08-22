using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using User.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace User
{
    public partial class frmUserMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected UserDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "User.xls";

        public frmUserMaster()
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
            this.dgvDataList = new UserDataGridView();
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
            CommandBase command = CommandManager.GetCommand(typeof(LoadUserDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtUserCode.Text, this.txtUserName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {
            
            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.User_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }
            List<UserEntity> entityList = this.dgvDataList.GetData();
            CommandBase command = CommandManager.GetCommand(typeof(UserSaveCommand));
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
            this.txtUserCode.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadUserDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtUserCode.Text, this.txtUserName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.USER_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
