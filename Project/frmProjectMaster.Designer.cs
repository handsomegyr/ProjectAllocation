using Project;
using ProjectAllocationFramework;
namespace Project
{
    partial class frmProjectMaster
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
            this.txtProjectCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtProjectName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblProjectCode = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectName);
            this.splitContainer1.Panel1.Controls.Add(this.lblProjectCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectName);
            this.splitContainer1.Panel1.Controls.Add(this.txtProjectCode);
            this.splitContainer1.Size = new System.Drawing.Size(926, 642);
            this.splitContainer1.SplitterDistance = 101;
            // 
            // lblDataListTitle
            // 
            this.lblDataListTitle.Size = new System.Drawing.Size(924, 23);
            // 
            // lblConditionTitle
            // 
            this.lblConditionTitle.Size = new System.Drawing.Size(924, 23);
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(110, 50);
            this.txtProjectCode.MaxLength = 8;
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(80, 21);
            this.txtProjectCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtProjectCode.TabIndex = 2;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(308, 50);
            this.txtProjectName.MaxLength = 100;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(200, 21);
            this.txtProjectName.TabIndex = 2;
            // 
            // lblProjectCode
            // 
            this.lblProjectCode.AutoSize = true;
            this.lblProjectCode.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectCode.Location = new System.Drawing.Point(22, 53);
            this.lblProjectCode.Name = "lblProjectCode";
            this.lblProjectCode.Size = new System.Drawing.Size(70, 15);
            this.lblProjectCode.TabIndex = 3;
            this.lblProjectCode.Text = "项目号:";
            this.lblProjectCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectName.Location = new System.Drawing.Point(216, 53);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(74, 15);
            this.lblProjectName.TabIndex = 3;
            this.lblProjectName.Text = "项目名:";
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProjectMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmProjectMaster";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "项目";
            this.Text = "项目";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtProjectName;
        private ProjectAllocation.Controls.UserCharTextBox txtProjectCode;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label lblProjectCode;
    }
}