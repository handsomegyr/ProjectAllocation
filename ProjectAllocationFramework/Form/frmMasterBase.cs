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
    public partial class frmMasterBase : frmBigBase
    {
        public frmMasterBase()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            tsbSave.Image = BudgetResource.Resource.apply;
            tsbImport.Image = BudgetResource.Resource.Import;
            tsbExport.Image = BudgetResource.Resource.Export;
            tsbClear.Image = BudgetResource.Resource.kedit;
            tsbSearch.Image = BudgetResource.Resource.kdvi;
            tsbBack.Image = BudgetResource.Resource.back1;

            tsbBack.Click += new EventHandler(tsbBack_Click);
        }

        void tsbBack_Click(object sender, EventArgs e)
        {
            this.Back();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

    }
}
