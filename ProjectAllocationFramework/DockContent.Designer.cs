namespace ProjectAllocationFramework
{
    partial class DockContent
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
            this.SuspendLayout();
            // 
            // ProjectAllocationDockContent
            // 
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Font = Constant.ProjectAllocationFont;
            this.Name = "ProjectAllocationDockContent";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
