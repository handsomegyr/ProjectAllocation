using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationBusiness.Statistics;
using ProjectAllocationUtil;

namespace WorkerAllocationStatistics
{
    public partial class WorkerAllocationStatisticsDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewTextBoxColumn workerCodeColumn;
        private DataGridViewTextBoxColumn workerNameColumn;
        private DataGridViewTextBoxColumn projectCountColumn;
        private DataGridViewTextBoxColumn worthTotalColumn;

        public WorkerAllocationStatisticsDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public WorkerAllocationStatisticsDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.workerCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.projectCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worthTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

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
            this.workerNameColumn.Width = 200;

            // 
            // projectCountColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.projectCountColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4IntWithoutComma.Clone();
            this.projectCountColumn.HeaderText = "项目数";
            this.projectCountColumn.MaxInputLength = 100;
            this.projectCountColumn.Name = "projectCountColumn";
            this.projectCountColumn.Width = 100;
            this.projectCountColumn.ValueType = typeof(int);

            // 
            // worthTotalColumn
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.worthTotalColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4Double.Clone();
            this.worthTotalColumn.HeaderText = "总产值(元)";
            this.worthTotalColumn.MaxInputLength = 100;
            this.worthTotalColumn.Name = "worthTotalColumn";
            this.worthTotalColumn.Width = 150;
            this.worthTotalColumn.ValueType = typeof(double);

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
            this.workerCodeColumn,
            this.workerNameColumn,
            this.projectCountColumn,
            this.worthTotalColumn});
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

        private delegate void TaskEventHandler<T>(List<T> dataSource);

        private void SetDataSource(List<WorkerAllocationEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<WorkerAllocationEntity> task = new TaskEventHandler<WorkerAllocationEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.workerCodeColumn.Name].Value = item.WorkerCode;
                    this.Rows[i].Cells[this.workerCodeColumn.Name].ReadOnly = true;
                    this.Rows[i].Cells[this.workerNameColumn.Name].Value = item.WorkerName;
                    this.Rows[i].Cells[this.workerNameColumn.Name].ReadOnly = true;

                    this.Rows[i].Cells[this.projectCountColumn.Name].Value = item.ProjectCount;
                    this.Rows[i].Cells[this.projectCountColumn.Name].ReadOnly = true;
                    this.Rows[i].Cells[this.worthTotalColumn.Name].Value = item.WorthTotal;
                    this.Rows[i].Cells[this.worthTotalColumn.Name].ReadOnly = true;
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.WORKERALLOCATIONSTATISTICS_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<WorkerAllocationEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<WorkerAllocationEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<WorkerAllocationEntity> entityList = new List<WorkerAllocationEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            {
                WorkerAllocationEntity entity = new WorkerAllocationEntity();
                entity.WorkerCode = ConvertUtil.ToString(item.Cells[this.workerCodeColumn.Name].Value);
                entity.WorkerName = ConvertUtil.ToString(item.Cells[this.workerNameColumn.Name].Value);
                entity.ProjectCount = ConvertUtil.ToInt(item.Cells[this.projectCountColumn.Name].Value);
                entity.WorthTotal = ConvertUtil.ToDouble(item.Cells[this.worthTotalColumn.Name].Value);

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
