namespace BudgetFramework
{
    partial class frmInputBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputBase));
            this.toolStripOperation = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.budgetStatusStripInfo = new BudgetFramework.Statues.BudgetStatusStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblConditionTitle = new Budget.Controls.XPLabel();
            this.lblDataListTitle = new Budget.Controls.XPLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripOperation
            // 
            this.toolStripOperation.Font = new System.Drawing.Font("Arial", 9F);
            this.toolStripOperation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbImport,
            this.tsbExport,
            this.tsbBack,
            this.tsbClear,
            this.tsbSearch});
            this.toolStripOperation.Location = new System.Drawing.Point(0, 0);
            this.toolStripOperation.Name = "toolStripOperation";
            this.toolStripOperation.Size = new System.Drawing.Size(1018, 38);
            this.toolStripOperation.Stretch = true;
            this.toolStripOperation.TabIndex = 0;
            this.toolStripOperation.Text = "toolStripOperation";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(38, 35);
            this.tsbSave.Text = "Save";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbImport
            // 
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(46, 35);
            this.tsbImport.Text = "Import";
            this.tsbImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbExport
            // 
            this.tsbExport.Image = ((System.Drawing.Image)(resources.GetObject("tsbExport.Image")));
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(45, 35);
            this.tsbExport.Text = "Export";
            this.tsbExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbBack
            // 
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(38, 35);
            this.tsbBack.Text = "Back";
            this.tsbBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbClear
            // 
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(41, 35);
            this.tsbClear.Text = "Clear";
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbSearch
            // 
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(50, 35);
            this.tsbSearch.Text = "Search";
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // budgetStatusStripInfo
            // 
            this.budgetStatusStripInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.budgetStatusStripInfo.IsBusy = false;
            this.budgetStatusStripInfo.Location = new System.Drawing.Point(0, 704);
            this.budgetStatusStripInfo.Name = "budgetStatusStripInfo";
            this.budgetStatusStripInfo.Size = new System.Drawing.Size(1018, 22);
            this.budgetStatusStripInfo.TabIndex = 1;
            this.budgetStatusStripInfo.Text = "budgetStatusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.splitContainer1.Panel1.Controls.Add(this.lblConditionTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(250)))));
            this.splitContainer1.Panel2.Controls.Add(this.lblDataListTitle);
            this.splitContainer1.Size = new System.Drawing.Size(1018, 666);
            this.splitContainer1.SplitterDistance = 176;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblConditionTitle
            // 
            this.lblConditionTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblConditionTitle.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblConditionTitle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(187)))));
            this.lblConditionTitle.BackColorScheme = Budget.Controls.BackColorSchemeType.Office2003Blue;
            this.lblConditionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConditionTitle.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblConditionTitle.ForeColor = System.Drawing.Color.White;
            this.lblConditionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblConditionTitle.Name = "lblConditionTitle";
            this.lblConditionTitle.ShowShadow = false;
            this.lblConditionTitle.Size = new System.Drawing.Size(1016, 23);
            this.lblConditionTitle.TabIndex = 0;
            this.lblConditionTitle.Text = "Input Information(INSERT/UPDATE)";
            this.lblConditionTitle.TextAlign = Budget.Controls.TextAlignStyle.AlignLeftMiddle;
            // 
            // lblDataListTitle
            // 
            this.lblDataListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblDataListTitle.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblDataListTitle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(187)))));
            this.lblDataListTitle.BackColorScheme = Budget.Controls.BackColorSchemeType.Office2003Blue;
            this.lblDataListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataListTitle.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDataListTitle.ForeColor = System.Drawing.Color.White;
            this.lblDataListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDataListTitle.Name = "lblDataListTitle";
            this.lblDataListTitle.ShowShadow = false;
            this.lblDataListTitle.Size = new System.Drawing.Size(1016, 23);
            this.lblDataListTitle.TabIndex = 0;
            this.lblDataListTitle.Text = "Data List";
            this.lblDataListTitle.TextAlign = Budget.Controls.TextAlignStyle.AlignLeftMiddle;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmInputBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 726);
            this.CloseButton = true;
            this.CloseButtonVisible = true;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.budgetStatusStripInfo);
            this.Controls.Add(this.toolStripOperation);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "frmInputBase";
            this.Text = "frmInputBase";
            this.toolStripOperation.ResumeLayout(false);
            this.toolStripOperation.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        protected internal System.Windows.Forms.SplitContainer splitContainer1;
        protected internal Statues.BudgetStatusStrip budgetStatusStripInfo;
        protected internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        protected internal System.Windows.Forms.SaveFileDialog saveFileDialog1;
        protected internal Budget.Controls.XPLabel lblDataListTitle;
        protected internal Budget.Controls.XPLabel lblConditionTitle;



    }
}