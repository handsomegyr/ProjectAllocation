using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public partial class frmExceptionBox : Form
    {
        public frmExceptionBox()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            this.TopLevel = true; 
        }

        public void SetTaskInfo(string taskName)
        {
            this.labelTaskName.Text = taskName;
        }

        public void SetErrorInfo(string errorMessage)
        {
            this.textBoxErrorInfo.Text = errorMessage;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
