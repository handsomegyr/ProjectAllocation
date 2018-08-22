using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public partial class frmSmallBase : frmBigBase
    {
        public frmSmallBase()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    this.btnCancel_Click(null, e);
        //}
    }
}
