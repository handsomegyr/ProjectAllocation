using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ProjectAllocationBusiness;
using ProjectAllocationFramework;
using System.Windows.Forms;

namespace ProjectAllocationCalc
{
    public partial class StageCalcTabControl : TabControl
    {
        private int i=0;

        private Dictionary<string, StageAllocationCalcEntity> stageAllocationCalcEntityList = new Dictionary<string, StageAllocationCalcEntity>();

        private Dictionary<string, TabPage> myDictionary = new Dictionary<string, TabPage>(); 
                
        public StageCalcTabControl()
        {
            InitializeComponent();
            Initialize();
        }

        public StageCalcTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }
        

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            //// 
            //// tpAddStage
            //// 
            //var tpAddStage = new System.Windows.Forms.TabPage();
            //tpAddStage.Location = new System.Drawing.Point(4, 22);
            //tpAddStage.Name = "tpAddStage";
            //tpAddStage.Padding = new System.Windows.Forms.Padding(3);
            //tpAddStage.Size = new System.Drawing.Size(778, 418);
            //tpAddStage.TabIndex = 0;
            //tpAddStage.Text = "添加";
            //tpAddStage.UseVisualStyleBackColor = true;
            //this.Controls.Add(tpAddStage);

            foreach (var stage in this.stageAllocationCalcEntityList)
            {
                this.AddCalcControl(stage.Value);
            }

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "tcStage";
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

        public void AddCalcControl(StageAllocationCalcEntity stage)
        {
            if (!this.stageAllocationCalcEntityList.ContainsKey(stage.StageCode))
            {
                this.stageAllocationCalcEntityList.Add(stage.StageCode,stage);
                // 
                // stageCalcControl
                // 
                var stageCalcControl = new ProjectAllocationCalc.StageCalcControl();
                stageCalcControl.StageAllocationCalcEntity = stage;
                stageCalcControl.Dock = System.Windows.Forms.DockStyle.Fill;
                stageCalcControl.Location = new System.Drawing.Point(3, 3);
                stageCalcControl.Name = "stageCalcControl" + this.i.ToString();
                stageCalcControl.Size = new System.Drawing.Size(772, 412);
                stageCalcControl.TabIndex = 1;

                // 
                // tpStage
                // 
                var tpStage = new System.Windows.Forms.TabPage();
                tpStage.Controls.Add(stageCalcControl);
                tpStage.Location = new System.Drawing.Point(4, 22);
                tpStage.Name = "tpStage" + this.i.ToString();
                tpStage.Padding = new System.Windows.Forms.Padding(3);
                tpStage.Size = new System.Drawing.Size(778, 418);
                tpStage.TabIndex = 0;
                tpStage.Text = stage.StageName;
                tpStage.UseVisualStyleBackColor = true;
                tpStage.Tag = stage;
                
                // 
                // tcStage
                // 
                this.Controls.Add(tpStage);
                this.SelectedTab = tpStage;
                myDictionary.Add(stage.StageCode, tpStage);
                this.i++;
            }            
        }

        public void RemoveCalcControl(StageAllocationCalcEntity stage)
        {
            if (this.stageAllocationCalcEntityList.ContainsKey(stage.StageCode))
            {
                this.stageAllocationCalcEntityList.Remove(stage.StageCode);

                if(myDictionary.ContainsKey(stage.StageCode)) 
　　            { 
　　　　            var tpStage = myDictionary[stage.StageCode];
                    // 
                    // tcStage
                    // 
                    this.Controls.Remove(tpStage);
                    //this.SelectedTab = tpStage;
                    myDictionary.Remove(stage.StageCode);
　　            } 
                
            }

        }

        public List<StageAllocationCalcEntity> GetStageAllocationCalcEntityList()
        {
            List<StageAllocationCalcEntity> list = new List<StageAllocationCalcEntity>();
            foreach (var stage in this.myDictionary)
            {
                var tpStage = stage.Value;

                foreach (var c in tpStage.Controls)
                {
                    var stageCalcControl = c as StageCalcControl;
                    if (stageCalcControl != null)
                    {
                        list.Add(stageCalcControl.StageAllocationCalcEntity);                        
                    }
                }
            }
            return list;
        }

        private double worth = 0.0;
        public double Worth {
            get
            {
                return worth;
            }
            
            set{
                worth = value;
                reCalcWorth();
            } 
        }

        private void reCalcWorth()
        {
            foreach (var stage in this.myDictionary)
            {
                var tpStage = stage.Value;

                foreach (var c in tpStage.Controls)
                {
                    var stageCalcControl = c as StageCalcControl;
                    if (stageCalcControl != null)
                    {
                        stageCalcControl.Worth = this.Worth;
                    }
                }
            }
        }

        public void Clear()
        {
            var dic = this.myDictionary.Values.ToList<TabPage>();
            foreach (var stage in dic)
            {
                var stage1 = stage.Tag as StageAllocationCalcEntity;
                RemoveCalcControl(stage1);
            }
        }
    }
}
