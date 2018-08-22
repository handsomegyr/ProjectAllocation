using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ProjectAllocation.Controls
{
    public class UserCharTextBox : TextBox
    {

        private const string C_RegularExpressions_A_Za_z = @"^[A-Za-z -]+$";
        private const string C_RegularExpressions_A_Za_z0_9 = @"^[A-Za-z0-9 -]+$";
        private const string C_RegularExpressions_A_Za_z0_9Chinese = @"^[A-Za-z0-9\ \u4e00-\u9fa5]+$";
        private const string C_RegularExpressions_All = @"^[A-Za-z0-9\u2e80-\u9fff\uFF00-\uFFFF\u0000-\u00FF]+$";
        private const string C_RegularExpressions_Word = @"^\w+$";
        
        // Fields
        private TextStyle myStyle;

        public delegate void TextStyleChangedEventHandler(object sender, EventArgs e);
        
        // Events
        [Description("Raised When TextStyle is changed")]
        public event TextStyleChangedEventHandler TextStyleChanged;

        public UserCharTextBox()
        {
            this.myStyle = TextStyle.All;
        }

        protected virtual bool IsValid(string strIn)
        {
            bool flag = false;
            try
            {
                switch (this.myStyle)
                {
                    case TextStyle.A_Za_z:
                        flag |= Regex.IsMatch(strIn, C_RegularExpressions_A_Za_z, RegexOptions.ECMAScript);
                        break;

                    case TextStyle.A_Za_z0_9:
                        flag |= Regex.IsMatch(strIn, C_RegularExpressions_A_Za_z0_9, RegexOptions.ECMAScript);
                        break;

                    case TextStyle.Word:
                        flag |= Regex.IsMatch(strIn, C_RegularExpressions_Word, RegexOptions.ECMAScript);
                        break;

                    case TextStyle.A_Za_z0_9Chinese:
                        flag |= Regex.IsMatch(strIn, C_RegularExpressions_A_Za_z0_9Chinese, RegexOptions.ECMAScript);
                        break;

                    case TextStyle.All:
                        flag |= Regex.IsMatch(strIn, C_RegularExpressions_All, RegexOptions.ECMAScript);
                        break;
                }
                flag |= base.Text.Trim() == string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            try
            {
                if (!this.IsValid(base.Text))
                {
                    this.Undo();
                    base.SelectionStart = base.Text.Length + 1;
                }
                else
                {
                    this.ClearUndo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual void OnTextStyleChanged(EventArgs e)
        {
            if (!this.IsValid(base.Text))
            {
                base.Text = "";
            }
            this.Invalidate();

            //Raise outSide Events;
            if (this.TextStyleChanged != null)
            {
                this.TextStyleChanged(this, e);
            }
        }

        // Properties
        [Bindable(true), 
        Description("Data Style"), 
        Category("Style"),
        DefaultValue(TextStyle.All)]
        public TextStyle Style
        {
            get
            {
                return this.myStyle;
            }
            set
            {
                this.myStyle = value;
                this.OnTextStyleChanged(EventArgs.Empty);
            }
        }
        
    }
}
