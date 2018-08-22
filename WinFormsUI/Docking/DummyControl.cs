using System;
using System.Windows.Forms;

namespace WeifenLuo.WinFormsUI.Docking
{
	internal class DummyControl : Control
	{
		public DummyControl()
		{
			SetStyle(ControlStyles.Selectable, false);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DummyControl
            // 
            this.Font = ProjectAllocationConstant.ProjectAllocationFont;
            this.ResumeLayout(false);

        }
	}
}
