using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;

namespace ProjectAllocationLayout.Statues
{
    public partial class StatusStrip : System.Windows.Forms.StatusStrip, IStatusStrip
    {
        private volatile bool isBusy;

        public StatusStrip()
        {
            InitializeComponent();
            this.toolStripProgressBar.Maximum = Constant.ProgressBarMaximum;
        }

        public StatusStrip(IContainer container) : this()
        {
            container.Add(this);
        }
 

        [Browsable(false)]
        public int Percentage
        {
            set
            {
                int percentageValue = value;
                if (percentageValue > 100)
                {
                    percentageValue = percentageValue % Constant.ProgressBarMaximum;
                }
                SetMessage(this.toolStripProgressBar, percentageValue);
            }
        }

        [Browsable(false)]
        public string TaskMessage
        {
            set
            {
                SetMessage(this.toolStripTaskName, value);
            }
        }

        [Browsable(false)]
        public string InfomationMessage
        {
            set
            {
                SetMessage(this.toolStripPrimaryInfo, value);
            }
        }

        private static void SetMessage(ToolStripItem item, object Message)
        {
            if (item == null || Message == null)
            {
                return;
            }
            Control control = item.Owner;
            if (control == null)
            {
                return;
            }
            if (item is ToolStripProgressBar)
            {
                if (control.InvokeRequired)
                {
                    control.BeginInvoke(new ThreadStart(delegate()
                    {
                        ChangeProgressBar(item, Message);
                    }));
                }
                else
                {
                    ChangeProgressBar(item, Message);
                }
            }
            else
            {
                try
                {
                    if (control.InvokeRequired)
                    {
                        control.BeginInvoke(new ThreadStart(delegate()
                        {
                            changeProgressInfo(item, Message);
                        }));
                    }
                    else
                    {
                        changeProgressInfo(item, Message);
                    }
                }
                catch
                { }
            }

            try
            {
                if (control.InvokeRequired)
                {
                    control.BeginInvoke(new ThreadStart(delegate()
                    {
                        control.Refresh();
                    }));
                }
                else
                {
                    control.Refresh();
                }
            }
            catch
            { }
        }

        private static void changeProgressInfo(ToolStripItem item, object Message)
        {
            ToolStripStatusLabel itemInfo = (ToolStripStatusLabel)item;
            itemInfo.Visible = true;
            itemInfo.Text = Message.ToString();

        }

        private static void ChangeProgressBar(ToolStripItem item, object Message)
        {
            int value = (int)Message;
            ToolStripProgressBar bar = (ToolStripProgressBar)item;
            if (value >= 100 || value == 0)
            {
                bar.Visible = false;
            }
            else
            {
                bar.Visible = true;
            }

            bar.Value = value;
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

    }
}
