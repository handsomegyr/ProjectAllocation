using System.Collections.Generic;
using System.ComponentModel;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using System.Windows.Forms;

namespace ProjectAllocationCalc
{
    public partial class ProcedureCalcTabControl : TabControl
    {       
        
        private int i=0;

        private Dictionary<string, ProcedureAllocationCalcEntity> procedureAllocationCalcEntityList = new Dictionary<string, ProcedureAllocationCalcEntity>();

        private Dictionary<string, TabPage> myDictionary = new Dictionary<string, TabPage>(); 
                
        public ProcedureCalcTabControl()
        {
            InitializeComponent();
            Initialize();
        }

        public ProcedureCalcTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Initialize();
        }
        

        private void Initialize()
        {
            this.Font = Constant.ProjectAllocationFont;

            //// 
            //// tpAddProcedure
            //// 
            //var tpAddProcedure = new System.Windows.Forms.TabPage();
            //tpAddProcedure.Location = new System.Drawing.Point(4, 22);
            //tpAddProcedure.Name = "tpAddProcedure";
            //tpAddProcedure.Padding = new System.Windows.Forms.Padding(3);
            //tpAddProcedure.Size = new System.Drawing.Size(778, 418);
            //tpAddProcedure.TabIndex = 0;
            //tpAddProcedure.Text = "添加";
            //tpAddProcedure.UseVisualStyleBackColor = true;
            //this.Controls.Add(tpAddProcedure);

            foreach (var procedure in this.procedureAllocationCalcEntityList)
            {
                this.AddCalcControl(procedure.Value);
            }

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "tcProcedure";
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

        public void AddCalcControl(ProcedureAllocationCalcEntity procedure)
        {
            if (!this.procedureAllocationCalcEntityList.ContainsKey(procedure.ProcedureCode))
            {
                this.procedureAllocationCalcEntityList.Add(procedure.ProcedureCode,procedure);
                // 
                // procedureCalcControl
                // 
                var procedureCalcControl = new ProjectAllocationCalc.ProcedureCalcControl();
                procedureCalcControl.ProcedureAllocationCalcEntity = procedure;
                procedureCalcControl.Dock = System.Windows.Forms.DockStyle.Fill;
                procedureCalcControl.Location = new System.Drawing.Point(3, 3);
                procedureCalcControl.Name = "procedureCalcControl" + this.i.ToString();
                procedureCalcControl.Size = new System.Drawing.Size(772, 412);
                procedureCalcControl.TabIndex = 1;

                // 
                // tpProcedure
                // 
                var tpProcedure = new System.Windows.Forms.TabPage();
                tpProcedure.Controls.Add(procedureCalcControl);
                tpProcedure.Location = new System.Drawing.Point(4, 22);
                tpProcedure.Name = "tpProcedure" + this.i.ToString();
                tpProcedure.Padding = new System.Windows.Forms.Padding(3);
                tpProcedure.Size = new System.Drawing.Size(778, 418);
                tpProcedure.TabIndex = 0;
                tpProcedure.Text = procedure.ProcedureName;
                tpProcedure.UseVisualStyleBackColor = true;
                tpProcedure.Tag = procedure;
                
                // 
                // tcProcedure
                // 
                this.Controls.Add(tpProcedure);
                this.SelectedTab = tpProcedure;
                myDictionary.Add(procedure.ProcedureCode, tpProcedure);
                this.i++;
            }            
        }

        public void RemoveCalcControl(ProcedureAllocationCalcEntity procedure)
        {
            if (this.procedureAllocationCalcEntityList.ContainsKey(procedure.ProcedureCode))
            {
                this.procedureAllocationCalcEntityList.Remove(procedure.ProcedureCode);

                if(myDictionary.ContainsKey(procedure.ProcedureCode)) 
　　            { 
　　　　            var tpProcedure = myDictionary[procedure.ProcedureCode];
                    // 
                    // tcProcedure
                    // 
                    this.Controls.Remove(tpProcedure);
                    //this.SelectedTab = tpProcedure;
                    myDictionary.Remove(procedure.ProcedureCode);
　　            } 
                
            }

        }

        public List<ProcedureAllocationCalcEntity> GetProcedureAllocationCalcEntityList()
        {
            List<ProcedureAllocationCalcEntity> list = new List<ProcedureAllocationCalcEntity>();
            foreach (var procedure in this.myDictionary)
            {
                var tpProcedure = procedure.Value;

                foreach (var c in tpProcedure.Controls)
                {
                    var procedureCalcControl = c as ProcedureCalcControl;
                    if (procedureCalcControl != null)
                    {
                        list.Add(procedureCalcControl.ProcedureAllocationCalcEntity);                        
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
            foreach (var procedure in this.myDictionary)
            {
                var tpProcedure = procedure.Value;

                foreach (var c in tpProcedure.Controls)
                {
                    var procedureCalcControl = c as ProcedureCalcControl;
                    if (procedureCalcControl != null)
                    {
                        procedureCalcControl.Worth = this.Worth;
                    }
                }
            }
        }
    }
}
