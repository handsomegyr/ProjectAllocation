using ProjectAllocationFramework;
namespace ProjectAllocationLayout
{
    partial class MasterDataGridView
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region
 
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.userCharTextBox1 = new ProjectAllocation.Controls.UserCharTextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // userCharTextBox1
            // 
            this.userCharTextBox1.Location = new System.Drawing.Point(396, 198);
            this.userCharTextBox1.MaxLength = 8;
            this.userCharTextBox1.Name = "userCharTextBox1";
            this.userCharTextBox1.Size = new System.Drawing.Size(79, 21);
            this.userCharTextBox1.Style = ProjectAllocation.Controls.TextStyle.A_Za_z0_9Chinese;
            this.userCharTextBox1.TabIndex = 4;
            this.userCharTextBox1.Visible = false;
            // 
            // MasterDataGridView
            // 
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(193)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MultiSelect = false;
            this.RowHeadersWidth = 35;
            this.RowTemplate.Height = 27;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectAllocation.Controls.UserCharTextBox userCharTextBox1;
    }
}
