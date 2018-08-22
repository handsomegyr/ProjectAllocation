using System;
using System.Windows.Forms;
using ProjectAllocationFramework;
using Procedure.Command;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.Collections.Generic;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Procedure
{
    public partial class frmProcedureMaster : ProjectAllocationLayout.frmMasterBase
    {
        protected ProcedureDataGridView dgvDataList = null;

        private const string EXCELFILENAME = "Procedure.xls";

        public frmProcedureMaster()
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
            this.dgvDataList = new ProcedureDataGridView();
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
            CommandBase command = CommandManager.GetCommand(typeof(LoadProcedureDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtProcedureCode.Text, this.txtProcedureName.Text);
        }

        void tsbSave_Click(object sender, EventArgs e)
        {

            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.Procedure_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }
            List<ProcedureEntity> entityList = this.dgvDataList.GetData();
            CommandBase command = CommandManager.GetCommand(typeof(ProcedureSaveCommand));
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
            this.txtProcedureCode.Text = string.Empty;
            this.txtProcedureName.Text = string.Empty;
            this.dgvDataList.Clear();
        }

        private void Initialize()
        {
            CommandBase command = CommandManager.GetCommand(typeof(LoadProcedureDataCommand));
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.txtProcedureCode.Text, this.txtProcedureName.Text);
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.PROCEDURE_SEARCH:
                    break;

                default:
                    break;
            }
        }
    }
}
