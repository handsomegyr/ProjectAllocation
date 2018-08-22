namespace ProjectAllocationLayout
{
    partial class frmMasterBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterBase));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblConditionTitle = new ProjectAllocation.Controls.XPLabel();
            this.lblDataListTitle = new ProjectAllocation.Controls.XPLabel();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
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
            this.splitContainer1.Size = new System.Drawing.Size(1125, 645);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblConditionTitle
            // 
            this.lblConditionTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblConditionTitle.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblConditionTitle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(187)))));
            this.lblConditionTitle.BackColorScheme = ProjectAllocation.Controls.BackColorSchemeType.Office2003Blue;
            this.lblConditionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConditionTitle.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConditionTitle.ForeColor = System.Drawing.Color.White;
            this.lblConditionTitle.Location = new System.Drawing.Point(0, 0);
            this.lblConditionTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblConditionTitle.Name = "lblConditionTitle";
            this.lblConditionTitle.ShowShadow = false;
            this.lblConditionTitle.Size = new System.Drawing.Size(1123, 29);
            this.lblConditionTitle.TabIndex = 0;
            this.lblConditionTitle.Text = "检索条件设置";
            this.lblConditionTitle.TextAlign = ProjectAllocation.Controls.TextAlignStyle.AlignLeftMiddle;
            // 
            // lblDataListTitle
            // 
            this.lblDataListTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblDataListTitle.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(191)))), ((int)(((byte)(236)))));
            this.lblDataListTitle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(102)))), ((int)(((byte)(187)))));
            this.lblDataListTitle.BackColorScheme = ProjectAllocation.Controls.BackColorSchemeType.Office2003Blue;
            this.lblDataListTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataListTitle.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataListTitle.ForeColor = System.Drawing.Color.White;
            this.lblDataListTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDataListTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDataListTitle.Name = "lblDataListTitle";
            this.lblDataListTitle.ShowShadow = false;
            this.lblDataListTitle.Size = new System.Drawing.Size(1123, 29);
            this.lblDataListTitle.TabIndex = 0;
            this.lblDataListTitle.Text = "数据列表";
            this.lblDataListTitle.TextAlign = ProjectAllocation.Controls.TextAlignStyle.AlignLeftMiddle;
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
            // tsbCopy
            // 
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(53, 52);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // frmMasterBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMasterBase";
            this.Text = "frmMasterBase";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected internal System.Windows.Forms.ToolStripButton tsbSave;
        protected internal System.Windows.Forms.ToolStripButton tsbImport;
        protected internal System.Windows.Forms.ToolStripButton tsbExport;
        protected internal System.Windows.Forms.ToolStripButton tsbBack;
        protected internal System.Windows.Forms.ToolStripButton tsbCopy;
        protected internal System.Windows.Forms.ToolStripButton tsbClear;
        protected internal System.Windows.Forms.ToolStripButton tsbSearch;
        protected internal System.Windows.Forms.SplitContainer splitContainer1;
        protected internal ProjectAllocation.Controls.XPLabel lblDataListTitle;
        protected internal ProjectAllocation.Controls.XPLabel lblConditionTitle;



    }
}