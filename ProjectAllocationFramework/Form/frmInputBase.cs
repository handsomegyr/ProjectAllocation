using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BudgetFramework.Command;

namespace BudgetFramework
{
    public partial class frmInputBase : frmBigBase
    {
        public frmInputBase()
        {
            InitializeComponent();
            tsbSave.Image = BudgetResource.Resource.Save.ToBitmap();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

    }
}
