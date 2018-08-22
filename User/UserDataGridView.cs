using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace User
{
    public partial class UserDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private DataGridViewCheckBoxColumn delColumn;
        private DataGridViewTextBoxColumn userCodeColumn;
        private DataGridViewTextBoxColumn userNameColumn;
        private DataGridViewTextBoxColumn passwordColumn;

        public UserDataGridView()
        {
            InitializeComponent();
            Initialize();

        }

        public UserDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.delColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();

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
            // userCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.userCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.userCodeColumn.HeaderText = "用户帐号";
            this.userCodeColumn.MaxInputLength = 10;
            this.userCodeColumn.Name = "userCodeColumn";
            this.userCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // userNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.userNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.userNameColumn.HeaderText = "用户名";
            this.userNameColumn.MaxInputLength = 30;
            this.userNameColumn.Name = "userNameColumn";
            this.userNameColumn.Width = 450;
            // 
            // passwordColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.passwordColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.passwordColumn.HeaderText = "密码";
            this.passwordColumn.MaxInputLength = 20;
            this.passwordColumn.Name = "passwordColumn";
            this.passwordColumn.Width = 200;

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
            this.userCodeColumn,
            this.userNameColumn,
            this.passwordColumn});
        }

        private delegate void TaskEventHandler<T>(List<T> dataSource);

        private void SetDataSource(List<UserEntity> entityList)
        {
            if (this.InvokeRequired)
            {
                TaskEventHandler<UserEntity> task = new TaskEventHandler<UserEntity>(SetDataSource);
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
                    this.Rows[i].Cells[this.userCodeColumn.Name].Value = item.UserCode;
                    this.Rows[i].Cells[this.userCodeColumn.Name].ReadOnly = item.ReadOnly;
                    this.Rows[i].Cells[this.userNameColumn.Name].Value = item.UserName;
                    this.Rows[i].Cells[this.passwordColumn.Name].Value = item.Password;
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.USER_SEARCH:
                    SetDataSource(Core.CoreData[e.Key] as List<UserEntity>);

                    break;

                default:
                    break;
            }
        }


        public List<UserEntity> GetData(params object[] paras)
        {
            this.EndEdit();
            List<UserEntity> entityList = new List<UserEntity>();
            int rowIdx = 1;
            foreach (DataGridViewRow item in this.Rows)
            { 
                UserEntity entity = new UserEntity();
                entity.Del = ConvertUtil.ToBoolean(item.Cells[this.delColumn.Name].Value);
                entity.UserCode = ConvertUtil.ToString(item.Cells[this.userCodeColumn.Name].Value);
                entity.UserName = ConvertUtil.ToString(item.Cells[this.userNameColumn.Name].Value);
                entity.Password = ConvertUtil.ToString(item.Cells[this.passwordColumn.Name].Value);
                entity.ReadOnly = item.Cells[this.userCodeColumn.Name].ReadOnly;
                entity.Row = rowIdx;
                rowIdx++;
                if (!string.IsNullOrEmpty(entity.UserCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }
    }
}
