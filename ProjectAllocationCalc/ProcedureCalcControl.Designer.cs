namespace ProjectAllocationCalc
{
    partial class ProcedureCalcControl
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
            this.txtProcedurePercent = new ProjectAllocation.Controls.UserNumberTextBox();
            this.txtProcedureWorth = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProcedureWorth = new System.Windows.Forms.Label();
            this.lblProcedurePercent = new System.Windows.Forms.Label();
            this.pnlProcedurePercent = new System.Windows.Forms.Panel();
            this.jobCalcTabControl1 = new ProjectAllocationCalc.JobCalcTabControl(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.pnlProcedurePercent.SuspendLayout();
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
            this.toolStripMenuItemAdd.Text = "添加工序";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.toolStripMenuItemAdd_Click);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRemove.Text = "删除工序";
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
            // txtProcedurePercent
            // 
            this.txtProcedurePercent.DecimalDigits = 2;
            this.txtProcedurePercent.Location = new System.Drawing.Point(109, 6);
            this.txtProcedurePercent.MaxValue = 100D;
            this.txtProcedurePercent.MinValue = 0D;
            this.txtProcedurePercent.Name = "txtProcedurePercent";
            this.txtProcedurePercent.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.Positive;
            this.txtProcedurePercent.ShowComma = true;
            this.txtProcedurePercent.Size = new System.Drawing.Size(50, 21);
            this.txtProcedurePercent.TabIndex = 1;
            this.txtProcedurePercent.Text = "0.00";
            this.txtProcedurePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProcedurePercent.Value = 0D;
            this.txtProcedurePercent.TextChanged += new System.EventHandler(this.txtProcedurePercent_TextChanged);
            // 
            // txtProcedureWorth
            // 
            this.txtProcedureWorth.DecimalDigits = 2;
            this.txtProcedureWorth.Location = new System.Drawing.Point(250, 6);
            this.txtProcedureWorth.MaxValue = 1.7976931348623157E+308D;
            this.txtProcedureWorth.MinValue = -1.7976931348623157E+308D;
            this.txtProcedureWorth.Name = "txtProcedureWorth";
            this.txtProcedureWorth.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.All;
            this.txtProcedureWorth.ReadOnly = true;
            this.txtProcedureWorth.ShowComma = true;
            this.txtProcedureWorth.Size = new System.Drawing.Size(150, 21);
            this.txtProcedureWorth.TabIndex = 3;
            this.txtProcedureWorth.Text = "0.00";
            this.txtProcedureWorth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProcedureWorth.Value = 0D;
            // 
            // lblProcedureWorth
            // 
            this.lblProcedureWorth.AutoSize = true;
            this.lblProcedureWorth.Location = new System.Drawing.Point(164, 9);
            this.lblProcedureWorth.Name = "lblProcedureWorth";
            this.lblProcedureWorth.Size = new System.Drawing.Size(83, 12);
            this.lblProcedureWorth.TabIndex = 2;
            this.lblProcedureWorth.Text = "专业产值(元):";
            // 
            // lblProcedurePercent
            // 
            this.lblProcedurePercent.AutoSize = true;
            this.lblProcedurePercent.Location = new System.Drawing.Point(5, 9);
            this.lblProcedurePercent.Name = "lblProcedurePercent";
            this.lblProcedurePercent.Size = new System.Drawing.Size(101, 12);
            this.lblProcedurePercent.TabIndex = 0;
            this.lblProcedurePercent.Text = "专业分配比例(%):";
            // 
            // pnlProcedurePercent
            // 
            this.pnlProcedurePercent.Controls.Add(this.txtProcedurePercent);
            this.pnlProcedurePercent.Controls.Add(this.txtProcedureWorth);
            this.pnlProcedurePercent.Controls.Add(this.lblProcedureWorth);
            this.pnlProcedurePercent.Controls.Add(this.lblProcedurePercent);
            this.pnlProcedurePercent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcedurePercent.Location = new System.Drawing.Point(0, 0);
            this.pnlProcedurePercent.Name = "pnlProcedurePercent";
            this.pnlProcedurePercent.Size = new System.Drawing.Size(438, 33);
            this.pnlProcedurePercent.TabIndex = 0;
            // 
            // jobCalcTabControl1
            // 
            this.jobCalcTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobCalcTabControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobCalcTabControl1.Location = new System.Drawing.Point(0, 33);
            this.jobCalcTabControl1.Name = "jobCalcTabControl1";
            this.jobCalcTabControl1.SelectedIndex = 0;
            this.jobCalcTabControl1.Size = new System.Drawing.Size(438, 262);
            this.jobCalcTabControl1.TabIndex = 1;
            this.jobCalcTabControl1.Worth = 0D;
            // 
            // ProcedureCalcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.jobCalcTabControl1);
            this.Controls.Add(this.pnlProcedurePercent);
            this.Name = "ProcedureCalcControl";
            this.Size = new System.Drawing.Size(438, 295);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnlProcedurePercent.ResumeLayout(false);
            this.pnlProcedurePercent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRefresh;
    }
}
