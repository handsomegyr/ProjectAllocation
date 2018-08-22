using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Stage
{
    public partial class StageDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn stageCodeColumn;
        private DataGridViewTextBoxColumn stageNameColumn;
        private DataGridViewTextBoxColumn percentColumn;

        public StageDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public StageDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stageCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // stageCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.stageCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.stageCodeColumn.HeaderText = "阶段码";
            this.stageCodeColumn.MaxInputLength = 10;
            this.stageCodeColumn.Name = "stageCodeColumn";
            this.stageCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // stageNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.stageNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.stageNameColumn.HeaderText = "阶段名";
            this.stageNameColumn.MaxInputLength = 30;
            this.stageNameColumn.Name = "stageNameColumn";
            this.stageNameColumn.Width = 450;
            
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
            // StageDataGridView
            // 
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delColumn,
            this.stageCodeColumn,
            this.stageNameColumn,
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

        private void SetDataSource(List<StageEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<StageEntity> task = new TaskEventHandler<StageEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.stageCodeColumn.Name].Value = item.StageCode;
                    this.Rows[i].Cells[this.stageCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.stageNameColumn.Name].Value = item.StageName;
                    this.Rows[i].Cells[this.percentColumn.Name].Value = ConvertUtil.ToDouble(item.Percent);
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.STAGE_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<StageEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<StageEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<StageEntity> entityList = new List<StageEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            {
                StageEntity entity = new StageEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.StageCode = ConvertUtil.ToString(item.Cells[this.stageCodeColumn.Name].Value);
                entity.StageName = ConvertUtil.ToString(item.Cells[this.stageNameColumn.Name].Value);
                entity.Percent = ConvertUtil.ToString(item.Cells[this.percentColumn.Name].Value, "0.00");
                entity.ReadOnly = item.Cells[this.stageCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.StageCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
