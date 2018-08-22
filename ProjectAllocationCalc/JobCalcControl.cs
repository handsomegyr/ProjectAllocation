using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using System.IO;
using ProjectAllocationLayout;

namespace ProjectAllocationCalc
{
    public partial class JobCalcControl : UserControl
    {
    
        private JobAllocationCalcEntity jobAllocationCalcEntity = new JobAllocationCalcEntity();
        public JobAllocationCalcEntity JobAllocationCalcEntity
        {
            get{
                jobAllocationCalcEntity.Percent = ConvertUtil.ToDouble(this.txtJobPercent.Value);
                jobAllocationCalcEntity.Worth = ConvertUtil.ToDouble(this.txtJobWorth.Value);
                jobAllocationCalcEntity.WorkerAllocationCalcEntityList = this.dgvWorker.GetWorkerAllocationCalcEntityList();
                
                return jobAllocationCalcEntity;
            }
            set {
                jobAllocationCalcEntity = value;
                InitializeForm(); 
            }

        }

        private WorkerDataGridView dgvWorker;
        private System.Windows.Forms.Panel pnlJobPercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtJobPercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtJobWorth;
        private System.Windows.Forms.Label lblJobWorth;
        private System.Windows.Forms.Label lblJobPercent;
        
        public JobCalcControl()
        {
            InitializeComponent();            
        }


        protected override void OnLoad(EventArgs e)
        {
            InitializeForm();            
        }

        private void InitializeForm()
        {
            this.Font = Constant.ProjectAllocationFont;

            this.txtJobPercent.Value = ConvertUtil.ToDouble(this.jobAllocationCalcEntity.Percent);

            this.txtJobWorth.Value = ConvertUtil.ToDouble(this.jobAllocationCalcEntity.Worth);

            this.dgvWorker.initializeColumn();

            if (this.jobAllocationCalcEntity.WorkerAllocationCalcEntityList != null)
            {
                foreach (var entity in this.jobAllocationCalcEntity.WorkerAllocationCalcEntityList)
                {
                    this.dgvWorker.AddCalcControl(entity);
                }
            }

            this.Worth = this.jobAllocationCalcEntity.Worth / this.jobAllocationCalcEntity.Percent*100;
            
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            string assemblyName = Path.Combine(Application.StartupPath, "Worker.dll");
            IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
            Form objForm = instance.GetSearchDialog(null);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                var objForm1 = objForm as frmBase;
                if (objForm1 != null)
                {
                    foreach (DataGridViewRow item in objForm1.SelectedRows())
                    {
                        WorkerAllocationCalcEntity entity = new WorkerAllocationCalcEntity();
                        entity.WorkerCode = ConvertUtil.ToString(item.Cells["workerCodeColumn"].Value);
                        entity.WorkerName = ConvertUtil.ToString(item.Cells["workerNameColumn"].Value);
                        entity.Percent = ConvertUtil.ToDouble(0.00);
                        entity.Worth = this.txtJobWorth.Value * entity.Percent/100;

                        if (!string.IsNullOrEmpty(entity.WorkerCode))
                        {
                            this.dgvWorker.AddCalcControl(entity);
                            break;
                        }
                    }
                    ;
                }
            }
        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            if (dgvWorker.SelectedRows.Count >0)
            {
                foreach (DataGridViewRow item in dgvWorker.SelectedRows)
                {
                    WorkerAllocationCalcEntity entity = new WorkerAllocationCalcEntity();
                    entity.WorkerCode = ConvertUtil.ToString(item.Cells["workerCodeColumn"].Value);
                    this.dgvWorker.RemoveCalcControl(entity);

                }
            }
        }

        private void toolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {

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
            this.txtJobWorth.Value = Worth * this.txtJobPercent.Value / 100;
            this.dgvWorker.Worth = this.txtJobWorth.Value;
        }

        private void txtJobPercent_TextChanged(object sender, EventArgs e)
        {
            reCalcWorth();
        }
    }
}
