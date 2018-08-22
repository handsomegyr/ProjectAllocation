using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ProjectAllocation.Controls
{
    public class UserNumberTextBox : TextBox
    {
        // Fields
        private const string C_RegularExpressions_AllFloat = @"^-?([0-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$";
        private const string C_RegularExpressions_PositiveFloat = @"^([0-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$";
        private const string C_RegularExpressions_NegativeFloat = @"^-([0-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$";

        private const string C_RegularExpressions_AllInteger = @"^-?[0-9]\d*$";
        private const string C_RegularExpressions_PositiveInteger = @"^[0-9]\d*$";
        private const string C_RegularExpressions_NegativeInteger = @"^-[0-9]\d*$";

        private int myDecimalDigits;
        private NumberStyle myStyle;
        private double myValue;
        private double myMaxValue;
        private double myMinValue;
        private bool myZeroShow;
        private bool myShowComma;

        private PositiveNegativeStyle myPositiveNegativeStyle;        

        public delegate void NumberStyleChangedEventHandler(object sender, EventArgs e);
        // Events
        [Description("Raised When NumberStyle is changed")]
        public event NumberStyleChangedEventHandler NumberStyleChanged;

        public UserNumberTextBox()
        {
            this.myStyle = NumberStyle.AllFloat;
            this.myPositiveNegativeStyle = PositiveNegativeStyle.All;
            this.myDecimalDigits = 4;
            this.myZeroShow = true;
            this.myValue = 0.0;
            this.myMaxValue = Double.MaxValue;
            this.myMinValue = Double.MinValue;
            this.myShowComma = true;

            base.Text = "";
            this.Value = 0.0;
            this.TextAlign = HorizontalAlignment.Right;

        }

        private string getDecimalDigitsString(FocusStyle enmFocus)
        {
            string str = "";
            int num = 1;
            switch (enmFocus)
            {
                case FocusStyle.GotFocus:

                    if (!this.myZeroShow)
                    {
                        str = "####";
                    }
                    else
                    {
                        str = "###0";
                    }
                    
                    break;

                case FocusStyle.LostFocus:
                    if (!this.myZeroShow)
                    {
                        str = "#,###";
                        break;
                    }
                    else
                    {
                        str = "#,##0";
                    }

                    break;
            }

            int myDecimalDigits = this.myDecimalDigits;
            for (num = 1; num <= myDecimalDigits; num++)
            {
                if (str.Trim().Contains("."))
                {
                    str = str + "0";
                }
                else
                {
                    str = str + ".0";
                }
            }
            if (!myShowComma)
            {
                str = str.Replace(",", "");
            }
            return  "{0:"+str+"}";
        }

        protected virtual bool IsValid(string strIn)
        {
            bool flag = false;
            try
            {
                strIn = strIn.Replace(",", "");
                switch (this.myStyle)
                {
                    case NumberStyle.AllInteger:
                        if (this.myPositiveNegativeStyle == PositiveNegativeStyle.All)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_AllInteger, RegexOptions.ECMAScript);
                        }
                        else if (this.myPositiveNegativeStyle == PositiveNegativeStyle.Positive)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_PositiveInteger, RegexOptions.ECMAScript);
                        }
                        else if (this.myPositiveNegativeStyle == PositiveNegativeStyle.Negative)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_NegativeInteger, RegexOptions.ECMAScript);
                        }
                        break;

                    case NumberStyle.AllFloat:
                        if (this.myPositiveNegativeStyle == PositiveNegativeStyle.All)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_AllInteger, RegexOptions.ECMAScript);
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_AllFloat, RegexOptions.ECMAScript);
                        }
                        else if (this.myPositiveNegativeStyle == PositiveNegativeStyle.Positive)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_PositiveInteger, RegexOptions.ECMAScript);
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_PositiveFloat, RegexOptions.ECMAScript);
                        }
                        else if (this.myPositiveNegativeStyle == PositiveNegativeStyle.Negative)
                        {
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_NegativeInteger, RegexOptions.ECMAScript);
                            flag |= Regex.IsMatch(strIn, C_RegularExpressions_NegativeFloat, RegexOptions.ECMAScript);
                        }
                        break;
                }
                flag = (flag | (base.Text.Trim() == string.Empty)) | (base.Text.Trim() == "0");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return flag;
        }

        protected virtual void OnNumberStyleChanged(EventArgs e)
        {
            if (!this.IsValid(base.Text))
            {
                base.Text = "";
            }
            this.Invalidate();

            if (this.NumberStyleChanged != null)
            {
                this.NumberStyleChanged(this, e);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (!this.IsValid(base.Text))
                {
                    base.Undo();
                    base.SelectionStart = base.Text.Length + 1;
                }
                else
                {
                    if (base.Text.Trim() != string.Empty)
                    {
                        var value1 = Convert.ToDouble(base.Text);
                        if (value1 < this.myMinValue)
                        {
                            base.Undo();
                            return;
                        }
                        if (value1 > this.myMaxValue)
                        {
                            base.Undo();
                            return;
                        }

                        this.myValue = value1;
                    }
                    else
                    {
                        this.myValue = 0.0;
                    }
                    if (this.myValue >= double.MaxValue)
                    {
                        this.myValue = double.MaxValue;
                    }
                    if (this.myValue <= double.MinValue)
                    {
                        this.myValue = double.MinValue;
                    }
                    
                    base.ClearUndo();
                    base.OnTextChanged(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string ShowNumber(FocusStyle focusStyle)
        {
            switch (this.myStyle)
            {
                case NumberStyle.AllInteger:
                case NumberStyle.AllFloat:
                    return String.Format(this.getDecimalDigitsString(focusStyle), this.myValue);
            }
            return "";
        }

        protected override void OnEnter(EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(base.Text))
                {
                    base.Text = this.ShowNumber(FocusStyle.GotFocus);
                }
                base.SelectionStart = 0;
                base.SelectionLength = base.Text.Length;
                base.OnEnter(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if ( e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
                if (this.myPositiveNegativeStyle == PositiveNegativeStyle.Positive)
                {
                    if (e.KeyChar == (char)Keys.Insert)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                if (((e.KeyChar <= (char)Keys.D9) && (e.KeyChar >= (char)Keys.D0))
                    || (e.KeyChar == (char)Keys.Delete)
                    || (e.KeyChar == (char)Keys.Insert))
                {
                    if (e.KeyChar == (char)Keys.Insert)
                    {
                        if ( !base.Text.Trim().Contains("-") )
                        {
                            if (base.Text.Trim() == string.Empty)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                base.Text = "-" + base.Text;
                                base.SelectionStart = base.Text.Length + 1;
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            base.Text = base.Text.Replace("-", "");
                            base.SelectionStart = base.Text.Length + 1;
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(base.Text))
                {
                    base.Text = this.ShowNumber(FocusStyle.LostFocus);
                }
                base.OnLeave(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Properties
        [Bindable(true), 
        Description("控制控件的数字显示方式"), 
        DefaultValue(4),
        Category("Digits")]
        public int DecimalDigits
        {
            get
            {
                return this.myDecimalDigits;
            }
            set
            {
                if (value < 0)
                {
                    value = this.myDecimalDigits;
                }
                this.myDecimalDigits = value;
                if (this.myDecimalDigits == 0)
                {
                    this.myStyle = NumberStyle.AllInteger;
                }
                else
                {
                    this.myStyle = NumberStyle.AllFloat;
                }
                this.Value = this.myValue;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value.Trim() == "")
                {
                    this.myValue = 0.0;
                    base.Text = value.Trim();
                }
                else if (this.IsValid(value))
                {
                    this.myValue = Math.Round(Convert.ToDouble(value), this.myDecimalDigits);
                    base.Text = String.Format(this.getDecimalDigitsString(FocusStyle.LostFocus), this.myValue);
                }
            }
        }

        [Category("数值"), 
        Bindable(true), 
        Description("控件的数值")]
        public double Value
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
                this.myValue = Math.Round(this.myValue, this.myDecimalDigits);
                base.Text = String.Format(this.getDecimalDigitsString(FocusStyle.LostFocus), this.myValue);
            }
        }

        [Category("Comma"),
        Bindable(true),
        Description("Comma show")]
        public bool ShowComma
        {
            get
            {
                return this.myShowComma;
            }
            set
            {
                this.myShowComma = value;
                this.Invalidate();
            }
        }

        [Category("PositiveNegative"),
        Bindable(true),
        Description("PositiveNegative")]
        public PositiveNegativeStyle PositiveNegativeStyle
        {
            get
            {
                return this.myPositiveNegativeStyle;
            }
            set
            {
                if (value == PositiveNegativeStyle.Positive)
                {
                    this.MinValue = 0;
                }
                else if (value == PositiveNegativeStyle.Negative)
                {
                    this.MaxValue = 0;
                }
                this.myPositiveNegativeStyle = value;
                this.Invalidate();
            }
        }

        [Category("MaxValue"),
        Bindable(true),
        Description("MaxValue")]
        public double MaxValue
        {
            get
            {
                return this.myMaxValue;
            }
            set
            {
                if (this.PositiveNegativeStyle == PositiveNegativeStyle.Positive)
                {
                    if (value < 0)
                    {
                        return;
                    }
                }
                else if (this.PositiveNegativeStyle == PositiveNegativeStyle.Negative)
                {
                    if (value > 0)
                    {
                        return;
                    }
                }

                if (value < this.MinValue)
                {
                    return;
                }
                this.myMaxValue = value;
                this.Invalidate();
            }
        }

        [Category("MinValue"),
        Bindable(true),
        Description("MinValue")]
        public double MinValue
        {
            get
            {
                return this.myMinValue;
            }
            set
            {
                if (this.PositiveNegativeStyle == PositiveNegativeStyle.Positive)
                {
                    if (value < 0)
                    {
                        return;
                    }                    
                }
                else if (this.PositiveNegativeStyle == PositiveNegativeStyle.Negative)
                {
                    if (value > 0)
                    {
                        return;
                    }
                }

                if (value > this.MaxValue)
                {
                    return;
                }

                this.myMinValue = value;
                this.Invalidate();
            }
        }
    }


}
