using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;
using ProjectAllocationFramework;

namespace ProjectAllocationFramework.Notify
{
    struct NotifyMessage
    {
        public string Message;
        public string Url;
    }

    class NotifyManager
    {
        static NotifyIcon sysIcon;
        [ThreadStatic()]
        static NotifyMessage nMessage;

        static NotifyManager()
        {
            nMessage = new NotifyMessage();
        }

        public static NotifyIcon InitSysIcon(IContainer Container)
        {
            sysIcon = new NotifyIcon(Container);
            sysIcon.Visible = true;
            sysIcon.Icon = ProjectAllocationResource.Resource.Action_button_info;
            sysIcon.BalloonTipClicked += new EventHandler(sysIcon_BalloonTipClicked);
            sysIcon.BalloonTipClosed += new EventHandler(sysIcon_BalloonTipClosed);
            sysIcon.Click += new EventHandler(sysIcon_Click);
            sysIcon.ContextMenuStrip = new NotifyIconContextMenu(sysIcon.Container);
            sysIcon.Text = "ProjectAllocation";
            return sysIcon;
        }

        private static void sysIcon_Click(object sender, EventArgs e)
        {
            Form main = Core.CoreData[CoreDataType.ApplicationForm] as Form;
            if (main == null)
            { return; }
            main.Visible = true;
            main.WindowState = FormWindowState.Maximized;
            main.Activate();
        }

        private static void sysIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            nMessage.Message = null;
            nMessage.Url = null;
        }

        private static void sysIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void NotifyMessage(string title,string message, string Url)
        {
            if (sysIcon == null)
            { return; }
            nMessage.Message = message;
            nMessage.Url = Url;
            sysIcon.BalloonTipTitle = title;
            sysIcon.BalloonTipText = message;
            sysIcon.ShowBalloonTip(30);
        }
    }
}
