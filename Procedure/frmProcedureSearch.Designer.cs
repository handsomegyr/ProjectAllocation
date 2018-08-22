using Procedure;
using ProjectAllocationFramework;
namespace Procedure
{
    partial class frmProcedureSearch
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
            this.txtProcedureCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtProcedureName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblProcedureCode = new System.Windows.Forms.Label();
            this.lblProcedureName = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblProcedureName);
            this.splitContainer1.Panel1.Controls.Add(this.lblProcedureCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtProcedureName);
            this.splitContainer1.Panel1.Controls.Add(this.txtProcedureCode);
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
            // txtProcedureCode
            // 
            this.txtProcedureCode.Location = new System.Drawing.Point(110, 50);
            this.txtProcedureCode.MaxLength = 8;
            this.txtProcedureCode.Name = "txtProcedureCode";
            this.txtProcedureCode.Size = new System.Drawing.Size(80, 21);
            this.txtProcedureCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtProcedureCode.TabIndex = 2;
            // 
            // txtProcedureName
            // 
            this.txtProcedureName.Location = new System.Drawing.Point(308, 50);
            this.txtProcedureName.MaxLength = 100;
            this.txtProcedureName.Name = "txtProcedureName";
            this.txtProcedureName.Size = new System.Drawing.Size(200, 21);
            this.txtProcedureName.TabIndex = 2;
            // 
            // lblProcedureCode
            // 
            this.lblProcedureCode.AutoSize = true;
            this.lblProcedureCode.BackColor = System.Drawing.Color.Transparent;
            this.lblProcedureCode.Location = new System.Drawing.Point(22, 53);
            this.lblProcedureCode.Name = "lblProcedureCode";
            this.lblProcedureCode.Size = new System.Drawing.Size(46, 15);
            this.lblProcedureCode.TabIndex = 3;
            this.lblProcedureCode.Text = "专业号:";
            this.lblProcedureCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcedureName
            // 
            this.lblProcedureName.AutoSize = true;
            this.lblProcedureName.BackColor = System.Drawing.Color.Transparent;
            this.lblProcedureName.Location = new System.Drawing.Point(216, 53);
            this.lblProcedureName.Name = "lblProcedureName";
            this.lblProcedureName.Size = new System.Drawing.Size(46, 15);
            this.lblProcedureName.TabIndex = 3;
            this.lblProcedureName.Text = "专业名:";
            this.lblProcedureName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProcedureSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmProcedureSearch";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "专业检索";
            this.Text = "专业检索";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtProcedureName;
        private ProjectAllocation.Controls.UserCharTextBox txtProcedureCode;
        private System.Windows.Forms.Label lblProcedureName;
        private System.Windows.Forms.Label lblProcedureCode;
    }
}