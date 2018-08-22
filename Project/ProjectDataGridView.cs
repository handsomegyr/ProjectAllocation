using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Project
{
    public partial class ProjectDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn projectCodeColumn;
        private DataGridViewTextBoxColumn projectNameColumn;

        public ProjectDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public ProjectDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.projectCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

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
            // projectCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.projectCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.projectCodeColumn.HeaderText = "项目号";
            this.projectCodeColumn.MaxInputLength = 30;
            this.projectCodeColumn.Name = "projectCodeColumn";
            this.projectCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // projectNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.projectNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.projectNameColumn.HeaderText = "项目名";
            this.projectNameColumn.MaxInputLength = 100;
            this.projectNameColumn.Name = "projectNameColumn";
            this.projectNameColumn.Width = 450;
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
            this.projectCodeColumn,
            this.projectNameColumn});
            if (this.Tag !=null && this.FindForm() != null && this.FindForm().Name == this.Tag.ToString())
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

        private void SetDataSource(List<ProjectEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<ProjectEntity> task = new TaskEventHandler<ProjectEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.projectCodeColumn.Name].Value = item.ProjectCode;
                    this.Rows[i].Cells[this.projectCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.projectNameColumn.Name].Value = item.ProjectName;
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.PROJECT_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<ProjectEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<ProjectEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<ProjectEntity> entityList = new List<ProjectEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            {
                ProjectEntity entity = new ProjectEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.ProjectCode = ConvertUtil.ToString(item.Cells[this.projectCodeColumn.Name].Value);
                entity.ProjectName = ConvertUtil.ToString(item.Cells[this.projectNameColumn.Name].Value);
                entity.ReadOnly = item.Cells[this.projectCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.ProjectCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
