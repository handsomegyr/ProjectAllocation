using ProjectAllocationUtil;
namespace ProjectAllocationCalc
{
    partial class StageCalcControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStagePercent = new System.Windows.Forms.Label();
            this.lblStageWorth = new System.Windows.Forms.Label();
            this.pnlStagePercent = new System.Windows.Forms.Panel();
            this.txtStagePercent = new ProjectAllocation.Controls.UserNumberTextBox();
            this.txtStageWorth = new ProjectAllocation.Controls.UserNumberTextBox();
            this.procedureCalcTabControl1 = new ProjectAllocationCalc.ProcedureCalcTabControl(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.pnlStagePercent.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAdd,
            this.toolStripMenuItemRemove,
            this.toolStripMenuItemRefresh});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemAdd.Text = "添加专业";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRemove.Text = "删除专业";
            this.toolStripMenuItemRemove.Click += new System.EventHandler(this.toolStripMenuItemRemove_Click);
            // 
            // toolStripMenuItemRefresh
            // 
            this.toolStripMenuItemRefresh.Name = "toolStripMenuItemRefresh";
            this.toolStripMenuItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRefresh.Text = "重新计算";
            this.toolStripMenuItemRefresh.Visible = false;
            this.toolStripMenuItemRefresh.Click += new System.EventHandler(this.toolStripMenuItemRefresh_Click);
            // 
            // lblStagePercent
            // 
            this.lblStagePercent.AutoSize = true;
            this.lblStagePercent.Location = new System.Drawing.Point(5, 9);
            this.lblStagePercent.Name = "lblStagePercent";
            this.lblStagePercent.Size = new System.Drawing.Size(101, 12);
            this.lblStagePercent.TabIndex = 0;
            this.lblStagePercent.Text = "阶段分配比例(%):";
            // 
            // lblStageWorth
            // 
            this.lblStageWorth.AutoSize = true;
            this.lblStageWorth.Location = new System.Drawing.Point(164, 9);
            this.lblStageWorth.Name = "lblStageWorth";
            this.lblStageWorth.Size = new System.Drawing.Size(83, 12);
            this.lblStageWorth.TabIndex = 2;
            this.lblStageWorth.Text = "阶段产值(元):";
            // 
            // pnlStagePercent
            // 
            this.pnlStagePercent.Controls.Add(this.txtStagePercent);
            this.pnlStagePercent.Controls.Add(this.txtStageWorth);
            this.pnlStagePercent.Controls.Add(this.lblStageWorth);
            this.pnlStagePercent.Controls.Add(this.lblStagePercent);
            this.pnlStagePercent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStagePercent.Location = new System.Drawing.Point(0, 0);
            this.pnlStagePercent.Name = "pnlStagePercent";
            this.pnlStagePercent.Size = new System.Drawing.Size(446, 33);
            this.pnlStagePercent.TabIndex = 0;
            // 
            // txtStagePercent
            // 
            this.txtStagePercent.DecimalDigits = 2;
            this.txtStagePercent.Location = new System.Drawing.Point(109, 6);
            this.txtStagePercent.MaxValue = 100D;
            this.txtStagePercent.MinValue = 0D;
            this.txtStagePercent.Name = "txtStagePercent";
            this.txtStagePercent.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.Positive;
            this.txtStagePercent.ShowComma = true;
            this.txtStagePercent.Size = new System.Drawing.Size(50, 21);
            this.txtStagePercent.TabIndex = 1;
            this.txtStagePercent.Text = "0.00";
            this.txtStagePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStagePercent.Value = 0D;
            this.txtStagePercent.TextChanged += new System.EventHandler(this.txtStagePercent_TextChanged);
            // 
            // txtStageWorth
            // 
            this.txtStageWorth.DecimalDigits = 2;
            this.txtStageWorth.Location = new System.Drawing.Point(250, 6);
            this.txtStageWorth.MaxValue = 1.7976931348623157E+308D;
            this.txtStageWorth.MinValue = -1.7976931348623157E+308D;
            this.txtStageWorth.Name = "txtStageWorth";
            this.txtStageWorth.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.All;
            this.txtStageWorth.ReadOnly = true;
            this.txtStageWorth.ShowComma = true;
            this.txtStageWorth.Size = new System.Drawing.Size(150, 21);
            this.txtStageWorth.TabIndex = 3;
            this.txtStageWorth.Text = "0.00";
            this.txtStageWorth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStageWorth.Value = 0D;
            // 
            // procedureCalcTabControl1
            // 
            this.procedureCalcTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procedureCalcTabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procedureCalcTabControl1.Location = new System.Drawing.Point(0, 33);
            this.procedureCalcTabControl1.Name = "procedureCalcTabControl1";
            this.procedureCalcTabControl1.SelectedIndex = 0;
            this.procedureCalcTabControl1.Size = new System.Drawing.Size(446, 306);
            this.procedureCalcTabControl1.TabIndex = 1;
            this.procedureCalcTabControl1.Worth = 0D;
            // 
            // StageCalcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.procedureCalcTabControl1);
            this.Controls.Add(this.pnlStagePercent);
            this.Name = "StageCalcControl";
            this.Size = new System.Drawing.Size(446, 339);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlStagePercent.ResumeLayout(false);
            this.pnlStagePercent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRefresh;

        private System.Windows.Forms.Panel pnlStagePercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtStagePercent;
        private ProjectAllocation.Controls.UserNumberTextBox txtStageWorth;
        private System.Windows.Forms.Label lblStageWorth;
        private System.Windows.Forms.Label lblStagePercent;

        private ProcedureCalcTabControl procedureCalcTabControl1;
    }
}
