using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ProjectAllocationFramework;

namespace ProjectAllocationLayout
{
    public partial class frmMasterBase : frmBase
    {
        public frmMasterBase()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            this.Icon = ProjectAllocationResource.Resource.Action_view_icon;

            tsbSave.Image = ProjectAllocationResource.Resource.apply;
            tsbImport.Image = ProjectAllocationResource.Resource.Import;
            tsbExport.Image = ProjectAllocationResource.Resource.Export;
            tsbClear.Image = ProjectAllocationResource.Resource.kedit;
            tsbSearch.Image = ProjectAllocationResource.Resource.kdvi;
            tsbCopy.Image = ProjectAllocationResource.Resource.editcopy;
            tsbBack.Image = ProjectAllocationResource.Resource.back1;

            this.tsbClear.Text = "清空";
            this.tsbSave.Text = "保存";
            this.tsbSearch.Text = "检索";
            this.tsbImport.Text = "导入";
            this.tsbExport.Text = "导出";
            this.tsbCopy.Text = "复制";
            this.tsbBack.Text = "关闭";

            tsbCopy.Visible = false;
            this.toolStripOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbImport,
            this.tsbExport,
            this.tsbCopy,
            this.tsbSearch,
            this.tsbClear,
            this.tsbBack});
            this.toolStripOperation.TabIndex = 0;
            this.splitContainer1.TabIndex = 1;
            this.StatusStripInfo.TabIndex = 2;
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
