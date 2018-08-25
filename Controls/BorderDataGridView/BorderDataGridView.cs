using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ProjectAllocation.Controls
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataGridView))]
    public class BorderDataGridView : System.Windows.Forms.DataGridView
    {
        public const string C_RegularExpressions_A_Za_z = @"^[A-Za-z \-]+$";
        public const string C_RegularExpressions_A_Za_z0_9 = @"^[A-Za-z0-9]+$";
        public const string C_RegularExpressions_A_Za_z0_9_With_Specail_Chars = @"^[A-Za-z0-9 \-()]+$";
        public const string C_RegularExpressions_A_Za_z0_9Chinese = @"^[A-Za-z0-9 \-()\u4e00-\u9fa5]+$";
        public const string C_RegularExpressions_All = @"^[A-Za-z0-9 \-\u2e80-\u9fff\uFF00-\uFFFF\u0000-\u00FF]+$";
        public const string C_RegularExpressions_Word = @"^\w+$";

        public const int WM_ERASEBKGND = 0x14;
        public const int WM_PAINT = 0xF;
        public const int WM_NC_PAINT = 0x85;
        public const int WM_PRINTCLIENT = 0x318;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, object lParam);

        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private Color borderColor = Color.FromArgb(158, 182, 206);
        Image imgColumnHeader = null;
        Image imgSortAscending = null;
        Image imgSortDescending = null;

        Image imgCurrent = null;
        Image imgEdit = null;
        Image imgNewRow = null;
        Image imgCurrentNew = null;

        public BorderDataGridView()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(BorderDataGridView));
            imgColumnHeader = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.Header.png"));
            imgSortAscending = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.Ascending.gif"));
            imgSortDescending = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.Descending.gif"));

            imgCurrent = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.Current.gif"));
            imgEdit = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.Edit.gif"));
            imgNewRow = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.NewRow.gif"));
            imgCurrentNew = new Bitmap(assembly.GetManifestResourceStream("ProjectAllocation.Controls.Resources.CurrentNew.gif"));

            this.BackgroundColor = Color.White;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = ControlPaint.ProjectAllocationFont;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(193)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeight = 22;
            this.RowHeadersWidth = 22;
            this.GridColor = Color.FromArgb(208, 215, 229);
            this.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            //if (Environment.OSVersion.Version.Major < 6)
            //{   //Vista
            this.CellPainting += new DataGridViewCellPaintingEventHandler(BorderDataGridView_CellPainting);
            //}
            this.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(BorderDataGridView_ColumnHeaderMouseClick);
        }

        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        //protected override void WndProc(ref Message m)
        //{
        //    IntPtr hDC = GetWindowDC(this.Handle);
        //    Graphics gdc = Graphics.FromHdc(hDC);
        //    switch (m.Msg)
        //    {
        //        case WM_PAINT:
        //            base.WndProc(ref m);
        //            DrawBorder(gdc);
        //            break;
        //        default:
        //            base.WndProc(ref m);
        //            break;
        //    }
        //    ReleaseDC(m.HWnd, hDC);
        //    gdc.Dispose();
        //}

        private void DrawBorder(Graphics g)
        {
            if (this.BorderStyle != BorderStyle.None)
            {
                int intStartX = 0;
                int intStartY = 0;
                int intEndX = this.Size.Width - 1;
                int intEndY = this.Size.Height - 1;

                Rectangle rect = new Rectangle(intStartX, intStartY, intEndX, intEndY);
                g.DrawRectangle(new Pen(borderColor), rect);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(TextBoxKeyPress);
            e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBoxKeyPress);
            e.Control.Validating -= new System.ComponentModel.CancelEventHandler(TextBoxValidating);
            e.Control.Validating += new System.ComponentModel.CancelEventHandler(TextBoxValidating);
        }

        private void TextBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;
                if (control != null)
                {
                    Type t = this.Columns[this.CurrentCell.ColumnIndex].ValueType;                   

                    var isCancel = false;

                    if (!isCancel && this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle != null && this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle.Tag != null)
                    {
                        if (t == typeof(decimal) || t == typeof(Single) || t == typeof(Double) || t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64) || t == typeof(UInt16) || t == typeof(UInt32) || t == typeof(UInt64) || t == typeof(Byte) || t == typeof(SByte))
                        {
                            double dblRet = 0;
                            if (!double.TryParse(control.Text, out dblRet))
                            {
                                isCancel = true;
                            }
                            string[] sArray = this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle.Tag.ToString().Split('|');

                            if (dblRet <double.Parse(sArray[0])  || dblRet > double.Parse(sArray[1]))
                            {
                                isCancel = true;
                            }
                        }
                        else
                        {
                            //isCancel = !Regex.IsMatch(control.Text, this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle.Tag.ToString(), RegexOptions.ECMAScript);
                        }
                    }

                    e.Cancel = isCancel;
                    if (isCancel)
                    {

                        this.CancelEdit();
                    }
                }
            }
            catch { }
        }

        private void TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Backspace Enter
            if (e.KeyChar == (Char)8 || e.KeyChar == (Char)13) return;

            try
            {
                System.Windows.Forms.Control control = sender as System.Windows.Forms.Control;                
                if (control != null)
                {                    
                    Type t = this.Columns[this.CurrentCell.ColumnIndex].ValueType;

                    var handled = MaskNumber(e.KeyChar, t, control.Text);

                    if (!handled && this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle!=null && this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle.Tag != null)
                    {
                        if (t == typeof(decimal) || t == typeof(Single) || t == typeof(Double) || t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64) || t == typeof(UInt16) || t == typeof(UInt32) || t == typeof(UInt64) || t == typeof(Byte) || t == typeof(SByte))
                        {
                            //double dblRet = 0;
                            //if (!double.TryParse(control.Text + e.KeyChar.ToString(), out dblRet))
                            //{
                            //    handled = true;
                            //}
                            //if (dblRet < 0 || dblRet > 100)
                            //{
                            //    handled = true;
                            //}
                        }
                        else
                        {
                            handled = !Regex.IsMatch(e.KeyChar.ToString(), this.Columns[this.CurrentCell.ColumnIndex].DefaultCellStyle.Tag.ToString(), RegexOptions.ECMAScript);
                        }
                    }
                    e.Handled = handled;
                }
            }
            catch { }
        }

 
        private bool MaskNumber(Char KeyChar, Type t, string Text)
        {
            //
            if (t == typeof(decimal) || t == typeof(Single) || t == typeof(Double))
            {
                int intIndex = Text.IndexOf(".");

                if (intIndex < 0)
                {
                    if (Char.IsDigit(KeyChar) || KeyChar == '.') return false;
                }
                else
                {
                    if (Char.IsDigit(KeyChar)) return false;
                }

                intIndex = Text.IndexOf("-");

                if (intIndex < 0)
                {
                    if (Char.IsDigit(KeyChar) || KeyChar == '-') return false;
                }
                else
                {
                    if (Char.IsDigit(KeyChar)) return false;
                }
                return true;
            }

       
            if (t == typeof(Int16) || t == typeof(Int32) || t == typeof(Int64) || t == typeof(UInt16) || t == typeof(UInt32) || t == typeof(UInt64) || t == typeof(Byte) || t == typeof(SByte))
            {
                if (Char.IsDigit(KeyChar)) return false;
                return true;
            }

            if (t == typeof(System.DateTime))
            {
                int intIndex = Text.IndexOf("-");
                int intIndex1 = Text.IndexOf("/");

                if (intIndex < 0 && intIndex1 < 0)
                {
                    if (Char.IsDigit(KeyChar) || KeyChar == '-' || KeyChar == '/') return false;
                }
                else
                {
                    if (intIndex > 0)
                    {
                        if (ContainCharNumber(Text, "-") == 1)
                        {
                            if (Char.IsDigit(KeyChar) || KeyChar == '-') return false;
                        }
                        else
                        {
                            if (Char.IsDigit(KeyChar)) return false;
                        }
                        return true;
                    }
                    if (intIndex1 > 0)
                    {
                        if (ContainCharNumber(Text, "/") == 1)
                        {
                            if (Char.IsDigit(KeyChar) || KeyChar == '/') return false;
                        }
                        else
                        {
                            if (Char.IsDigit(KeyChar)) return false;
                        }
                        return true;
                    }
                    if (Char.IsDigit(KeyChar)) return false;
                }
                return true;
            }

            return false;
        }

        private int ContainCharNumber(string str, string Char)
        {
            if (str.Length < 1) return 0;

            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == Char)
                {
                    j++;
                }
            }

            return j;
        }


        private void BorderDataGridView_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {   

                TekenAchtergrond(e.Graphics, imgColumnHeader, e.CellBounds, 1);
                StringFormat format1;

                format1 = new StringFormat();
                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                SizeF ef1 = e.Graphics.MeasureString((string)e.Value, this.Font, new SizeF((Single)e.CellBounds.Width, (Single)e.CellBounds.Height), format1);

                Size txts = System.Drawing.Size.Empty;

                txts = System.Drawing.Size.Ceiling(ef1);
                e.CellBounds.Inflate(-4, -4);

                Rectangle txtr = e.CellBounds;

                txtr = HAlignWithin(txts, txtr, ContentAlignment.MiddleCenter);
                txtr = VAlignWithin(txts, txtr, ContentAlignment.MiddleCenter);
                Brush brush2;

                format1 = new StringFormat();
                format1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                brush2 = new SolidBrush(Color.FromArgb(39, 66, 62));

                e.Graphics.DrawString((string)e.Value, this.Font, brush2, (RectangleF)txtr, format1);
                brush2.Dispose();
                Pen pen = new Pen(Color.FromArgb(158, 182, 206));
                Rectangle recBorder = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1);
                if (this.BorderStyle == BorderStyle.None)
                {
                    e.Graphics.DrawRectangle(pen, recBorder);
                }
                else
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                    e.Graphics.DrawLine(pen, e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                    e.Graphics.DrawLine(pen, e.CellBounds.X  + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }

                if (SortedColumnIndex >= 0 && e.ColumnIndex == SortedColumnIndex)
                {
                    Image image = null;
                    if (this.SortOrder == SortOrder.Ascending)
                    {
                        image = imgSortAscending;

                    }
                    if (this.SortOrder == SortOrder.Descending)
                    {
                        image = imgSortDescending;
                    }

                    if(image != null)
                    {
                        int x = 0;
                        int y = 0;
                        if (e.CellBounds.Width > 16)
                        {
                            x = e.CellBounds.X + e.CellBounds.Width - 16;
                        }
                        else
                        {
                            x = e.CellBounds.X;
                        }
                        if (e.CellBounds.Height > image.Height)
                        {
                            y = e.CellBounds.Y + (e.CellBounds.Height - image.Height) / 2;
                        }
                        else
                        {
                            y = e.CellBounds.Y;
                        }

                        e.Graphics.DrawImage(image, x, y, image.Width, image.Height);
                    }
                }
                e.Handled = true;
            }

            if (e.ColumnIndex == -1)
            {   
                TekenAchtergrond(e.Graphics, imgColumnHeader, e.CellBounds, 1);

                Pen pen = new Pen(Color.FromArgb(158, 182, 206));
                Rectangle recBorder = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height - 1);
                if (this.BorderStyle == BorderStyle.None)
                {
                    e.Graphics.DrawRectangle(pen, recBorder);
                }
                else
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.X - 1, e.CellBounds.Y, e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                    e.Graphics.DrawLine(pen, e.CellBounds.X - 1, e.CellBounds.Y + e.CellBounds.Height - 1, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                    e.Graphics.DrawLine(pen, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y, e.CellBounds.X + e.CellBounds.Width - 1, e.CellBounds.Y + e.CellBounds.Height - 1);
                }
                
                if (e.RowIndex >= 0)
                {
                    Image image = null;
                    if (this.Rows[e.RowIndex].IsNewRow)
                    {
                        image = imgNewRow;
                    }
                    if (this.CurrentCell != null)
                    { 
                        if (this.CurrentCell.RowIndex == e.RowIndex && this.Rows[e.RowIndex].IsNewRow)
                        {
                            image = imgCurrentNew;
                        }
                        else if (this.CurrentCell.RowIndex == e.RowIndex && this.CurrentCell.IsInEditMode)
                        {
                            image = imgEdit;
                        }
                        else if (this.CurrentCell.RowIndex == e.RowIndex)
                        {
                            image = imgCurrent;
                        }
                    }

                    if (image != null)
                    {
                        int x = 0;
                        int y = 0;
                        if (e.CellBounds.Width > 16)
                        {
                            x = e.CellBounds.X + e.CellBounds.Width - 16;
                        }
                        else
                        {
                            x = e.CellBounds.X;
                        }
                        if (e.CellBounds.Height > image.Height)
                        {
                            y = e.CellBounds.Y + (e.CellBounds.Height - image.Height) / 2;
                        }
                        else
                        {
                            y = e.CellBounds.Y;
                        }

                        e.Graphics.DrawImage(image, x, y, image.Width, image.Height);
                    }
                }
                e.Handled = true;
            }
                        
        }

        private int SortedColumnIndex = -1;

        private void BorderDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortedColumnIndex = e.ColumnIndex;
        }
        
        private ContentAlignment anyBottom = (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft);
        private ContentAlignment anyRight = (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight);
        private ContentAlignment anyCenter = (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter);
        private ContentAlignment anyMiddle = (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft);
        private ContentAlignment anyTop = (ContentAlignment.TopRight | ContentAlignment.TopCenter | ContentAlignment.TopLeft);

        private Rectangle HAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {
            if ((align & anyRight) != (ContentAlignment)0)
            {
                withinThis.X = withinThis.X + withinThis.Width - alignThis.Width;
            }
            else if ((align & anyCenter) != (ContentAlignment)0)
            {
                withinThis.X = withinThis.X + ((withinThis.Width - alignThis.Width) + 1) / 2;
            }
            withinThis.Width = alignThis.Width;
            return withinThis;
        }

        private Rectangle VAlignWithin(Size alignThis, Rectangle withinThis, ContentAlignment align)
        {

            if ((align & anyBottom) != (ContentAlignment)0)
            {
                withinThis.Y = withinThis.Y + withinThis.Height - alignThis.Height + 1;
            }
            else if ((align & anyMiddle) != (ContentAlignment)0)
            {
                withinThis.Y = withinThis.Y + (withinThis.Height - alignThis.Height + 1) / 2 + 1;
            }
            withinThis.Height = alignThis.Height;
            return withinThis;
        }

        private void TekenAchtergrond(Graphics g, Image obj, Rectangle r, int index)
        {
            if (obj == null) return;

            int oWidth  = obj.Width;
            Rectangle lr  = Rectangle.FromLTRB(0, 0, 0, 0);

            Rectangle r1, r2;
            int x = ((index - 1) * oWidth);
            int y  = 0;
            int x1 = r.Left;
            int y1 = r.Top;

            if ((r.Height > obj.Height) && (r.Width <= oWidth))
            {
                r1 = new Rectangle(x, y, oWidth, lr.Top);
                r2 = new Rectangle(x1, y1, r.Width, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, (y + lr.Top), oWidth, (obj.Height - (lr.Top - lr.Bottom)));
                r2 = new Rectangle(x1, (y1 + lr.Top), r.Width, (r.Height - (lr.Top - lr.Bottom)));
                if (lr.Top + lr.Bottom == 0)
                {
                    r1.Height = r1.Height - 1;
                }
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x, y + obj.Height - lr.Bottom, oWidth, lr.Bottom);
                r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, r.Width, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
            else if ((r.Height <= obj.Height) && (r.Width > oWidth))
            {
                r1 = new Rectangle(x, y, lr.Left, obj.Height);
                r2 = new Rectangle(x1, y1, lr.Left, r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x + lr.Left, y, oWidth - lr.Left + lr.Right, obj.Height);
                r2 = new Rectangle(x1 + lr.Left, y1, r.Width - lr.Left + lr.Right, r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                r1 = new Rectangle(x + oWidth - lr.Right, y, lr.Right, obj.Height);
                r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, r.Height);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
            else if ((r.Height <= obj.Height) && (r.Width <= oWidth))
            {
                r1 = new Rectangle((index - 1) * oWidth, 0, oWidth, obj.Height - 1);
                g.DrawImage(obj, new Rectangle(x1, y1, r.Width, r.Height), r1, GraphicsUnit.Pixel);
            }
            else if ((r.Height > obj.Height) && (r.Width > oWidth))
            {
                //top-left
                r1 = new Rectangle(x, y, lr.Left, lr.Top);
                r2 = new Rectangle(x1, y1, lr.Left, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                //top-bottom
                r1 = new Rectangle(x, y + obj.Height - lr.Bottom, lr.Left, lr.Bottom);
                r2 = new Rectangle(x1, y1 + r.Height - lr.Bottom, lr.Left, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                //left
                r1 = new Rectangle(x, y + lr.Top, lr.Left, obj.Height - r.Top + lr.Bottom);
                r2 = new Rectangle(x1, (y1 + lr.Top), lr.Left, (r.Height - (lr.Top - lr.Bottom)));
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                //top
                r1 = new Rectangle(x + lr.Left, y, oWidth - lr.Left + lr.Right, lr.Top);
                r2 = new Rectangle((x1 + lr.Left), y1, (r.Width - (lr.Left - lr.Right)), lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                
                //right-top
                r1 = new Rectangle(x + oWidth - lr.Right, y, lr.Right, lr.Top);
                r2 = new Rectangle(x1 + r.Width - lr.Right, y1, lr.Right, lr.Top);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                //Right
                r1 = new Rectangle(x + oWidth - lr.Right, y + lr.Top, lr.Right, obj.Height - lr.Top + lr.Bottom);
                r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + lr.Top, lr.Right, r.Height - lr.Top + lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);

                //right-bottom
                r1 = new Rectangle(x + oWidth - lr.Right, y + obj.Height - lr.Bottom, lr.Right, lr.Bottom);
                r2 = new Rectangle(x1 + r.Width - lr.Right, y1 + r.Height - lr.Bottom, lr.Right, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                
                //bottom
                r1 = new Rectangle(x + lr.Left, y + obj.Height - lr.Bottom, oWidth - lr.Left + lr.Right, lr.Bottom);
                r2 = new Rectangle(x1 + lr.Left, y1 + r.Height - lr.Bottom, r.Width - lr.Left + lr.Right, lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
                
                //Center
                r1 = new Rectangle(x + lr.Left, y + lr.Top, oWidth - lr.Left + lr.Right, obj.Height - lr.Top + lr.Bottom);
                r2 = new Rectangle(x1 + lr.Left, y1 + lr.Top, r.Width - lr.Left + lr.Right, r.Height - lr.Top + lr.Bottom);
                g.DrawImage(obj, r2, r1, GraphicsUnit.Pixel);
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderDataGridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = ControlPaint.ProjectAllocationFont;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = ControlPaint.ProjectAllocationFont;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = ControlPaint.ProjectAllocationFont;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.RowTemplate.Height = 21;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
