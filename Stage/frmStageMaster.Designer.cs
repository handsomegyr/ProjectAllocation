using Stage;
using ProjectAllocationFramework;
namespace Stage
{
    partial class frmStageMaster
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
            this.txtStageCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtStageName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lbStageCode = new System.Windows.Forms.Label();
            this.lblStageName = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblStageName);
            this.splitContainer1.Panel1.Controls.Add(this.lbStageCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtStageName);
            this.splitContainer1.Panel1.Controls.Add(this.txtStageCode);
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
            // txtStageCode
            // 
            this.txtStageCode.Location = new System.Drawing.Point(110, 50);
            this.txtStageCode.MaxLength = 8;
            this.txtStageCode.Name = "txtStageCode";
            this.txtStageCode.Size = new System.Drawing.Size(80, 21);
            this.txtStageCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtStageCode.TabIndex = 2;
            // 
            // txtStageName
            // 
            this.txtStageName.Location = new System.Drawing.Point(308, 50);
            this.txtStageName.MaxLength = 100;
            this.txtStageName.Name = "txtStageName";
            this.txtStageName.Size = new System.Drawing.Size(200, 21);
            this.txtStageName.TabIndex = 2;
            // 
            // lbStageCode
            // 
            this.lbStageCode.AutoSize = true;
            this.lbStageCode.BackColor = System.Drawing.Color.Transparent;
            this.lbStageCode.Location = new System.Drawing.Point(22, 53);
            this.lbStageCode.Name = "lbStageCode";
            this.lbStageCode.Size = new System.Drawing.Size(70, 15);
            this.lbStageCode.TabIndex = 3;
            this.lbStageCode.Text = "阶段码:";
            this.lbStageCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStageName
            // 
            this.lblStageName.AutoSize = true;
            this.lblStageName.BackColor = System.Drawing.Color.Transparent;
            this.lblStageName.Location = new System.Drawing.Point(216, 53);
            this.lblStageName.Name = "lblStageName";
            this.lblStageName.Size = new System.Drawing.Size(74, 15);
            this.lblStageName.TabIndex = 3;
            this.lblStageName.Text = "阶段名称:";
            this.lblStageName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmStageMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmStageMaster";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "阶段";
            this.Text = "阶段";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtStageName;
        private ProjectAllocation.Controls.UserCharTextBox txtStageCode;
        private System.Windows.Forms.Label lblStageName;
        private System.Windows.Forms.Label lbStageCode;
    }
}