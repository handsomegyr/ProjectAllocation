using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public partial class DockContent : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected static Dictionary<string, List<DockContent>> _openedContents = new Dictionary<string, List<DockContent>>();
        
        public DockContent()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;
            
            Core.CoreData.CoreDataChanged += new CoreDataChangedEventHandler(CoreData_CoreDataChanged);
        }

        virtual protected void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case CoreDataType.ActiveDockContent:
            //        IDockContent ActiveContent = Core.CoreData[CoreDataType.ActiveDockContent] as IDockContent;
            //        if (ActiveContent == null)
            //        {
            //            return;
            //        }
            //        if (ActiveContent.DockHandler.PreviousActive != null)
            //        {
            //            ActiveContent.DockHandler.PreviousActive.DockHandler.Activate();
            //        }
                    
            //        break;
            //    default:
            //        break;
            //}
        }
        
        public void InvokeNotification(String propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void processNotification(String propertyName)
        {
            
        }

        protected virtual void Back()
        {
            //if (this.HideOnClose)
            //{
            //    this.Hide();
            //}
            //else
            //{
            //    this.Close();
            //}
            this.Close();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Type t = this.GetType();
            string shell = t.Assembly.ManifestModule.Name;
            if (shell != "ProjectAllocation.exe")
            {
                _openedContents.Remove(shell);
            }
            
            bool IsTaskProcessing = false;


            if (Core.CoreData[CoreDataType.IsTaskProcessing] != null)
            {
                IsTaskProcessing = (bool)Core.CoreData[CoreDataType.IsTaskProcessing];
            }

            if (IsTaskProcessing)
            {
                e.Cancel = true;
            }

        }

    }
}
