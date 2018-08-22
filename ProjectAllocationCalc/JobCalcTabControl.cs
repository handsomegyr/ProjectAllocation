using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjectAllocationFramework;
using System.Windows.Forms;
using ProjectAllocationBusiness;
using ProjectAllocationUtil;

namespace ProjectAllocationCalc
{
    public partial class JobCalcTabControl : TabControl
    {        

        private int i=0;

        private Dictionary<string, JobAllocationCalcEntity> jobAllocationCalcEntityList = new Dictionary<string, JobAllocationCalcEntity>();

        private Dictionary<string, TabPage> myDictionary = new Dictionary<string, TabPage>(); 
                
        public JobCalcTabControl()
        {
            InitializeComponent();
            Initialize();
        }

        public JobCalcTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }
        

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            //// 
            //// tpAddJob
            //// 
            //var tpAddJob = new System.Windows.Forms.TabPage();
            //tpAddJob.Location = new System.Drawing.Point(4, 22);
            //tpAddJob.Name = "tpAddJob";
            //tpAddJob.Padding = new System.Windows.Forms.Padding(3);
            //tpAddJob.Size = new System.Drawing.Size(778, 418);
            //tpAddJob.TabIndex = 0;
            //tpAddJob.Text = "添加";
            //tpAddJob.UseVisualStyleBackColor = true;
            //this.Controls.Add(tpAddJob);

            foreach (var job in this.jobAllocationCalcEntityList)
            {
                this.AddCalcControl(job.Value);
            }

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "tcJob";
            this.SelectedIndex = 0;
            this.Size = new System.Drawing.Size(786, 444);
            this.TabIndex = 0;


        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
        }

        protected override void OnSelected(TabControlEventArgs e)
        {
            base.OnSelected(e);
        }

        public void AddCalcControl(JobAllocationCalcEntity job)
        {
            if (!this.jobAllocationCalcEntityList.ContainsKey(job.JobCode))
            {
                this.jobAllocationCalcEntityList.Add(job.JobCode,job);
                // 
                // jobCalcControl
                // 
                var jobCalcControl = new ProjectAllocationCalc.JobCalcControl();
                jobCalcControl.JobAllocationCalcEntity = job;
                jobCalcControl.Dock = System.Windows.Forms.DockStyle.Fill;
                jobCalcControl.Location = new System.Drawing.Point(3, 3);
                jobCalcControl.Name = "jobCalcControl" + this.i.ToString();
                jobCalcControl.Size = new System.Drawing.Size(772, 412);
                jobCalcControl.TabIndex = 1;

                // 
                // tpJob
                // 
                var tpJob = new System.Windows.Forms.TabPage();
                tpJob.Controls.Add(jobCalcControl);
                tpJob.Location = new System.Drawing.Point(4, 22);
                tpJob.Name = "tpJob" + this.i.ToString();
                tpJob.Padding = new System.Windows.Forms.Padding(3);
                tpJob.Size = new System.Drawing.Size(778, 418);
                tpJob.TabIndex = 0;
                tpJob.Text = job.JobName;
                tpJob.UseVisualStyleBackColor = true;
                tpJob.Tag = job;
                
                // 
                // tcJob
                // 
                this.Controls.Add(tpJob);
                this.SelectedTab = tpJob;
                myDictionary.Add(job.JobCode, tpJob);
                this.i++;
            }            
        }

        public void RemoveCalcControl(JobAllocationCalcEntity job)
        {
            if (this.jobAllocationCalcEntityList.ContainsKey(job.JobCode))
            {
                this.jobAllocationCalcEntityList.Remove(job.JobCode);

                if(myDictionary.ContainsKey(job.JobCode)) 
　　            { 
　　　　            var tpJob = myDictionary[job.JobCode];
                    // 
                    // tcJob
                    // 
                    this.Controls.Remove(tpJob);
                    //this.SelectedTab = tpJob;
                    myDictionary.Remove(job.JobCode);
　　            } 
                
            }

        }

        public List<JobAllocationCalcEntity> GetJobAllocationCalcEntityList()
        {
            List<JobAllocationCalcEntity> list = new List<JobAllocationCalcEntity>();
            foreach (var job in this.myDictionary)
            {
                var tpJob = job.Value;

                foreach (var c in tpJob.Controls)
                {
                    var jobCalcControl = c as JobCalcControl;
                    if (jobCalcControl != null)
                    {
                        list.Add(jobCalcControl.JobAllocationCalcEntity);                        
                    }
                }
            }
            return list;
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
            
            foreach (var job in this.myDictionary)
            {
                var tpJob = job.Value;

                foreach (var c in tpJob.Controls)
                {
                    var jobCalcControl = c as JobCalcControl;
                    if (jobCalcControl != null)
                    {
                        jobCalcControl.Worth = this.Worth;
                    }
                }
            }
        }
    }
}
