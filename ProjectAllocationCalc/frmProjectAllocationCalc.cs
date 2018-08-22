using System;
using ProjectAllocationCalc.Model;
using ProjectAllocationUtil;
using System.Windows.Forms;
using ProjectAllocationFramework;
using System.IO;
using ProjectAllocationLayout;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using ProjectAllocationFramework.Command;
using ProjectAllocationCalc.Command;
using ProjectAllocationFramework.Statues;

namespace ProjectAllocationCalc
{
    public partial class frmProjectAllocationCalc : ProjectAllocationLayout.frmBusinessBase
    {

        private ProjectAllocationCalcEntity projectAllocationCalcEntity = new ProjectAllocationCalcEntity();
        public ProjectAllocationCalcEntity ProjectAllocationCalcEntity
        {
            get
            {
                projectAllocationCalcEntity.ProjectCode = this.txtProjectName.Tag.ToString();
                projectAllocationCalcEntity.ProjectName = this.txtProjectName.Text;
                projectAllocationCalcEntity.ProjectDate = this.dateTimePickerProjectDate.Value.Date.ToString("yyyy-MM-dd");
                projectAllocationCalcEntity.Worth = this.txtProjectWorth.Value;

                projectAllocationCalcEntity.WorkerAllocationCalcEntityList = new List<WorkerAllocationCalcEntity>();
                // 主师1                
                if(!string.IsNullOrEmpty(this.txtProjectLeader1.Tag.ToString())){
                    WorkerAllocationCalcEntity worker1 = new WorkerAllocationCalcEntity();
                    worker1.WorkerCode = this.txtProjectLeader1.Tag.ToString();
                    worker1.WorkerName = this.txtProjectLeader1.Text;
                    worker1.Percent = this.txtProjectLeaderPercent1.Value;
                    worker1.Worth = this.txtProjectLeaderWorth1.Value;
                    projectAllocationCalcEntity.WorkerAllocationCalcEntityList.Add(worker1);
                }
                // 主师2
                if (!string.IsNullOrEmpty(this.txtProjectLeader2.Tag.ToString()))
                {
                    WorkerAllocationCalcEntity worker2 = new WorkerAllocationCalcEntity();
                    worker2.WorkerCode = this.txtProjectLeader2.Tag.ToString();
                    worker2.WorkerName = this.txtProjectLeader2.Text;
                    worker2.Percent = this.txtProjectLeaderPercent2.Value;
                    worker2.Worth = this.txtProjectLeaderWorth2.Value;
                    projectAllocationCalcEntity.WorkerAllocationCalcEntityList.Add(worker2);
                }                
                // 阶段
                projectAllocationCalcEntity.StageAllocationCalcEntityList= this.stageCalcTabControl1.GetStageAllocationCalcEntityList();
                return projectAllocationCalcEntity;
            }
            set
            {
                projectAllocationCalcEntity = value;
                SetDataSource(projectAllocationCalcEntity);
            }
        }

        private StageCalcTabControl stageCalcTabControl1;

        public frmProjectAllocationCalc()
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

            // 
            // stageCalcTabControl1
            //
            this.stageCalcTabControl1 = new ProjectAllocationCalc.StageCalcTabControl();
            this.stageCalcTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stageCalcTabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageCalcTabControl1.Location = new System.Drawing.Point(0, 0);
            this.stageCalcTabControl1.Name = "stageCalcTabControl1";
            this.stageCalcTabControl1.SelectedIndex = 0;
            this.stageCalcTabControl1.Size = new System.Drawing.Size(794, 428);
            this.stageCalcTabControl1.TabIndex = 0;

            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.stageCalcTabControl1);
            this.stageCalcTabControl1.BringToFront();

            
            this.tsbExport.Visible = false;

            this.tsbSave.Visible = true;
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new EventHandler(tsbSave_Click);


            this.tsbClear.Click += new EventHandler(tsbClear_Click);
            this.tsbClear.Visible = true;

            this.ContextMenuStrip = this.contextMenuStripStage;


