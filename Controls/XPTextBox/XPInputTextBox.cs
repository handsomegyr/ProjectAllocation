using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ProjectAllocation.Controls
{
	[ToolboxBitmap(typeof(ProjectAllocation.Controls.XPInputTextBox), "XPTextBox.bmp")]
    public class XPInputTextBox : System.Windows.Forms.TextBox
	{
		public const int WM_ERASEBKGND = 0x14;
		public const int WM_PAINT = 0xF;
		public const int WM_NC_PAINT = 0x85;
		public const int WM_PRINTCLIENT = 0x318;

		[DllImport("user32.dll", EntryPoint="SendMessageA")]
		public static extern int SendMessage (IntPtr hwnd, uint wMsg, IntPtr wParam, object lParam);

		[DllImport("user32")]
		public static extern IntPtr GetWindowDC (IntPtr hWnd );

		[DllImport("user32")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC );

		private Color colorLine = Color.FromArgb(215, 223, 232);
        
		private bool bHaveMouse = false;
        private string sTempString = "";
        private MaskTypes masktype = MaskTypes.None;

        public delegate void EnterKeyEventHandler(object sender, System.Windows.Forms.KeyPressEventArgs e);

        private EnterKeyEventHandler eventHandler = null;

        public event EnterKeyEventHandler EnterKey
        {
            add
            {
                eventHandler += value;
            }
            remove
            {
                eventHandler -= value;
            }
        }

        public XPInputTextBox()	: base()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.BorderStyle = BorderStyle.None;
//			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.XPInputTextBox_KeyUp);
			this.MouseEnter += new System.EventHandler(this.XPInputTextBox_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.XPInputTextBox_MouseLeave);
            this.GotFocus += new System.EventHandler(this.InputTextBox_GotFocus);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTextBox_KeyPress);

        }

		public Color BorderColor
		{
			get
			{
				return colorLine;
			}
			set
			{
				colorLine = value;
                this.Invalidate();

                //Invalidate(this.ClientRectangle);
			}
		}

        //protected override void WndProc(ref Message m)
        //{
        //    IntPtr hDC = GetWindowDC(this.Handle);
        //    Graphics gdc = Graphics.FromHdc(hDC);
        //    switch (m.Msg)
        //    {
        //        case WM_NC_PAINT:
        //            SendMessage(this.Handle, WM_ERASEBKGND, hDC, 0);
        //            SendPrintClientMsg();	// send to draw client area
        //            PaintFlatControlBorder(gdc);
        //            m.Result = (IntPtr)1;	// indicate msg has been processed			
        //            break;
        //        case WM_PAINT:
        //            base.WndProc(ref m);
        //            PaintFlatControlBorder(gdc);
        //            break;
        //        default:
        //            base.WndProc(ref m);
        //            break;
        //    }
        //    ReleaseDC(m.HWnd, hDC);
        //    gdc.Dispose();
        //}

		private void SendPrintClientMsg()
		{
			// We send this message for the control to redraw the client area
			Graphics gClient = this.CreateGraphics();
			IntPtr ptrClientDC = gClient.GetHdc();
			SendMessage(this.Handle, WM_PRINTCLIENT, ptrClientDC, 0);
			gClient.ReleaseHdc(ptrClientDC);
			gClient.Dispose();
		}

		private void PaintFlatControlBorder(Graphics g)
		{
			if(!this.ReadOnly && this.Enabled && (this.bHaveMouse || this.Focused))
			{
//				int intStartX = Convert.ToInt32(BorderWidth / 2);
//				int intStartY =  Convert.ToInt32(BorderWidth / 2);
//				int intEndX = this.Size.Width -  Convert.ToInt32(BorderWidth * 2);
//				int intEndY = this.Size.Height - Convert.ToInt32(BorderWidth * 2);
//
//				Rectangle[] Outlines = new Rectangle[] { new Rectangle(intStartX,intStartY,intEndX,intEndY) };
//				g.DrawRectangles(new Pen(colorLine, BorderWidth), Outlines);

				int intStartX = 0;
				int intStartY = 0;
				int intEndX = this.Size.Width - 1;
				int intEndY = this.Size.Height - 1;

				Rectangle rect = new Rectangle(intStartX, intStartY, intEndX, intEndY);
				g.DrawRectangle(new Pen(colorLine), rect);

			}
		}

		private void XPInputTextBox_MouseEnter(object sender, System.EventArgs e)
		{
			this.bHaveMouse = true;
			this.Invalidate();
//			Invalidate(this.ClientRectangle);
		}

		private void XPInputTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.Invalidate();
//			Invalidate(this.ClientRectangle);
		}
		
		private void XPInputTextBox_MouseLeave(object sender, System.EventArgs e)
		{
			this.bHaveMouse = false;
			this.Invalidate();
//			Invalidate(this.ClientRectangle);
		}

		protected override void OnLostFocus(System.EventArgs e)
		{
			this.bHaveMouse = false;
			base.OnLostFocus(e);
			this.Invalidate();
//			Invalidate(this.ClientRectangle);
		}

		protected override void OnGotFocus(System.EventArgs e)
		{
			this.bHaveMouse = true;
			base.OnGotFocus(e);
			this.Invalidate();
//			Invalidate(this.ClientRectangle);
		}

        public MaskTypes MaskType
        {
            get
            {
                return this.masktype;
            }
            set
            {
                this.masktype = value;
            }
        }

        private void InputTextBox_GotFocus(object sender, System.EventArgs e)
        {
            this.sTempString = this.Text;
        }

        private void InputTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13 && this.Text != this.sTempString)
            {
                this.Modified = !this.Modified;
                this.sTempString = this.Text;
            }

            if (e.KeyChar == (Char)8 || e.KeyChar == (Char)13)
            {
                if (e.KeyChar == (Char)13 && eventHandler != null)
                {
                    Invoke(eventHandler, new object[] { this, e });
                }
                if (e.KeyChar == (char)13)
                {
                    SendKeys.Send("{TAB}");
                }

                return;
            }
            e.Handled = MaskNumber(e.KeyChar, this.Text);
        }

        private bool MaskNumber(Char KeyChar, string Text)
        {
            if (this.MaskType == MaskTypes.None) return false;

            if (this.MaskType == MaskTypes.Float)
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

            if (this.MaskType == MaskTypes.Int)
            {
                if (Char.IsDigit(KeyChar)) return false;
                return true;
            }

            if (this.MaskType == MaskTypes.Date)
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
            return true;
        }

        private static int ContainCharNumber(string str, string Char)
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

	}

    public enum MaskTypes { None, Int, Float, Date };

}
