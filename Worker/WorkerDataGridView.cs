using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Worker
{
    public partial class WorkerDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn workerCodeColumn;
        private DataGridViewTextBoxColumn workerNameColumn;

        public WorkerDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public WorkerDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.workerCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // 
            // delColumn
            // 
            this.delColumn.HeaderText = "是否删除";
            this.delColumn.MinimumWidth = 60;
            this.delColumn.Name = "delColumn";
            this.delColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.delColumn.ToolTipText = "是否删除";
            this.delColumn.Width = 50;
            // 
            // workerCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.workerCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.workerCodeColumn.HeaderText = "员工号";
            this.workerCodeColumn.MaxInputLength = 30;
            this.workerCodeColumn.Name = "workerCodeColumn";
            this.workerCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // workerNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.workerNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.workerNameColumn.HeaderText = "员工名";
            this.workerNameColumn.MaxInputLength = 100;
            this.workerNameColumn.Name = "workerNameColumn";
            this.workerNameColumn.Width = 450;
            
            //200

            this.RowTemplate.Height = 27;

            initializeColumn();

        }

        private void initializeColumn()
        {
            // 
            // UserDataGridView
            // 
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delColumn,
            this.workerCodeColumn,
            this.workerNameColumn});


            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Columns[this.workerCodeColumn.Name].DefaultCellStyle.Tag = C_RegularExpressions_A_Za_z0_9;
            this.Columns[this.workerNameColumn.Name].DefaultCellStyle.Tag = C_RegularExpressions_A_Za_z0_9Chinese;


            if (this.Tag != null && this.FindForm() != null && this.FindForm().Name == this.Tag.ToString())
            {
                this.delColumn.Visible = false;
                //this.Columns.Remove(this.delColumn);
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.ReadOnly = true;

                this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                this.AllowUserToAddRows = false;
                this.AllowUserToDeleteRows = false;
                this.AllowUserToResizeColumns = false;
                this.AllowUserToResizeRows = false;
                this.EnableHeadersVisualStyles = false;
                //this.ReadOnly = false;
                //this.RowHeadersVisible = false;
                //this.RowHeadersWidth = 10;
                //this.RowTemplate.Height = 23;
                //this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
                this.ShowCellErrors = false;
                this.ShowCellToolTips = false;
                this.ShowEditingIcon = false;
                this.ShowRowErrors = false;
            }
        }

        private delegate void TaskEventHandler<T>(List<T> dataSource);

        private void SetDataSource(List<WorkerEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<WorkerEntity> task = new TaskEventHandler<WorkerEntity>(SetDataSource);
                this.Invoke(task, new object[] { entityList });
            }
            else
            {
                //this.dgvDataList.DataSource = entityList;
                this.Clear();
                initializeColumn();

                if (entityList == null)
                {
                    return;
                }
                var userQuery = from user in entityList
                                where user.Del == false
                                select user;

                foreach (var item in userQuery)
                {
                    int i = this.Rows.Add();
                    this.Rows[i].Cells[this.delColumn.Name].Value = item.Del;
                    this.Rows[i].Cells[this.workerCodeColumn.Name].Value = item.WorkerCode;
                    this.Rows[i].Cells[this.workerCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.workerNameColumn.Name].Value = item.WorkerName;
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.WORKER_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<WorkerEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<WorkerEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<WorkerEntity> entityList = new List<WorkerEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            {
                WorkerEntity entity = new WorkerEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.WorkerCode = ConvertUtil.ToString(item.Cells[this.workerCodeColumn.Name].Value);
                entity.WorkerName = ConvertUtil.ToString(item.Cells[this.workerNameColumn.Name].Value);
                entity.ReadOnly = item.Cells[this.workerCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.WorkerCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
