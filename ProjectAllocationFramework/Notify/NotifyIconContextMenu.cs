using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using ProjectAllocationFramework;

namespace ProjectAllocationFramework.Notify
{
    public partial class NotifyIconContextMenu : ContextMenuStrip
    {
        public NotifyIconContextMenu()
        {
            InitializeComponent();
        }

        public NotifyIconContextMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            //CommandBase command = CommandManager.GetCommand(CommandFamily.Command_CloseSystem);
            //command.Execute(this, null);
        }

        private void OpenApplication(object sender, EventArgs e)
        {
            Form main = Core.CoreData[CoreDataType.ApplicationForm] as Form;
            if (main == null)
            { return; }
            main.Visible = true;
        }       
    }
}
