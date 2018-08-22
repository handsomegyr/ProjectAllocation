using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Budget.Controls;
using System.Windows.Forms;
using System.Drawing;

namespace BudgetFramework
{
    public partial class MasterDataGridView : RightClickableDataGridView
    {
        public MasterDataGridView()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Core.CoreData.CoreDataChanged += new CoreDataChangedEventHandler(CoreData_CoreDataChanged);

        }
        protected virtual void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
        }

        public MasterDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Core.CoreData.CoreDataChanged += new CoreDataChangedEventHandler(CoreData_CoreDataChanged);
        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            displayErrorDialogIfNoHandler = false;
            base.OnDataError(displayErrorDialogIfNoHandler, e);
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                this.RowHeadersWidth,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, 
                (e.RowIndex + 1).ToString(),
                this.RowHeadersDefaultCellStyle.Font,
                rectangle,
                this.RowHeadersDefaultCellStyle.ForeColor, 
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        //protected override void OnScroll(ScrollEventArgs e)
        //{
        //    //if (this.userCharTextBox1.Visible == true)
        //    //{
        //    //    Rectangle r = this.GetCellDisplayRectangle(
        //    //        this.CurrentCell.ColumnIndex,
        //    //        this.CurrentCell.RowIndex,
        //    //        true);
        //    //    this.userCharTextBox1.Location = r.Location;
        //    //    this.userCharTextBox1.Size = r.Size;
        //    //}
        //}

        //protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        //{
        //    //if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.RowIndex != this.NewRowIndex)
        //    //{
        //    //    this.CurrentCell.Value = this.userCharTextBox1.Text;
        //    //    this.userCharTextBox1.Visible = false;

        //    //}
        //}

        //protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        //{
        //    //if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.RowIndex != this.NewRowIndex)
        //    //{
        //    //    Rectangle rect = this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        //    //    this.userCharTextBox1.Location = rect.Location;
        //    //    this.userCharTextBox1.Size = rect.Size;
        //    //    this.userCharTextBox1.Text = this.CurrentCell.Value.ToString();
        //    //    //this.userCharTextBox1.ButtonText = "click";
        //    //    //this.userCharTextBox1.renderControl();
        //    //    this.userCharTextBox1.Visible = true;

        //    //}
        //}

        //protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        //{
        //    //if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.RowIndex != this.NewRowIndex)
        //    //{
        //    //    Rectangle textRect = e.CellBounds;
        //    //    textRect.Width -= e.CellBounds.Width / 3;
        //    //    Rectangle btnRect = e.CellBounds;
        //    //    btnRect.X += textRect.Width;
        //    //    btnRect.Width = e.CellBounds.Width / 3;
        //    //    e.Paint(textRect, DataGridViewPaintParts.All);
        //    //    ControlPaint.DrawButton(e.Graphics, btnRect, ButtonState.Normal);
        //    //    StringFormat formater = new StringFormat();
        //    //    formater.Alignment = StringAlignment.Center;
        //    //    e.Graphics.DrawString("click", e.CellStyle.Font, new SolidBrush(e.CellStyle.ForeColor), btnRect, formater);
        //    //    e.Handled = true;
        //    //}
        //}

        //protected override void OnDoubleClick(EventArgs e)
        //{
        //    base.OnDoubleClick(e);

        //}

        //protected override void OnCellLeave(DataGridViewCellEventArgs e)
        //{

        //}

        //protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        //{
        //    if (DataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
        //    {
        //    }
        //}

        //protected override void OnCellEnter(DataGridViewCellEventArgs e)
        //{
        //}

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
            {
                if (!this.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    //e.CellStyle.BackColor = Color.Pink;
                }
            }

        }

        //protected override void OnCellClick(DataGridViewCellEventArgs e)
        //{
        //    if (DataGridViewIsOperated(e.RowIndex, e.ColumnIndex))
        //    {
                

        //    }

        //    //int X = this.dgvDataList.CurrentCellAddress.X;
        //    //int Y = this.dgvDataList.CurrentCellAddress.Y;

        //    //Rectangle rect = this.dgvDataList.GetCellDisplayRectangle(X, Y, false);
        //    //this.userCharTextBox1.Size = rect.Size;
        //    //this.userCharTextBox1.Text = this.dgvDataList.CurrentCell.Value.ToString();
        //    //this.userCharTextBox1.Visible = true;
        //    //this.userCharTextBox1.Focus();

        //    //this.userCharTextBox1.Location = new Point(
        //    //    (this.dgvDataList.Location.X + rect.X),
        //    //    (this.dgvDataList.Location.Y + rect.Y + 1));
        //}

        protected virtual bool DataGridViewIsOperated(int intRowIndex, int intColumnIndex)
        {
            bool isOperated = false;

            if (intRowIndex == -1 || intColumnIndex == -1)
            {
                return isOperated;
            }
            if (!this.Columns[intColumnIndex].ReadOnly ||
                !this.Rows[intRowIndex].Cells[intColumnIndex].ReadOnly)
            {
                isOperated = true;
            }
            return isOperated;
        }

        private void userCharTextBox1_Enter(object sender, EventArgs e)
        {
            userCharTextBox1.BackColor = Color.Yellow;
        }

        private void userCharTextBox1_Leave(object sender, EventArgs e)
        {
            userCharTextBox1.BackColor = SystemColors.Window;
        }


        public virtual void Clear()
        {
            this.Rows.Clear();
        }

    }
}
