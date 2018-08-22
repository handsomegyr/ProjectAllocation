namespace ProjectAllocationLayout.Statues
{
    partial class StatusStrip
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

        #region 

        private void InitializeComponent()
        {
            this.toolStripPrimaryInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTaskName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SuspendLayout();
            // 
            // toolStripPrimaryInfo
            // 
            this.toolStripPrimaryInfo.Name = "toolStripPrimaryInfo";
            this.toolStripPrimaryInfo.Size = new System.Drawing.Size(41, 21);
            this.toolStripPrimaryInfo.Spring = true;
            this.toolStripPrimaryInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripPrimaryInfo.Visible = false;
            // 
            // toolStripTaskName
            // 
            this.toolStripTaskName.Name = "toolStripTaskName";
            this.toolStripTaskName.Size = new System.Drawing.Size(41, 21);
            this.toolStripTaskName.Spring = true;
            this.toolStripTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripTaskName.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // StatusStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTaskName,
            this.toolStripProgressBar,
            this.toolStripPrimaryInfo});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripTaskName;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPrimaryInfo;
    }
}
