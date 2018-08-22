using Job;
using ProjectAllocationFramework;
namespace Job
{
    partial class frmJobSearch
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
            this.txtJobCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtJobName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblJobCode = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblJobName);
            this.splitContainer1.Panel1.Controls.Add(this.lblJobCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtJobName);
            this.splitContainer1.Panel1.Controls.Add(this.txtJobCode);
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
            // txtJobCode
            // 
            this.txtJobCode.Location = new System.Drawing.Point(110, 50);
            this.txtJobCode.MaxLength = 8;
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Size = new System.Drawing.Size(80, 21);
            this.txtJobCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtJobCode.TabIndex = 2;
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(308, 50);
            this.txtJobName.MaxLength = 100;
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(200, 21);
            this.txtJobName.TabIndex = 2;
            // 
            // lblJobCode
            // 
            this.lblJobCode.AutoSize = true;
            this.lblJobCode.BackColor = System.Drawing.Color.Transparent;
            this.lblJobCode.Location = new System.Drawing.Point(22, 53);
            this.lblJobCode.Name = "lblJobCode";
            this.lblJobCode.Size = new System.Drawing.Size(46, 15);
            this.lblJobCode.TabIndex = 3;
            this.lblJobCode.Text = "工序号:";
            this.lblJobCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.BackColor = System.Drawing.Color.Transparent;
            this.lblJobName.Location = new System.Drawing.Point(216, 53);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(46, 15);
            this.lblJobName.TabIndex = 3;
            this.lblJobName.Text = "工序名:";
            this.lblJobName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmJobSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmJobSearch";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "工序检索";
            this.Text = "工序检索";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtJobName;
        private ProjectAllocation.Controls.UserCharTextBox txtJobCode;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label lblJobCode;
    }
}