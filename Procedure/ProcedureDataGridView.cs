using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace Procedure
{
    public partial class ProcedureDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn procedureCodeColumn;
        private DataGridViewTextBoxColumn procedureNameColumn;
        private DataGridViewTextBoxColumn percentColumn;

        public ProcedureDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public ProcedureDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.procedureCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedureNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // procedureCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.procedureCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.procedureCodeColumn.HeaderText = "专业码";
            this.procedureCodeColumn.MaxInputLength = 10;
            this.procedureCodeColumn.Name = "procedureCodeColumn";
            this.procedureCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // procedureNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.procedureNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.procedureNameColumn.HeaderText = "专业名";
            this.procedureNameColumn.MaxInputLength = 30;
            this.procedureNameColumn.Name = "procedureNameColumn";
            this.procedureNameColumn.Width = 450;
            
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
            // ProcedureDataGridView
            // 
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delColumn,
            this.procedureCodeColumn,
            this.procedureNameColumn,
            this.percentColumn});


            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Columns[this.procedureCodeColumn.Name].DefaultCellStyle.Tag = C_RegularExpressions_A_Za_z0_9;
            this.Columns[this.procedureNameColumn.Name].DefaultCellStyle.Tag = C_RegularExpressions_A_Za_z0_9Chinese;
            this.Columns[this.percentColumn.Name].DefaultCellStyle.Tag = "0|100";

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

        private void SetDataSource(List<ProcedureEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<ProcedureEntity> task = new TaskEventHandler<ProcedureEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.procedureCodeColumn.Name].Value = item.ProcedureCode;
                    this.Rows[i].Cells[this.procedureCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.procedureNameColumn.Name].Value = item.ProcedureName;
                    this.Rows[i].Cells[this.percentColumn.Name].Value = ConvertUtil.ToDouble(item.Percent);
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.PROCEDURE_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<ProcedureEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<ProcedureEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<ProcedureEntity> entityList = new List<ProcedureEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            {
                ProcedureEntity entity = new ProcedureEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.ProcedureCode = ConvertUtil.ToString(item.Cells[this.procedureCodeColumn.Name].Value);
                entity.ProcedureName = ConvertUtil.ToString(item.Cells[this.procedureNameColumn.Name].Value);
                entity.Percent = ConvertUtil.ToString(item.Cells[this.percentColumn.Name].Value, "0.00");
                entity.ReadOnly = item.Cells[this.procedureCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.ProcedureCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
