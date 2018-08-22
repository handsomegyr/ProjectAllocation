using ProjectAllocationCalc;
using ProjectAllocationFramework;
namespace ProjectAllocationCalc
{
    partial class frmProjectAllocationCalc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblProjectDate = new System.Windows.Forms.Label();
            this.dateTimePickerProjectDate = new System.Windows.Forms.DateTimePicker();
            this.txtProjectLeaderWorth2 = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProjectLeaderWorth2 = new System.Windows.Forms.Label();
            this.lblProjectLeaderPercent2 = new System.Windows.Forms.Label();
            this.txtProjectLeader2 = new ProjectAllocation.Controls.UserCharTextBox();
            this.btnProjectLeader2 = new System.Windows.Forms.Button();
            this.txtProjectLeaderPercent2 = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProjectLeader2 = new System.Windows.Forms.Label();
            this.txtProjectLeaderWorth1 = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProjectLeaderWorth1 = new System.Windows.Forms.Label();
            this.lblProjectLeaderPercent1 = new System.Windows.Forms.Label();
            this.txtProjectLeader1 = new ProjectAllocation.Controls.UserCharTextBox();
            this.btnProjectLeader1 = new System.Windows.Forms.Button();
            this.txtProjectLeaderPercent1 = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProjectLeader1 = new System.Windows.Forms.Label();
            this.btnProject = new System.Windows.Forms.Button();
            this.txtProjectWorth = new ProjectAllocation.Controls.UserNumberTextBox();
            this.lblProjectCost = new System.Windows.Forms.Label();
            this.txtProjectName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.contextMenuStripStage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddStage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteStage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteWorker1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteWorker2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripStage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWork
            // 
            this.panelWork.Controls.Add(this.splitContainer1);
            this.panelWork.Size = new System.Drawing.Size(883, 462);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectDate);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePickerProjectDate);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeaderWorth2);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeaderWorth2);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeaderPercent2);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeader2);
            this.splitContainer1.Panel1.Controls.Add(this.btnProjectLeader2);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeaderPercent2);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeader2);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeaderWorth1);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeaderWorth1);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeaderPercent1);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeader1);
            this.splitContainer1.Panel1.Controls.Add(this.btnProjectLeader1);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectLeaderPercent1);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectLeader1);
            this.splitContainer1.Panel1.Controls.Add(this.btnProject);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectWorth);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectCost);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectName);
            this.splitContainer1.Panel1.Controls.Add(this.lblProject);
            this.splitContainer1.Panel1MinSize = 80;
            this.splitContainer1.Size = new System.Drawing.Size(883, 462);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblProjectDate
            // 
            this.lblProjectDate.AutoSize = true;
            this.lblProjectDate.Location = new System.Drawing.Point(661, 10);
            this.lblProjectDate.Name = "lblProjectDate";
            this.lblProjectDate.Size = new System.Drawing.Size(34, 15);
            this.lblProjectDate.TabIndex = 5;
            this.lblProjectDate.Text = "日期:";
            // 
            // dateTimePickerProjectDate
            // 
            this.dateTimePickerProjectDate.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePickerProjectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerProjectDate.Location = new System.Drawing.Point(698, 7);
            this.dateTimePickerProjectDate.Name = "dateTimePickerProjectDate";
            this.dateTimePickerProjectDate.Size = new System.Drawing.Size(127, 21);
            this.dateTimePickerProjectDate.TabIndex = 6;
            // 
            // txtProjectLeaderWorth2
            // 
            this.txtProjectLeaderWorth2.DecimalDigits = 2;
            this.txtProjectLeaderWorth2.Location = new System.Drawing.Point(459, 59);
            this.txtProjectLeaderWorth2.MaxValue = 1.7976931348623157E+308D;
            this.txtProjectLeaderWorth2.MinValue = -1.7976931348623157E+308D;
            this.txtProjectLeaderWorth2.Name = "txtProjectLeaderWorth2";
            this.txtProjectLeaderWorth2.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.All;
            this.txtProjectLeaderWorth2.ReadOnly = true;
            this.txtProjectLeaderWorth2.ShowComma = true;
            this.txtProjectLeaderWorth2.Size = new System.Drawing.Size(150, 21);
            this.txtProjectLeaderWorth2.TabIndex = 20;
            this.txtProjectLeaderWorth2.Text = "0.00";
            this.txtProjectLeaderWorth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectLeaderWorth2.Value = 0D;
            // 
            // lblProjectLeaderWorth2
            // 
            this.lblProjectLeaderWorth2.AutoSize = true;
            this.lblProjectLeaderWorth2.Location = new System.Drawing.Point(371, 60);
            this.lblProjectLeaderWorth2.Name = "lblProjectLeaderWorth2";
            this.lblProjectLeaderWorth2.Size = new System.Drawing.Size(85, 15);
            this.lblProjectLeaderWorth2.TabIndex = 19;
            this.lblProjectLeaderWorth2.Text = "主师2产值(元):";
            // 
            // lblProjectLeaderPercent2
            // 
            this.lblProjectLeaderPercent2.AutoSize = true;
            this.lblProjectLeaderPercent2.Location = new System.Drawing.Point(194, 60);
            this.lblProjectLeaderPercent2.Name = "lblProjectLeaderPercent2";
            this.lblProjectLeaderPercent2.Size = new System.Drawing.Size(108, 15);
            this.lblProjectLeaderPercent2.TabIndex = 17;
            this.lblProjectLeaderPercent2.Text = "主师2分配比例(%):";
            // 
            // txtProjectLeader2
            // 
            this.txtProjectLeader2.Location = new System.Drawing.Point(50, 59);
            this.txtProjectLeader2.MaxLength = 100;
            this.txtProjectLeader2.Name = "txtProjectLeader2";
            this.txtProjectLeader2.ReadOnly = true;
            this.txtProjectLeader2.Size = new System.Drawing.Size(105, 21);
            this.txtProjectLeader2.TabIndex = 15;
            // 
            // btnProjectLeader2
            // 
            this.btnProjectLeader2.Location = new System.Drawing.Point(161, 56);
            this.btnProjectLeader2.Name = "btnProjectLeader2";
            this.btnProjectLeader2.Size = new System.Drawing.Size(24, 23);
            this.btnProjectLeader2.TabIndex = 16;
            this.btnProjectLeader2.Text = "...";
            this.btnProjectLeader2.UseVisualStyleBackColor = true;
            this.btnProjectLeader2.Click += new System.EventHandler(this.btnProjectLeader2_Click);
            // 
            // txtProjectLeaderPercent2
            // 
            this.txtProjectLeaderPercent2.DecimalDigits = 2;
            this.txtProjectLeaderPercent2.Location = new System.Drawing.Point(308, 59);
            this.txtProjectLeaderPercent2.MaxValue = 100D;
            this.txtProjectLeaderPercent2.MinValue = 0D;
            this.txtProjectLeaderPercent2.Name = "txtProjectLeaderPercent2";
            this.txtProjectLeaderPercent2.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.Positive;
            this.txtProjectLeaderPercent2.ShowComma = true;
            this.txtProjectLeaderPercent2.Size = new System.Drawing.Size(50, 21);
            this.txtProjectLeaderPercent2.TabIndex = 18;
            this.txtProjectLeaderPercent2.Text = "0.00";
            this.txtProjectLeaderPercent2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectLeaderPercent2.Value = 0D;
            this.txtProjectLeaderPercent2.TextChanged += new System.EventHandler(this.txtProjectLeaderPercent2_TextChanged);
            // 
            // lblProjectLeader2
            // 
            this.lblProjectLeader2.AutoSize = true;
            this.lblProjectLeader2.Location = new System.Drawing.Point(5, 60);
            this.lblProjectLeader2.Name = "lblProjectLeader2";
            this.lblProjectLeader2.Size = new System.Drawing.Size(41, 15);
            this.lblProjectLeader2.TabIndex = 14;
            this.lblProjectLeader2.Text = "主师2:";
            // 
            // txtProjectLeaderWorth1
            // 
            this.txtProjectLeaderWorth1.DecimalDigits = 2;
            this.txtProjectLeaderWorth1.Location = new System.Drawing.Point(459, 33);
            this.txtProjectLeaderWorth1.MaxValue = 1.7976931348623157E+308D;
            this.txtProjectLeaderWorth1.MinValue = -1.7976931348623157E+308D;
            this.txtProjectLeaderWorth1.Name = "txtProjectLeaderWorth1";
            this.txtProjectLeaderWorth1.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.All;
            this.txtProjectLeaderWorth1.ReadOnly = true;
            this.txtProjectLeaderWorth1.ShowComma = true;
            this.txtProjectLeaderWorth1.Size = new System.Drawing.Size(150, 21);
            this.txtProjectLeaderWorth1.TabIndex = 13;
            this.txtProjectLeaderWorth1.Text = "0.00";
            this.txtProjectLeaderWorth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectLeaderWorth1.Value = 0D;
            // 
            // lblProjectLeaderWorth1
            // 
            this.lblProjectLeaderWorth1.AutoSize = true;
            this.lblProjectLeaderWorth1.Location = new System.Drawing.Point(371, 35);
            this.lblProjectLeaderWorth1.Name = "lblProjectLeaderWorth1";
            this.lblProjectLeaderWorth1.Size = new System.Drawing.Size(85, 15);
            this.lblProjectLeaderWorth1.TabIndex = 12;
            this.lblProjectLeaderWorth1.Text = "主师1产值(元):";
            // 
            // lblProjectLeaderPercent1
            // 
            this.lblProjectLeaderPercent1.AutoSize = true;
            this.lblProjectLeaderPercent1.Location = new System.Drawing.Point(194, 35);
            this.lblProjectLeaderPercent1.Name = "lblProjectLeaderPercent1";
            this.lblProjectLeaderPercent1.Size = new System.Drawing.Size(108, 15);
            this.lblProjectLeaderPercent1.TabIndex = 10;
            this.lblProjectLeaderPercent1.Text = "主师1分配比例(%):";
            // 
            // txtProjectLeader1
            // 
            this.txtProjectLeader1.Location = new System.Drawing.Point(50, 33);
            this.txtProjectLeader1.MaxLength = 100;
            this.txtProjectLeader1.Name = "txtProjectLeader1";
            this.txtProjectLeader1.ReadOnly = true;
            this.txtProjectLeader1.Size = new System.Drawing.Size(105, 21);
            this.txtProjectLeader1.TabIndex = 8;
            // 
            // btnProjectLeader1
            // 
            this.btnProjectLeader1.Location = new System.Drawing.Point(161, 30);
            this.btnProjectLeader1.Name = "btnProjectLeader1";
            this.btnProjectLeader1.Size = new System.Drawing.Size(24, 23);
            this.btnProjectLeader1.TabIndex = 9;
            this.btnProjectLeader1.Text = "...";
            this.btnProjectLeader1.UseVisualStyleBackColor = true;
            this.btnProjectLeader1.Click += new System.EventHandler(this.btnProjectLeader1_Click);
            // 
            // txtProjectLeaderPercent1
            // 
            this.txtProjectLeaderPercent1.DecimalDigits = 2;
            this.txtProjectLeaderPercent1.Location = new System.Drawing.Point(308, 33);
            this.txtProjectLeaderPercent1.MaxValue = 100D;
            this.txtProjectLeaderPercent1.MinValue = 0D;
            this.txtProjectLeaderPercent1.Name = "txtProjectLeaderPercent1";
            this.txtProjectLeaderPercent1.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.Positive;
            this.txtProjectLeaderPercent1.ShowComma = true;
            this.txtProjectLeaderPercent1.Size = new System.Drawing.Size(50, 21);
            this.txtProjectLeaderPercent1.TabIndex = 11;
            this.txtProjectLeaderPercent1.Text = "0.00";
            this.txtProjectLeaderPercent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectLeaderPercent1.Value = 0D;
            this.txtProjectLeaderPercent1.TextChanged += new System.EventHandler(this.txtProjectLeaderPercent1_TextChanged);
            // 
            // lblProjectLeader1
            // 
            this.lblProjectLeader1.AutoSize = true;
            this.lblProjectLeader1.Location = new System.Drawing.Point(5, 35);
            this.lblProjectLeader1.Name = "lblProjectLeader1";
            this.lblProjectLeader1.Size = new System.Drawing.Size(41, 15);
            this.lblProjectLeader1.TabIndex = 7;
            this.lblProjectLeader1.Text = "主师1:";
            // 
            // btnProject
            // 
            this.btnProject.Location = new System.Drawing.Point(338, 5);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(24, 23);
            this.btnProject.TabIndex = 2;
            this.btnProject.Text = "...";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // txtProjectWorth
            // 
            this.txtProjectWorth.DecimalDigits = 2;
            this.txtProjectWorth.Location = new System.Drawing.Point(459, 7);
            this.txtProjectWorth.MaxValue = 1.7976931348623157E+308D;
            this.txtProjectWorth.MinValue = 0D;
            this.txtProjectWorth.Name = "txtProjectWorth";
            this.txtProjectWorth.PositiveNegativeStyle = ProjectAllocation.Controls.PositiveNegativeStyle.Positive;
            this.txtProjectWorth.ShowComma = true;
            this.txtProjectWorth.Size = new System.Drawing.Size(150, 21);
            this.txtProjectWorth.TabIndex = 4;
            this.txtProjectWorth.Text = "0.00";
            this.txtProjectWorth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjectWorth.Value = 0D;
            this.txtProjectWorth.TextChanged += new System.EventHandler(this.txtProjectWorth_TextChanged);
            // 
            // lblProjectCost
            // 
            this.lblProjectCost.AutoSize = true;
            this.lblProjectCost.Location = new System.Drawing.Point(402, 10);
            this.lblProjectCost.Name = "lblProjectCost";
            this.lblProjectCost.Size = new System.Drawing.Size(54, 15);
            this.lblProjectCost.TabIndex = 3;
            this.lblProjectCost.Text = "产值(元):";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(50, 7);
            this.txtProjectName.MaxLength = 100;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(285, 21);
            this.txtProjectName.TabIndex = 1;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(5, 10);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(34, 15);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "项目:";
            // 
            // contextMenuStripStage
            // 
            this.contextMenuStripStage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddStage,
            this.toolStripMenuItemRefresh,
            this.toolStripMenuItemDeleteStage,
            this.toolStripMenuItemDeleteWorker1,
            this.toolStripMenuItemDeleteWorker2});
            this.contextMenuStripStage.Name = "contextMenuStripStage";
            this.contextMenuStripStage.Size = new System.Drawing.Size(132, 114);
            // 
            // toolStripMenuItemAddStage
            // 
            this.toolStripMenuItemAddStage.Name = "toolStripMenuItemAddStage";
            this.toolStripMenuItemAddStage.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItemAddStage.Text = "添加阶段";
            this.toolStripMenuItemAddStage.Click += new System.EventHandler(this.toolStripMenuItemAddStage_Click);
            // 
            // toolStripMenuItemRefresh
            // 
            this.toolStripMenuItemRefresh.Name = "toolStripMenuItemRefresh";
            this.toolStripMenuItemRefresh.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItemRefresh.Text = "重新计算";
            this.toolStripMenuItemRefresh.Visible = false;
            this.toolStripMenuItemRefresh.Click += new System.EventHandler(this.toolStripMenuItemRefresh_Click);
            // 
            // toolStripMenuItemDeleteStage
            // 
            this.toolStripMenuItemDeleteStage.Name = "toolStripMenuItemDeleteStage";
            this.toolStripMenuItemDeleteStage.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItemDeleteStage.Text = "删除阶段";
            this.toolStripMenuItemDeleteStage.Click += new System.EventHandler(this.toolStripMenuItemDeleteStage_Click);
            // 
            // toolStripMenuItemDeleteWorker1
            // 
            this.toolStripMenuItemDeleteWorker1.Name = "toolStripMenuItemDeleteWorker1";
            this.toolStripMenuItemDeleteWorker1.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItemDeleteWorker1.Text = "删除主师1";
            this.toolStripMenuItemDeleteWorker1.Click += new System.EventHandler(this.toolStripMenuItemDeleteWorker1_Click);
            // 
            // toolStripMenuItemDeleteWorker2
            // 
            this.toolStripMenuItemDeleteWorker2.Name = "toolStripMenuItemDeleteWorker2";
            this.toolStripMenuItemDeleteWorker2.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItemDeleteWorker2.Text = "删除主师2";
            this.toolStripMenuItemDeleteWorker2.Click += new System.EventHandler(this.toolStripMenuItemDeleteWorker2_Click);
            // 
            // frmProjectAllocationCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 539);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmProjectAllocationCalc";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "产值计算";
            this.Text = "产值计算";
            this.Controls.SetChildIndex(this.panelWork, 0);
            this.panelWork.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripStage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnProject;
        private ProjectAllocation.Controls.UserNumberTextBox txtProjectWorth;
        private System.Windows.Forms.Label lblProjectCost;
        private ProjectAllocation.Controls.UserCharTextBox txtProjectName;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddStage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteStage;
        private ProjectAllocation.Controls.UserCharTextBox txtProjectLeader1;
        private System.Windows.Forms.Button btnProjectLeader1;
        private ProjectAllocation.Controls.UserNumberTextBox txtProjectLeaderPercent1;
        private System.Windows.Forms.Label lblProjectLeader1;
        private ProjectAllocation.Controls.UserNumberTextBox txtProjectLeaderWorth1;
        private System.Windows.Forms.Label lblProjectLeaderWorth1;
        private System.Windows.Forms.Label lblProjectLeaderPercent1;
        private ProjectAllocation.Controls.UserNumberTextBox txtProjectLeaderWorth2;
        private System.Windows.Forms.Label lblProjectLeaderWorth2;
        private System.Windows.Forms.Label lblProjectLeaderPercent2;
        private ProjectAllocation.Controls.UserCharTextBox txtProjectLeader2;
        private System.Windows.Forms.Button btnProjectLeader2;
        private ProjectAllocation.Controls.UserNumberTextBox txtProjectLeaderPercent2;
        private System.Windows.Forms.Label lblProjectLeader2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteWorker1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteWorker2;
        private System.Windows.Forms.Label lblProjectDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerProjectDate;

    }
}