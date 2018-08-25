using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using System;

namespace ProjectAllocationCalc
{
    public partial class WorkerDataGridView : ProjectAllocationLayout.MasterDataGridView
    {
        private Dictionary<string, WorkerAllocationCalcEntity> workerAllocationCalcEntityList = new Dictionary<string, WorkerAllocationCalcEntity>();
        private Dictionary<string, DataGridViewRow> myDictionary = new Dictionary<string, DataGridViewRow>();
        
        private DataGridViewButtonColumn operationColumn;
        private DataGridViewTextBoxColumn workerCodeColumn;
        private DataGridViewTextBoxColumn workerNameColumn;
        private DataGridViewTextBoxColumn percentColumn;
        private DataGridViewTextBoxColumn workerWorthColumn;
        

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

            this.operationColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.workerCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerWorthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
           
            // 
            // operationColumn
            // 
            this.operationColumn.HeaderText = "";
            //this.operationColumn.MinimumWidth = 60;
            this.operationColumn.ReadOnly = true;
            this.operationColumn.Name = "operationColumn";
            this.operationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.operationColumn.ToolTipText = "";
            this.operationColumn.Width = 20;
            this.operationColumn.ValueType = typeof(string);
            // 
            // workerCodeColumn
            // 
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.workerCodeColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone(); ;
            this.workerCodeColumn.HeaderText = "员工码";
            this.workerCodeColumn.MaxInputLength = 10;
            this.workerCodeColumn.Name = "workerCodeColumn";
            //this.workerCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.workerCodeColumn.Width = 50;
            // 
            // workerNameColumn
            // 
            //dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.workerNameColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4String.Clone();
            this.workerNameColumn.HeaderText = "员工名";
            this.workerNameColumn.MaxInputLength = 30;
            this.workerNameColumn.Name = "workerNameColumn";
            this.workerNameColumn.Width = 400;
            
            // 
            // percentColumn
            // 
            this.percentColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4Double.Clone();
            this.percentColumn.HeaderText = "所占比例(%)";
            this.percentColumn.MaxInputLength = 15;
            this.percentColumn.Name = "percentColumn";
            this.percentColumn.Width = 100;
            this.percentColumn.ValueType = typeof(double);

            // 
            // workerWorthColumn
            // 
            this.workerWorthColumn.DefaultCellStyle = ProjectAllocationFramework.DataGridViewCellStyle.DataGridViewCellStyle4Double.Clone();
            this.workerWorthColumn.HeaderText = "个人产值(元)";
            this.workerWorthColumn.MaxInputLength = 15;
            this.workerWorthColumn.Name = "workerWorthColumn";
            this.workerWorthColumn.Width = 300;
            this.workerWorthColumn.ValueType = typeof(double);

            this.RowTemplate.Height = 27;

            this.AllowUserToResizeColumns = true;
            this.AllowUserToResizeRows = false;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.EnableHeadersVisualStyles = false;
            this.ReadOnly = false;
            //this.RowHeadersVisible = false;
            this.RowHeadersWidth = 10;
            //this.RowTemplate.Height = 23;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect;
            this.ShowCellErrors = false;
            this.ShowCellToolTips = false;
            this.ShowEditingIcon = false;
            this.ShowRowErrors = false;

            
            initializeColumn();

        }


