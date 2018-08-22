using ProjectAllocationFramework;
namespace ProjectAllocation
{
    partial class MenuItemTreePanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuItemTreePanel));
            this.taskItemTree = new ProjectAllocation.MenuDataTreeView(this.components);
            this.SuspendLayout();
            // 
            // taskItemTree
            // 
            resources.ApplyResources(this.taskItemTree, "taskItemTree");
            this.taskItemTree.HideSelection = false;
            this.taskItemTree.Name = "taskItemTree";
            // 
            // MenuItemTreePanel
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.taskItemTree);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "MenuItemTreePanel";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "²Ëµ¥";
            this.ResumeLayout(false);

        }

        #endregion

        private MenuDataTreeView taskItemTree;
    }
}
