using ProjectAllocationFramework;
namespace ProjectAllocation
{
    partial class frmProjectAllocation
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
            this.picCompanyIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picCompanyName = new System.Windows.Forms.PictureBox();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslExit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslServerDBInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDateInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVersionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyIcon)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyName)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel
            // 
            this.dockPanel.DefaultFloatWindowSize = new System.Drawing.Size(800, 600);
            this.dockPanel.DockLeftPortion = 0.15D;
            this.dockPanel.Location = new System.Drawing.Point(0, 57);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(3);
            this.dockPanel.Size = new System.Drawing.Size(1018, 601);
            this.dockPanel.TabIndex = 0;
            // 
            // picCompanyIcon
            // 
            this.picCompanyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCompanyIcon.Location = new System.Drawing.Point(4, 3);
            this.picCompanyIcon.Name = "picCompanyIcon";
            this.picCompanyIcon.Size = new System.Drawing.Size(46, 50);
            this.picCompanyIcon.TabIndex = 0;
            this.picCompanyIcon.TabStop = false;
            this.picCompanyIcon.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picCompanyName);
            this.panel1.Controls.Add(this.picCompanyIcon);
            this.panel1.Controls.Add(this.lblSystemName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 57);
            this.panel1.TabIndex = 3;
            // 
            // picCompanyName
            // 
            this.picCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picCompanyName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picCompanyName.Location = new System.Drawing.Point(55, 3);
            this.picCompanyName.Name = "picCompanyName";
            this.picCompanyName.Size = new System.Drawing.Size(115, 50);
            this.picCompanyName.TabIndex = 6;
            this.picCompanyName.TabStop = false;
            this.picCompanyName.Visible = false;
            // 
            // lblSystemName
            // 
            this.lblSystemName.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSystemName.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.ForeColor = System.Drawing.Color.Snow;
            this.lblSystemName.Location = new System.Drawing.Point(0, 0);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(1016, 55);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "项目产值分配管理系统";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSystemName.UseCompatibleTextRendering = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslExit,
            this.toolStripStatusLabel1,
            this.tsslServerDBInfo,
            this.toolStripStatusLabel2,
            this.tsslUserInfo,
            this.toolStripStatusLabel3,
            this.tsslDateInfo,
            this.toolStripStatusLabel4,
            this.tsslVersionInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1018, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            // 
            // tsslExit
            // 
            this.tsslExit.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslExit.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.tsslExit.Name = "tsslExit";
            this.tsslExit.Size = new System.Drawing.Size(44, 20);
            this.tsslExit.Text = "退出";
            this.tsslExit.Click += new System.EventHandler(this.tsslExit_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(163, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "                    ";
            // 
            // tsslServerDBInfo
            // 
            this.tsslServerDBInfo.Name = "tsslServerDBInfo";
            this.tsslServerDBInfo.Size = new System.Drawing.Size(223, 20);
            this.tsslServerDBInfo.Text = "Server:10.0.0.7  DB:ProjectAllocation";
            this.tsslServerDBInfo.Visible = false;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(163, 20);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "     ";
            // 
            // tsslUserInfo
            // 
            this.tsslUserInfo.Name = "tsslUserInfo";
            this.tsslUserInfo.Size = new System.Drawing.Size(60, 20);
            this.tsslUserInfo.Text = "User:Xue";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(163, 20);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "       ";
            // 
            // tsslDateInfo
            // 
            this.tsslDateInfo.Name = "tsslDateInfo";
            this.tsslDateInfo.Size = new System.Drawing.Size(156, 20);
            this.tsslDateInfo.Text = "Date:2011-08-08 12:09:09";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(163, 20);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "      ";
            // 
            // tsslVersionInfo
            // 
            this.tsslVersionInfo.Name = "tsslVersionInfo";
            this.tsslVersionInfo.Size = new System.Drawing.Size(95, 20);
            this.tsslVersionInfo.Text = "Version:1.0.0.0";
            // 
            // frmProjectAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 683);
            this.CloseButton = true;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmProjectAllocation";
            this.Text = "项目产值分配管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProjectAllocation_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.statusStrip1, 0);
            this.Controls.SetChildIndex(this.dockPanel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCompanyName)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCompanyIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslExit;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerDBInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslUserInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslDateInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersionInfo;
        private System.Windows.Forms.PictureBox picCompanyName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;

    }
}