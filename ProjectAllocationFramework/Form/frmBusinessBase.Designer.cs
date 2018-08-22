namespace BudgetFramework
{
    partial class frmBusinessBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusinessBase));
            this.toolStripOperation = new System.Windows.Forms.ToolStrip();
            this.CompanyView = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.HkgImpor = new System.Windows.Forms.ToolStripButton();
            this.IntImpor = new System.Windows.Forms.ToolStripButton();
            this.PurchaseImpor = new System.Windows.Forms.ToolStripButton();
            this.StockImpor = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.budgetStatusStripInfo = new BudgetFramework.Statues.BudgetStatusStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelWork = new System.Windows.Forms.Panel();
            this.toolStripOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOperation
            // 
            this.toolStripOperation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripOperation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOperation.ImageScalingSize = new System.Drawing.Size(32, 32);
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
            this.toolStripOperation.Location = new System.Drawing.Point(0, 0);
            this.toolStripOperation.Name = "toolStripOperation";
            this.toolStripOperation.Size = new System.Drawing.Size(1018, 55);
            this.toolStripOperation.Stretch = true;
            this.toolStripOperation.TabIndex = 0;
            this.toolStripOperation.Text = "toolStripOperation";
            // 
            // CompanyView
            // 
            this.CompanyView.Image = ((System.Drawing.Image)(resources.GetObject("CompanyView.Image")));
            this.CompanyView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CompanyView.Name = "CompanyView";
            this.CompanyView.Size = new System.Drawing.Size(72, 52);
            this.CompanyView.Text = "Company";
            this.CompanyView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(44, 52);
            this.tsbSave.Text = "Save";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbImport
            // 
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(53, 52);
            this.tsbImport.Text = "Import";
            this.tsbImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // HkgImpor
            // 
            this.HkgImpor.Image = ((System.Drawing.Image)(resources.GetObject("HkgImpor.Image")));
            this.HkgImpor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HkgImpor.Name = "HkgImpor";
            this.HkgImpor.Size = new System.Drawing.Size(57, 52);
            this.HkgImpor.Text = "HKG(S)";
            this.HkgImpor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // IntImpor
            // 
            this.IntImpor.Image = ((System.Drawing.Image)(resources.GetObject("IntImpor.Image")));
            this.IntImpor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IntImpor.Name = "IntImpor";
            this.IntImpor.Size = new System.Drawing.Size(53, 52);
            this.IntImpor.Text = "Int\'ｌ(S)";
            this.IntImpor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // PurchaseImpor
            // 
            this.PurchaseImpor.Image = ((System.Drawing.Image)(resources.GetObject("PurchaseImpor.Image")));
            this.PurchaseImpor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PurchaseImpor.Name = "PurchaseImpor";
            this.PurchaseImpor.Size = new System.Drawing.Size(71, 52);
            this.PurchaseImpor.Text = "Purchase";
            this.PurchaseImpor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // StockImpor
            // 
            this.StockImpor.Image = ((System.Drawing.Image)(resources.GetObject("StockImpor.Image")));
            this.StockImpor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StockImpor.Name = "StockImpor";
            this.StockImpor.Size = new System.Drawing.Size(47, 52);
            this.StockImpor.Text = "Stock";
            this.StockImpor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(53, 52);
            this.tsbExport.Text = "Export";
            this.tsbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbBack
            // 
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(43, 52);
            this.tsbBack.Text = "Back";
            this.tsbBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbClear
            // 
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(46, 52);
            this.tsbClear.Text = "Clear";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(57, 52);
            this.tsbSearch.Text = "Search";
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // budgetStatusStripInfo
            // 
            this.budgetStatusStripInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetStatusStripInfo.IsBusy = false;
            this.budgetStatusStripInfo.Location = new System.Drawing.Point(0, 704);
            this.budgetStatusStripInfo.Name = "budgetStatusStripInfo";
            this.budgetStatusStripInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.budgetStatusStripInfo.Size = new System.Drawing.Size(1018, 22);
            this.budgetStatusStripInfo.SizingGrip = false;
            this.budgetStatusStripInfo.TabIndex = 2;
            this.budgetStatusStripInfo.Text = "budgetStatusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelWork
            // 
            this.panelWork.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.panelWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWork.Location = new System.Drawing.Point(0, 55);
            this.panelWork.Name = "panelWork";
            this.panelWork.Size = new System.Drawing.Size(1018, 649);
            this.panelWork.TabIndex = 1;
            // 
            // frmBusinessBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 726);
            this.CloseButton = true;
            this.CloseButtonVisible = true;
            this.Controls.Add(this.panelWork);
            this.Controls.Add(this.budgetStatusStripInfo);
            this.Controls.Add(this.toolStripOperation);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "frmBusinessBase";
            this.Text = "frmBusinessBase";
            this.toolStripOperation.ResumeLayout(false);
            this.toolStripOperation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.ToolStrip toolStripOperation;
        protected internal System.Windows.Forms.ToolStripButton tsbSave;
        protected internal System.Windows.Forms.ToolStripButton tsbImport;
        protected internal System.Windows.Forms.ToolStripButton tsbExport;
        protected internal System.Windows.Forms.ToolStripButton tsbBack;
        protected internal System.Windows.Forms.ToolStripButton tsbClear;
        protected internal System.Windows.Forms.ToolStripButton tsbSearch;
        protected internal Statues.BudgetStatusStrip budgetStatusStripInfo;
        protected internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        protected internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
        protected internal System.Windows.Forms.Panel panelWork;
        protected internal System.Windows.Forms.ToolStripButton HkgImpor;
        protected internal System.Windows.Forms.ToolStripButton IntImpor;
        protected internal System.Windows.Forms.ToolStripButton PurchaseImpor;
        protected internal System.Windows.Forms.ToolStripButton StockImpor;
        protected internal System.Windows.Forms.ToolStripButton CompanyView;



    }
}