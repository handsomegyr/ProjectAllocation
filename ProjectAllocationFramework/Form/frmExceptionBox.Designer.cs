namespace ProjectAllocationFramework
{
    partial class frmExceptionBox
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 

        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelTaskName = new System.Windows.Forms.Label();
            this.textBoxErrorInfo = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.Controls.Add(this.labelTaskName, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.textBoxErrorInfo, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.okButton, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 8);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(417, 246);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelTaskName
            // 
            this.labelTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTaskName.Location = new System.Drawing.Point(6, 0);
            this.labelTaskName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelTaskName.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelTaskName.Name = "labelTaskName";
            this.labelTaskName.Size = new System.Drawing.Size(408, 16);
            this.labelTaskName.TabIndex = 19;
            this.labelTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxErrorInfo
            // 
            this.textBoxErrorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxErrorInfo.Location = new System.Drawing.Point(6, 37);
            this.textBoxErrorInfo.Margin = new System.Windows.Forms.Padding(6, 2, 3, 2);
            this.textBoxErrorInfo.Multiline = true;
            this.textBoxErrorInfo.Name = "textBoxErrorInfo";
            this.textBoxErrorInfo.ReadOnly = true;
            this.textBoxErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxErrorInfo.Size = new System.Drawing.Size(408, 171);
            this.textBoxErrorInfo.TabIndex = 23;
            this.textBoxErrorInfo.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(339, 222);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 22);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "OK(&O)";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // frmExceptionBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 262);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = Constant.ProjectAllocationFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmExceptionBox";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectAllocation System Error";
            this.TopMost = true;
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelTaskName;
        private System.Windows.Forms.TextBox textBoxErrorInfo;
        private System.Windows.Forms.Button okButton;
    }
}
