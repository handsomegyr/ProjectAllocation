using User;
using ProjectAllocationFramework;
namespace User
{
    partial class frmUserMaster
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
            this.txtUserCode = new ProjectAllocation.Controls.UserCharTextBox();
            this.txtUserName = new ProjectAllocation.Controls.UserCharTextBox();
            this.lblUserCode = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblUserName);
            this.splitContainer1.Panel1.Controls.Add(this.lblUserCode);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserName);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserCode);
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
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(110, 50);
            this.txtUserCode.MaxLength = 8;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(80, 21);
            this.txtUserCode.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9;
            this.txtUserCode.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(308, 50);
            this.txtUserName.MaxLength = 100;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // lblUserCode
            // 
            this.lblUserCode.AutoSize = true;
            this.lblUserCode.BackColor = System.Drawing.Color.Transparent;
            this.lblUserCode.Location = new System.Drawing.Point(22, 53);
            this.lblUserCode.Name = "lblUserCode";
            this.lblUserCode.Size = new System.Drawing.Size(70, 15);
            this.lblUserCode.TabIndex = 3;
            this.lblUserCode.Text = "用户帐号:";
            this.lblUserCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(216, 53);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(74, 15);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "用户名称:";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 719);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Name = "frmUserMaster";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.TabText = "后台用户";
            this.Text = "后台用户";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox txtUserName;
        private ProjectAllocation.Controls.UserCharTextBox txtUserCode;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserCode;
    }
}