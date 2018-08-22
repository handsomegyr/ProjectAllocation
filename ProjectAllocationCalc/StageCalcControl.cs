using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;
using System.IO;
using ProjectAllocationLayout;

namespace ProjectAllocationCalc
{
    public partial class StageCalcControl : UserControl
    {
        private StageAllocationCalcEntity stageAllocationCalcEntity = new StageAllocationCalcEntity();
        public StageAllocationCalcEntity StageAllocationCalcEntity
        {
            get{
                stageAllocationCalcEntity.Percent =  ConvertUtil.ToDouble(this.txtStagePercent.Value);
                stageAllocationCalcEntity.Worth = ConvertUtil.ToDouble(this.txtStageWorth.Value);
                stageAllocationCalcEntity.ProcedureAllocationCalcEntityList = this.procedureCalcTabControl1.GetProcedureAllocationCalcEntityList();
                return stageAllocationCalcEntity;
            }
            set {
                stageAllocationCalcEntity = value;
                InitializeForm();
            }

        }

        public StageCalcControl()
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

            this.txtStagePercent.Value = ConvertUtil.ToDouble(this.stageAllocationCalcEntity.Percent);
            this.txtStageWorth.Value = ConvertUtil.ToDouble(this.stageAllocationCalcEntity.Worth);
            if (this.stageAllocationCalcEntity.ProcedureAllocationCalcEntityList != null)
            {
                foreach (var entity in this.stageAllocationCalcEntity.ProcedureAllocationCalcEntityList)
                {
                    this.procedureCalcTabControl1.AddCalcControl(entity);
                }
            }
            this.Worth = this.stageAllocationCalcEntity.Worth / this.stageAllocationCalcEntity.Percent*100;
            
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            string assemblyName = Path.Combine(Application.StartupPath, "Procedure.dll");
            IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
            Form objForm = instance.GetSearchDialog(null);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                var objForm1 = objForm as frmBase;
                if (objForm1 != null)
                {
                    foreach (DataGridViewRow item in objForm1.SelectedRows())
                    {
                        ProcedureAllocationCalcEntity entity = new ProcedureAllocationCalcEntity();
                        entity.ProcedureCode = ConvertUtil.ToString(item.Cells["procedureCodeColumn"].Value);
                        entity.ProcedureName = ConvertUtil.ToString(item.Cells["procedureNameColumn"].Value);
                        entity.Percent = ConvertUtil.ToDouble(item.Cells["percentColumn"].Value);
                        entity.Worth = this.txtStageWorth.Value * entity.Percent/100;
                        if (!string.IsNullOrEmpty(entity.ProcedureCode))
                        {
                            this.procedureCalcTabControl1.AddCalcControl(entity);
                            break;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            if (procedureCalcTabControl1.SelectedTab != null)
            {
                ProcedureAllocationCalcEntity entity = procedureCalcTabControl1.SelectedTab.Tag as ProcedureAllocationCalcEntity;
                if (entity != null)
                {
                    this.procedureCalcTabControl1.RemoveCalcControl(entity);
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
            this.txtStageWorth.Value = Worth * this.txtStagePercent.Value / 100;
            this.procedureCalcTabControl1.Worth = this.txtStageWorth.Value;
        }

        private void txtStagePercent_TextChanged(object sender, EventArgs e)
        {
            reCalcWorth();
        }
    }
}