        public void initializeColumn()
        {
            // 
            // WorkerDataGridView
            // 
            this.Columns.Clear();
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.operationColumn,
            this.workerCodeColumn,
            this.workerNameColumn,
            this.percentColumn,
            this.workerWorthColumn});

            this.Columns[this.percentColumn.Name].DefaultCellStyle.Tag = "0|100";

            this.Clear();
            this.workerAllocationCalcEntityList.Clear();
            this.myDictionary.Clear();
        }


        public void AddCalcControl(WorkerAllocationCalcEntity worker)
        {
            if (!this.workerAllocationCalcEntityList.ContainsKey(worker.WorkerCode))
            {
                this.workerAllocationCalcEntityList.Add(worker.WorkerCode, worker);

                int i = this.Rows.Add();
                this.Rows[i].Cells[this.operationColumn.Name].Value = "R";
                this.Rows[i].Cells[this.operationColumn.Name].ToolTipText = "移除";
                this.Rows[i].Cells[this.operationColumn.Name].ReadOnly = false;
                this.Rows[i].Cells[this.workerCodeColumn.Name].Value = worker.WorkerCode;
                this.Rows[i].Cells[this.workerCodeColumn.Name].ReadOnly = true;
                this.Rows[i].Cells[this.workerNameColumn.Name].Value = worker.WorkerName;
                this.Rows[i].Cells[this.workerNameColumn.Name].ReadOnly = true;
                this.Rows[i].Cells[this.percentColumn.Name].Value = ConvertUtil.ToDouble(worker.Percent);
                this.Rows[i].Cells[this.workerWorthColumn.Name].Value = ConvertUtil.ToDouble(worker.Worth);
                this.Rows[i].Cells[this.workerWorthColumn.Name].ReadOnly = true;
                myDictionary.Add(worker.WorkerCode, this.Rows[i]);
            }
        }

        public void RemoveCalcControl(WorkerAllocationCalcEntity worker)
        {
            if (this.workerAllocationCalcEntityList.ContainsKey(worker.WorkerCode))
            {
                this.workerAllocationCalcEntityList.Remove(worker.WorkerCode);
                
                if (myDictionary.ContainsKey(worker.WorkerCode))
                {
                    this.Rows.Remove(myDictionary[worker.WorkerCode]);
                    myDictionary.Remove(worker.WorkerCode);
                }

            }

        }

        public List<WorkerAllocationCalcEntity> GetWorkerAllocationCalcEntityList()
        {
            this.EndEdit();
            List<WorkerAllocationCalcEntity> entityList = new List<WorkerAllocationCalcEntity>();

            foreach (DataGridViewRow item in this.Rows)
            {
                WorkerAllocationCalcEntity entity = new WorkerAllocationCalcEntity();
                //entity.Del = ConvertUtil.ToBoolean(item.Cells[this.operationColumn.Name].Value);
                entity.WorkerCode = ConvertUtil.ToString(item.Cells[this.workerCodeColumn.Name].Value);
                entity.WorkerName = ConvertUtil.ToString(item.Cells[this.workerNameColumn.Name].Value);
                entity.Percent = ConvertUtil.ToDouble(item.Cells[this.percentColumn.Name].Value);
                entity.Worth = ConvertUtil.ToDouble(item.Cells[this.workerWorthColumn.Name].Value);
                if (!string.IsNullOrEmpty(entity.WorkerCode))
                {
                    entityList.Add(entity);
                }
            }
            return entityList;
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {

            base.OnCellClick(e);

            if (!dataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
            {
                return;
            }
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                return;
            }
            if(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "R")
            {
                WorkerAllocationCalcEntity worker = new WorkerAllocationCalcEntity();
                worker.WorkerCode = ConvertUtil.ToString(this.Rows[e.RowIndex].Cells[this.workerCodeColumn.Name].Value);
                this.RemoveCalcControl(worker);
            }

            
        }

        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {

            base.OnCellValueChanged(e);
            if (!dataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
            {
                return;
            }
            //if (this.Columns[e.ColumnIndex].Name == this.percentColumn.Name)
            //{
            //    var dblValue = ConvertUtil.ToDouble(this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            //    if (dblValue < 0 || dblValue > 100)
            //    {
            //        return;
            //    }
            //}
            // 重新计算
            reCalcWorth();            
            
        }
        
        protected override void OnCellValidating(DataGridViewCellValidatingEventArgs e)
        {
            base.OnCellValidating(e);

            if (!dataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
            {
                return;
            }

            //if (this.Columns[e.ColumnIndex].Name == this.percentColumn.Name)
            //{
            //    double dblRet = 0.0;
            //    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
            //    {
            //        if (!double.TryParse(e.FormattedValue.ToString(), out dblRet))
            //        {
            //            e.Cancel = true;

            //            this.CancelEdit();
            //            //MessageBox.Show("请输入数字或小数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //        }
            //        if (dblRet < 0 || dblRet > 100)
            //        {
            //            e.Cancel = true;
            //            this.CancelEdit();
            //            //MessageBox.Show("请输入数字或小数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //            //e.FormattedValue = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //        }
            //    }
            //}

        }

        private double worth = 0.0;
        public double Worth
        {
            get
            {
                return worth;
            }

            set
            {
                worth = value;
                reCalcWorth();
            }
        }

        private void reCalcWorth()
        { 

            foreach (DataGridViewRow item in this.Rows)
            {
                item.Cells[this.workerWorthColumn.Name].Value = this.worth * ConvertUtil.ToDouble(item.Cells[this.percentColumn.Name].Value) / 100;
                
            }
        }

        private bool dataGridViewIsOperated(int intRowIndex,int intColumnIndex)
        {
            bool blnIsOperated = false;
            if(intRowIndex == -1 || intColumnIndex == -1){

                return blnIsOperated;
            }
            if(this.Columns[intColumnIndex].ReadOnly == false || this.Rows[intRowIndex].Cells[intColumnIndex].ReadOnly == false )
            {
                blnIsOperated = true;
            }
            return blnIsOperated;

        }
    }
}
