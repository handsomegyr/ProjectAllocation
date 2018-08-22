using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ProjectAllocationLayout;
using ProjectAllocationFramework;

namespace ProjectAllocationLayout
{
    public partial class frmBusinessBase : frmBase
    {
        public frmBusinessBase()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            this.Icon = ProjectAllocationResource.Resource.Action_configure;

            tsbSave.Image = ProjectAllocationResource.Resource.apply;
            tsbImport.Image = ProjectAllocationResource.Resource.Import;
            tsbExport.Image = ProjectAllocationResource.Resource.Export;
            tsbClear.Image = ProjectAllocationResource.Resource.kedit;
            tsbSearch.Image = ProjectAllocationResource.Resource.kdvi;
            tsbBack.Image = ProjectAllocationResource.Resource.back1;
            HkgImpor.Image = ProjectAllocationResource.Resource.Import;
            IntImpor.Image = ProjectAllocationResource.Resource.Import;
            PurchaseImpor.Image = ProjectAllocationResource.Resource.Import;
            StockImpor.Image = ProjectAllocationResource.Resource.Import;
            CompanyView.Image = ProjectAllocationResource.Resource.Import;

            this.toolStripOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompanyView,
            this.tsbSave,
            this.tsbImport,
            this.HkgImpor,
            this.IntImpor,
            this.PurchaseImpor,
            this.StockImpor,
            this.tsbExport,
            this.tsbSearch,
            this.tsbClear,
            this.tsbBack});

            this.toolStripOperation.TabIndex = 0;
            this.panelWork.TabIndex = 1;
            this.StatusStripInfo.TabIndex = 2;

            tsbSave.Visible = true;
            tsbImport.Visible = false;
            tsbExport.Visible = false;
            tsbClear.Visible = false;
            tsbSearch.Visible = false;
            tsbBack.Visible = true;
            HkgImpor.Visible = false;
            IntImpor.Visible = false;
            PurchaseImpor.Visible = false;
            StockImpor.Visible = false;
            CompanyView.Visible = false;

            tsbSave.Text = "Execute";
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
