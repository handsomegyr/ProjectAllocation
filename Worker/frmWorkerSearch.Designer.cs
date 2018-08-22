using Worker;
using ProjectAllocationFramework;
namespace Worker
{
    partial class frmWorkerSearch
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
            this.txtWorkerCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtWorkerName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblWorkerCode = new System.Windows.Forms.Label();
            this.lblWorkerName = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblWorkerName);
            this.splitContainer1.Panel1.Controls.Add(this.lblWorkerCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtWorkerName);
            this.splitContainer1.Panel1.Controls.Add(this.txtWorkerCode);
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
            // txtWorkerCode
            // 
            this.txtWorkerCode.Location = new System.Drawing.Point(110, 50);
            this.txtWorkerCode.MaxLength = 8;
            this.txtWorkerCode.Name = "txtWorkerCode";
            this.txtWorkerCode.Size = new System.Drawing.Size(80, 21);
            this.txtWorkerCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtWorkerCode.TabIndex = 2;
            // 
            // txtWorkerName
            // 
            this.txtWorkerName.Location = new System.Drawing.Point(308, 50);
            this.txtWorkerName.MaxLength = 100;
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.Size = new System.Drawing.Size(200, 21);
            this.txtWorkerName.TabIndex = 2;
            // 
            // lblWorkerCode
            // 
            this.lblWorkerCode.AutoSize = true;
            this.lblWorkerCode.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerCode.Location = new System.Drawing.Point(22, 53);
            this.lblWorkerCode.Name = "lblWorkerCode";
            this.lblWorkerCode.Size = new System.Drawing.Size(46, 15);
            this.lblWorkerCode.TabIndex = 3;
            this.lblWorkerCode.Text = "员工号:";
            this.lblWorkerCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorkerName
            // 
            this.lblWorkerName.AutoSize = true;
            this.lblWorkerName.BackColor = System.Drawing.Color.Transparent;
            this.lblWorkerName.Location = new System.Drawing.Point(216, 53);
            this.lblWorkerName.Name = "lblWorkerName";
            this.lblWorkerName.Size = new System.Drawing.Size(46, 15);
            this.lblWorkerName.TabIndex = 3;
            this.lblWorkerName.Text = "员工名:";
            this.lblWorkerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmWorkerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmWorkerSearch";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "员工检索";
            this.Text = "员工检索";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtWorkerName;
        private ProjectAllocation.Controls.UserCharTextBox txtWorkerCode;
        private System.Windows.Forms.Label lblWorkerName;
        private System.Windows.Forms.Label lblWorkerCode;
    }
}