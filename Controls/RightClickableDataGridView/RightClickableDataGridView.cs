using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ProjectAllocation.Controls
{
    
    /// <summary>
    /// This class extends datagridview to support right click select row.
    /// </summary>
    public partial class RightClickableDataGridView : BorderDataGridView
    {
        #region field
        //bool isDrag = false;
        //int mouseDownIndex = -1;
        #endregion

        public RightClickableDataGridView()
        {
            InitializeComponent();
        }

        public RightClickableDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnCellContextMenuStripNeeded(DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            base.OnCellContextMenuStripNeeded(e);
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    HitTestInfo info = this.HitTest(e.X, e.Y);
        //    this.mouseDownIndex = info.RowIndex;
        //    if (info.RowIndex < 0)
        //    {
        //        base.OnMouseDown(e);
        //        return;
        //    }
        //    DataGridViewRow cRow = this.Rows[info.RowIndex];
        //    this.isDrag = cRow.Selected;

        //    if (this.isDrag)
        //    {
        //        this.ResetMouseEventArgs();
        //    }
        //    else if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
        //    {
        //        this.ClearSelection();
        //        this.SetSelectedRowCore(info.RowIndex, true);
        //        this.ResetMouseEventArgs();
        //    }
        //    else
        //    {
        //        base.OnMouseDown(e);
        //    }
        //}

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    HitTestInfo info = this.HitTest(e.X, e.Y);
        //    if (info.RowIndex < 0)
        //    {
        //        base.OnMouseUp(e);
        //        return;
        //    }
        //    if (this.isDrag && info.RowIndex == this.mouseDownIndex && (e.Button & MouseButtons.Left) == MouseButtons.Left)
        //    {
        //        this.ClearSelection();
        //        this.SetSelectedRowCore(info.RowIndex, true);
        //    }
        //    else
        //    {
        //        base.OnMouseUp(e);
        //    }
        //    this.mouseDownIndex = -1;
        //}
    }
}
