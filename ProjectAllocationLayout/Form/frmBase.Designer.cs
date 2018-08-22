using ProjectAllocationFramework;
namespace ProjectAllocationLayout
{
    partial class frmBase
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
            this.toolStripOperation = new System.Windows.Forms.ToolStrip();
            this.StatusStripInfo = new ProjectAllocationLayout.Statues.StatusStrip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // toolStripOperation
            // 
            this.toolStripOperation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripOperation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripOperation.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripOperation.Location = new System.Drawing.Point(0, 0);
            this.toolStripOperation.Name = "toolStripOperation";
            this.toolStripOperation.Size = new System.Drawing.Size(1018, 25);
            this.toolStripOperation.Stretch = true;
            this.toolStripOperation.TabIndex = 0;
            this.toolStripOperation.Text = "toolStripOperation";
            // 
            // StatusStripInfo
            // 
            this.StatusStripInfo.Font = Constant.ProjectAllocationFont;
            this.StatusStripInfo.IsBusy = false;
            this.StatusStripInfo.Location = new System.Drawing.Point(0, 704);
            this.StatusStripInfo.Name = "StatusStripInfo";
            this.StatusStripInfo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusStripInfo.Size = new System.Drawing.Size(1018, 22);
            this.StatusStripInfo.SizingGrip = false;
            this.StatusStripInfo.TabIndex = 1;
            this.StatusStripInfo.Text = "StatusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 726);
            this.CloseButton = true;
            this.CloseButtonVisible = true;
            this.Controls.Add(this.StatusStripInfo);
            this.Controls.Add(this.toolStripOperation);
            this.Font = Constant.ProjectAllocationFont;
            this.Name = "frmBase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.ToolStrip toolStripOperation;
        protected internal Statues.StatusStrip StatusStripInfo;
        protected internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        protected internal System.Windows.Forms.SaveFileDialog saveFileDialog1;



    }
}