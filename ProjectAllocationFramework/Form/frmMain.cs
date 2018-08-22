using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using ProjectAllocationFramework;
using ProjectAllocationResource;

namespace ProjectAllocationFramework
{
    public partial class frmMain : frmBigBase
    { 
        public frmMain()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            Application.Idle += new EventHandler(Application_Idle);
            this.dockPanel.ShowDocumentIcon = false;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Application_Idle);
        }

    }
}
