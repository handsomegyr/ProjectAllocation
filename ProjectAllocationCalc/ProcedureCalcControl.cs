using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationFramework;
using ProjectAllocationUtil;
using System.IO;
using ProjectAllocationLayout;

namespace ProjectAllocationCalc
{
    public partial class ProcedureCalcControl : UserControl
    {

        private ProcedureAllocationCalcEntity procedureAllocationCalcEntity = new ProcedureAllocationCalcEntity();
        public ProcedureAllocationCalcEntity ProcedureAllocationCalcEntity
        {
            get{
                procedureAllocationCalcEntity.Percent = ConvertUtil.ToDouble(this.txtProcedurePercent.Value);
                procedureAllocationCalcEntity.Worth = ConvertUtil.ToDouble(this.txtProcedureWorth.Value);
                procedureAllocationCalcEntity.JobAllocationCalcEntityList = this.jobCalcTabControl1.GetJobAllocationCalcEntityList();
                
                return procedureAllocationCalcEntity;
            }
            set {
                procedureAllocationCalcEntity = value;
                InitializeForm();
            }

        }

        private System.Windows.Forms.Panel pnlProcedurePercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtProcedurePercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtProcedureWorth;
        private System.Windows.Forms.Label lblProcedureWorth;
        private System.Windows.Forms.Label lblProcedurePercent;

        private JobCalcTabControl jobCalcTabControl1;

        public ProcedureCalcControl()
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

            this.txtProcedurePercent.Value = ConvertUtil.ToDouble(this.procedureAllocationCalcEntity.Percent);

            this.txtProcedureWorth.Value = ConvertUtil.ToDouble(this.procedureAllocationCalcEntity.Worth);

            if (this.procedureAllocationCalcEntity.JobAllocationCalcEntityList != null)
            {
                foreach (var entity in this.procedureAllocationCalcEntity.JobAllocationCalcEntityList)
                {
                    this.jobCalcTabControl1.AddCalcControl(entity);
                }
            }

            this.Worth = this.procedureAllocationCalcEntity.Worth / this.procedureAllocationCalcEntity.Percent*100;
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            string assemblyName = Path.Combine(Application.StartupPath, "Job.dll");
            IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
            Form objForm = instance.GetSearchDialog(null);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                var objForm1 = objForm as frmBase;
                if (objForm1 != null)
                {
                    foreach (DataGridViewRow item in objForm1.SelectedRows())
                    {
                        JobAllocationCalcEntity entity = new JobAllocationCalcEntity();
                        entity.JobCode = ConvertUtil.ToString(item.Cells["jobCodeColumn"].Value);
                        entity.JobName = ConvertUtil.ToString(item.Cells["jobNameColumn"].Value);
                        entity.Percent = ConvertUtil.ToDouble(item.Cells["percentColumn"].Value);
                        entity.Worth = this.txtProcedureWorth.Value * entity.Percent /100;
                        if (!string.IsNullOrEmpty(entity.JobCode))
                        {
                            this.jobCalcTabControl1.AddCalcControl(entity);
                            break;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            if (jobCalcTabControl1.SelectedTab != null)
            {
                JobAllocationCalcEntity entity = jobCalcTabControl1.SelectedTab.Tag as JobAllocationCalcEntity;
                if (entity != null)
                {
                    this.jobCalcTabControl1.RemoveCalcControl(entity);
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
            this.txtProcedureWorth.Value = Worth * this.txtProcedurePercent.Value / 100;
            this.jobCalcTabControl1.Worth = this.txtProcedureWorth.Value;
        }

        private void txtProcedurePercent_TextChanged(object sender, EventArgs e)
        {
            reCalcWorth();
        }
    }
}
