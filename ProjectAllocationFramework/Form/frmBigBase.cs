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
    public partial class frmBigBase : DockContent
    {
        public frmBigBase()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
	        {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
		        default:
                    break;
	        }
            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter:
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