            SetDataSource(this.projectAllocationCalcEntity);

        }

        void tsbSave_Click(object sender, EventArgs e)
        {
            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.ProjectAllocationCalc_SaveMessage, this.Text) == DialogResult.Cancel)
            {
                return;
            }            
            
            CommandBase command = CommandManager.GetCommand(typeof(ProjectAllocationCalcSaveCommand));
            command.OnWorkComplete = Work_RunWorkerCompleted;
            command.OnProgress = OnProgressChanged;
            command.ExecuteAsync(this.ProjectAllocationCalcEntity);

        }

        void tsbClear_Click(object sender, EventArgs e)
        {
            ProjectAllocationCalcEntity projectAllocationCalcEntity = new ProjectAllocationCalcEntity();
            this.ProjectAllocationCalcEntity = projectAllocationCalcEntity;

        }
        private void Work_RunWorkerCompleted(object sender, WorkerCompletedEventArgs e)
        {
            if (e.HasError)
            {
                return;
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            string assemblyName = Path.Combine(Application.StartupPath, "Project.dll");
            IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
            Form objForm= instance.GetSearchDialog(null);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                var objForm1 = objForm as frmBase;
                if (objForm1 != null)
                {
                    foreach (DataGridViewRow item in objForm1.SelectedRows())
                    { 
                        ProjectEntity entity = new ProjectEntity();
                        entity.ProjectCode = ConvertUtil.ToString(item.Cells["projectCodeColumn"].Value);
                        entity.ProjectName = ConvertUtil.ToString(item.Cells["projectNameColumn"].Value);
                        
                        if (!string.IsNullOrEmpty(entity.ProjectCode))
                        {
                            this.txtProjectName.Text = entity.ProjectName;
                            this.txtProjectName.Tag = entity.ProjectCode;

                            // 查询该项目的计算产值记录
                            ProjectAllocationCalcManager manager = new ProjectAllocationCalcManager();
                            ProjectAllocationCalcEntity projectAllocationCalcEntity = manager.GetProjectAllocationCalcEntity(OnProgressChanged, entity.ProjectCode);

                            // 如果没有找到的话
                            if (projectAllocationCalcEntity == null)
                            {
                                projectAllocationCalcEntity = new ProjectAllocationCalcEntity();
                                projectAllocationCalcEntity.ProjectCode = entity.ProjectCode;
                                projectAllocationCalcEntity.ProjectName = entity.ProjectName;
                                projectAllocationCalcEntity.Worth = 0.0;
                            }
                            this.ProjectAllocationCalcEntity = projectAllocationCalcEntity;
                            break;
                        }
                    }
                }
            }

        }

        private void toolStripMenuItemAddStage_Click(object sender, EventArgs e)
        {
            string assemblyName = Path.Combine(Application.StartupPath, "Stage.dll");
            IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
            Form objForm = instance.GetSearchDialog(null);
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                var objForm1 = objForm as frmBase;
                if (objForm1 != null)
                {
                    foreach (DataGridViewRow item in objForm1.SelectedRows())
                    {
                        StageAllocationCalcEntity entity = new StageAllocationCalcEntity();
                        entity.StageCode = ConvertUtil.ToString(item.Cells["stageCodeColumn"].Value);
                        entity.StageName = ConvertUtil.ToString(item.Cells["stageNameColumn"].Value);
                        entity.Percent = ConvertUtil.ToDouble(item.Cells["percentColumn"].Value);
                        entity.Worth = stageCalcTabControl1.Worth * entity.Percent/100;

                        if (!string.IsNullOrEmpty(entity.StageCode))
                        {
                            this.stageCalcTabControl1.AddCalcControl(entity);
                            break;
                        }
                    }
                }
            }
        }

        private void toolStripMenuItemDeleteStage_Click(object sender, EventArgs e)
        {
            if (stageCalcTabControl1.SelectedTab != null)
            {
                StageAllocationCalcEntity entity = stageCalcTabControl1.SelectedTab.Tag as StageAllocationCalcEntity;
                if (entity != null)
                {
                    this.stageCalcTabControl1.RemoveCalcControl(entity);
                }
            }
        }

        private void toolStripMenuItemRefresh_Click(object sender, EventArgs e)
        {
            //List<StageAllocationCalcEntity> stageAllocationCalcEntityList= this.stageCalcTabControl1.GetStageAllocationCalcEntityList();
        }

        private void btnProjectLeader1_Click(object sender, EventArgs e)
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
                        WorkerEntity entity = new WorkerEntity();
                        entity.WorkerCode = ConvertUtil.ToString(item.Cells["workerCodeColumn"].Value);
                        entity.WorkerName = ConvertUtil.ToString(item.Cells["workerNameColumn"].Value);
                        
                        if (!string.IsNullOrEmpty(entity.WorkerCode))
                        {
                            this.txtProjectLeader1.Text = entity.WorkerName;
                            this.txtProjectLeader1.Tag = entity.WorkerCode;
                            break;
                        }
                    }
                }
            }
        }

        private void btnProjectLeader2_Click(object sender, EventArgs e)
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
                        WorkerEntity entity = new WorkerEntity();
                        entity.WorkerCode = ConvertUtil.ToString(item.Cells["workerCodeColumn"].Value);
                        entity.WorkerName = ConvertUtil.ToString(item.Cells["workerNameColumn"].Value);

                        if (!string.IsNullOrEmpty(entity.WorkerCode))
                        {
                            this.txtProjectLeader2.Text = entity.WorkerName;
                            this.txtProjectLeader2.Tag = entity.WorkerCode;
                            break;
                        }
                    }
                }
            }
        }

        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.PROJECTALLOCATIONCALC_SEARCH:
                    //SetDataSource(Core.CoreData[e.Key] as List<ProjectAllocationCalcEntity>);
                    break;

                default:
                    break;
            }
        }

        private void SetDataSource(ProjectAllocationCalcEntity projectAllocationCalcEntity)
        {          

            this.txtProjectName.Tag = "";
            this.txtProjectName.Text = "";
            this.dateTimePickerProjectDate.Value = System.DateTime.Now;
            this.btnProject.Enabled = true;

            clearWorker1();
            clearWorker2();
            
            this.stageCalcTabControl1.Clear();
            txtProjectWorth.Value = 0.00;

            this.txtProjectName.Tag = projectAllocationCalcEntity.ProjectCode;
            this.txtProjectName.Text = projectAllocationCalcEntity.ProjectName;
            if (!string.IsNullOrEmpty(projectAllocationCalcEntity.ProjectDate))
            {
                this.dateTimePickerProjectDate.Value = Convert.ToDateTime(projectAllocationCalcEntity.ProjectDate);
            }
            this.btnProject.Enabled = string.IsNullOrEmpty(projectAllocationCalcEntity.ProjectCode);

            if (projectAllocationCalcEntity.WorkerAllocationCalcEntityList!=null)
            {
                var i = 0;
                foreach (WorkerAllocationCalcEntity worker in projectAllocationCalcEntity.WorkerAllocationCalcEntityList)
                {
                    if (i == 0)
                    {
                        this.txtProjectLeader1.Tag = worker.WorkerCode;
                        this.txtProjectLeader1.Text = worker.WorkerName;
                        this.txtProjectLeaderPercent1.Value = worker.Percent;
                        this.txtProjectLeaderWorth1.Value = worker.Worth;
                    }
                    else if (i == 1)
                    {
                        this.txtProjectLeader2.Tag = worker.WorkerCode;
                        this.txtProjectLeader2.Text = worker.WorkerName;
                        this.txtProjectLeaderPercent2.Value = worker.Percent;
                        this.txtProjectLeaderWorth2.Value = worker.Worth;
                    }
                    i++;
                }
            }

            
            if (projectAllocationCalcEntity.StageAllocationCalcEntityList != null)
            {
                foreach (StageAllocationCalcEntity entity in projectAllocationCalcEntity.StageAllocationCalcEntityList)
                {
                    this.stageCalcTabControl1.AddCalcControl(entity);
                }
            }

            txtProjectWorth.Value = projectAllocationCalcEntity.Worth;
             
        }

        private void txtProjectWorth_TextChanged(object sender, EventArgs e)
        {
            // 重新计算
            reCalcWorth();
        }

        private void reCalcWorth()
        {
            // 主师1的产值
            txtProjectLeaderWorth1.Value = txtProjectWorth.Value * txtProjectLeaderPercent1.Value / 100;

            // 主师2的产值
            txtProjectLeaderWorth2.Value = txtProjectWorth.Value * txtProjectLeaderPercent2.Value / 100;

            // 阶段总价值
            stageCalcTabControl1.Worth = txtProjectWorth.Value - txtProjectLeaderWorth1.Value - txtProjectLeaderWorth2.Value;
        }

        private void txtProjectLeaderPercent1_TextChanged(object sender, EventArgs e)
        {
            reCalcWorth();
        }

        private void txtProjectLeaderPercent2_TextChanged(object sender, EventArgs e)
        {
            reCalcWorth();
        }

        private void toolStripMenuItemDeleteWorker1_Click(object sender, EventArgs e)
        {
            clearWorker1();
        }

        private void toolStripMenuItemDeleteWorker2_Click(object sender, EventArgs e)
        {
            clearWorker2();
        }

        private void clearWorker1()
        {
            this.txtProjectLeader1.Tag = "";
            this.txtProjectLeader1.Text = "";
            this.txtProjectLeaderPercent1.Value = 0.00;
            this.txtProjectLeaderWorth1.Value = 0.00;
        }

        private void clearWorker2()
        {
            this.txtProjectLeader2.Tag = "";
            this.txtProjectLeader2.Text = "";
            this.txtProjectLeaderPercent2.Value = 0.00;
            this.txtProjectLeaderWorth2.Value = 0.00;
        }
    }
}
