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
using ProjectAllocationLayout.Statues;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness.Entity;

namespace ProjectAllocationLayout
{
    public partial class frmBase : frmBigBase
    {
        protected Presenter Presenter {get;set; }

        public frmBase()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            this.TabText = this.Text;
            Presenter = new Presenter(this);

            openFileDialog1.DefaultExt = EXCELDEFAULTEXT;
            openFileDialog1.Filter = ProjectAllocationResource.Resource.ExcelFileFilter;

            saveFileDialog1.DefaultExt = EXCELDEFAULTEXT;
            saveFileDialog1.Filter = ProjectAllocationResource.Resource.ExcelFileFilter97_2003;
        }

        protected const string EXCELDEFAULTEXT = ".xls";

        protected virtual ProjectAllocationLayout.Statues.StatusStrip Status
        {
            get { return this.StatusStripInfo; }
        }

        protected virtual void OnProgressChanged(object sender, ProjectAllocationFramework.Statues.ProgressChangedEventArgs e)
        {
            if (this.Status != null)
            {
                Thread.Sleep(10);

                if (!string.IsNullOrEmpty(e.TaskName))
                {
                    this.Status.TaskMessage = e.TaskName;
                }
                this.Status.InfomationMessage = e.ProgressInfo;
                this.Status.Percentage = e.ProgressPercentage;
            }
        }

        public virtual DataGridViewSelectedRowCollection SelectedRows()
        {
            throw new NotImplementedException();
        }

    }
}
