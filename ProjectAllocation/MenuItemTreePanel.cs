using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectAllocationFramework;

namespace ProjectAllocation
{
    public partial class MenuItemTreePanel : DockContent
    {
        public MenuItemTreePanel()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Icon = ProjectAllocationResource.Resource.Action_view_tree;
            taskItemTree.LoadMenu();
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            taskItemTree.Nodes.Clear();
            base.OnClosing(e);
        }

    }
}

