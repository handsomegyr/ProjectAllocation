using ProjectAllocationFramework;
namespace ProjectAllocation
{
    partial class MenuDataTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuDataTreeView));
            this.treeViewIcoList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewIcoList
            // 
            this.treeViewIcoList.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            resources.ApplyResources(this.treeViewIcoList, "treeViewIcoList");
            this.treeViewIcoList.TransparentColor = System.Drawing.Color.White;
            // 
            // MenuDataTreeView
            // 
            resources.ApplyResources(this, "$this");
            this.HideSelection = false;
            this.ImageList = this.treeViewIcoList;
            this.LineColor = System.Drawing.Color.Black;
            this.Font = Constant.ProjectAllocationFont;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList treeViewIcoList;



    }
}
