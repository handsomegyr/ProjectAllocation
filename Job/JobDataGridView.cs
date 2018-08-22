using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Job
{
    public partial class JobDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn jobCodeColumn;
        private DataGridViewTextBoxColumn jobNameColumn;
        private DataGridViewTextBoxColumn percentColumn;

        public JobDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public JobDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.jobCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jobNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

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
            // jobCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jobCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.jobCodeColumn.HeaderText = "工序码";
            this.jobCodeColumn.MaxInputLength = 10;
            this.jobCodeColumn.Name = "jobCodeColumn";
            this.jobCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // jobNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.jobNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.jobNameColumn.HeaderText = "工序名";
            this.jobNameColumn.MaxInputLength = 30;
            this.jobNameColumn.Name = "jobNameColumn";
            this.jobNameColumn.Width = 450;
            // 
            // percentColumn
            // 
            this.percentColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4Double.Clone();
            this.percentColumn.HeaderText = "所占比例%";
            this.percentColumn.MaxInputLength = 15;
            this.percentColumn.Name = "percentColumn";
            this.percentColumn.Width = 200;
            this.percentColumn.ValueType = typeof(double);

            this.RowTemplate.Height = 27;

            initializeColumn();

        }

        private void initializeColumn()
        {
            // 
            // JobDataGridView
            // 
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delColumn,
            this.jobCodeColumn,
            this.jobNameColumn,
            this.percentColumn});

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

        private void SetDataSource(List<JobEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<JobEntity> task = new TaskEventHandler<JobEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.jobCodeColumn.Name].Value = item.JobCode;
                    this.Rows[i].Cells[this.jobCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.jobNameColumn.Name].Value = item.JobName;
                    this.Rows[i].Cells[this.percentColumn.Name].Value = ConvertUtil.ToDouble(item.Percent);
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.JOB_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<JobEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<JobEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<JobEntity> entityList = new List<JobEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            { 
                JobEntity entity = new JobEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.JobCode = ConvertUtil.ToString(item.Cells[this.jobCodeColumn.Name].Value);
                entity.JobName = ConvertUtil.ToString(item.Cells[this.jobNameColumn.Name].Value);
                entity.Percent = ConvertUtil.ToString(item.Cells[this.percentColumn.Name].Value, "0.00");
                entity.ReadOnly = item.Cells[this.jobCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.JobCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
