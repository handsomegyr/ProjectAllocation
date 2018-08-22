using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ProjectAllocationFramework;
using System.IO;
using ProjectAllocationBusiness.Business;
using ProjectAllocationBusiness;
using System.Security.Permissions;
using ProjectAllocationUtil.Win32;
using ProjectAllocationUtil;
using System.Threading;
using System.Drawing;

namespace ProjectAllocation
{
    public partial class frmProjectAllocation : frmMain
    {
        MenuItemTreePanel _menuItemTreePanel;
        
        public frmProjectAllocation()
        {
            InitializeComponent();
            this.Icon = ProjectAllocationResource.Resource.ProjectAllocationApp;
            this.Font = Constant.ProjectAllocationFont;

            initialize();

            CreateMDIForm();
            Core.CoreData[CoreDataType.ApplicationForm] = this;
            //ProjectAllocationNotifyManager.InitSysIcon(this.components);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            //SetDockPanelSize();
            if (this.panel1.Height < 46)
            {
                this.panel1.Height = 46;
            }
            picCompanyName.Top = this.panel1.Height - picCompanyName.Height - 3;
        }

        private void SetDockPanelSize()
        {
            if (this.panel1 != null && this.dockPanel != null && this.statusStrip1 != null)
            {
                this.dockPanel.Top = this.panel1.Top + this.panel1.Height;
                this.dockPanel.Height = this.statusStrip1.Top - this.dockPanel.Top;
                this.dockPanel.Width = this.Width-6;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.Hide();
            }
            base.OnResize(e);

            
            //SetDockPanelSize();
            
        }

        private void OnActiveContentChanged(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                Core.CoreData[CoreDataType.ActiveDockContent] = this.dockPanel.ActiveDocument;
            });
            t.Start();
        }

        private void CreateMDIForm()
        {
            _menuItemTreePanel = new MenuItemTreePanel();
        }

        private void LoadMDIForm()
        {
            Core.CoreData[CoreDataType.ActiveDockPanel] = this.dockPanel;
            _menuItemTreePanel.Show(this.dockPanel);
        }

        private void initialize()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.lblSystemName.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _openedContents.Clear();
            picCompanyIcon.BackgroundImage = ProjectAllocationResource.Resource.nikon;
            //picCompanyIcon.Size = ProjectAllocationResource.Resource.nikon.Size;
            //this.panel1.BringToFront();

            picCompanyName.BackgroundImage = ProjectAllocationResource.Resource.Company;
            picCompanyName.Size = ProjectAllocationResource.Resource.Company.Size;
            picCompanyName.Top = this.panel1.Height - picCompanyName.Height - 3;
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.dockPanel.Dock = DockStyle.None;

            
            this.dockPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel.ActiveContentChanged += new EventHandler(OnActiveContentChanged);

            tsslExit.Image = ProjectAllocationResource.Resource.exit1;
            tsslServerDBInfo.Image = ProjectAllocationResource.Resource.display;
            tsslUserInfo.Image = ProjectAllocationResource.Resource.Login_Manager;
            tsslDateInfo.Image = ProjectAllocationResource.Resource.clock1;
            tsslVersionInfo.Image = ProjectAllocationResource.Resource.openoffice;
            tsslServerDBInfo.Text = ConfigUtil.GetServerDBInfo();
            tsslUserInfo.Text = string.Format("User:{0}", User.Operator.UserName);
            tsslDateInfo.Text = string.Format("Date:{0}", DateTime.Now.Date.ToShortDateString());
            tsslVersionInfo.Text = string.Format("Version:{0}", Application.ProductVersion);
        }

        private void frmProjectAllocation_Load(object sender, EventArgs e)
        {
            LoadMDIForm();
        }


        protected override void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.MenuItemSelected:
                    MenuItemChanged();
                    break;
                default:
                    break;
            }

        }

        private void MenuItemChanged()
        {
            UserMenuItem menuItem = Core.CoreData[CoreDataType.MenuItemSelected] as UserMenuItem;

            if (!string.IsNullOrEmpty(menuItem.Shell))
            {
                List<DockContent> contents = null;
                if (!_openedContents.ContainsKey(menuItem.Shell))
                {
                    //if not exists
                    string assemblyName = Path.Combine(Application.StartupPath, menuItem.Shell);
                    IEntry instance = ApplicationDispatcher.GetInstance(assemblyName, new String[] { "" });
                    contents = instance.GetContents(null);
                    _openedContents.Add(menuItem.Shell, contents);
                }

                if (_openedContents.ContainsKey(menuItem.Shell))
                {
                    //if exists
                    contents = _openedContents[menuItem.Shell];
                }

                if (contents != null)
                {
                    foreach (var item in contents)
                    {
                        item.Show(this.dockPanel);

                    }
                }
            }
        }

        private void tsslExit_Click(object sender, EventArgs e)
        {
            if (MessageUtil.QuestionMessage(ProjectAllocationResource.Message.Exit_Info, this.Text) == DialogResult.Cancel)
            {
                return;
            }

            this.Close();

        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Msgs.WM_CLOSE)
            {
                Application.Exit();
                return;
            }
            else if (m.Msg == (int)Msgs.WM_NCLBUTTONDBLCLK)
            {
                uint result = NativeMethods.SendMessage(this.Handle, (int)Msgs.WM_NCHITTEST, 0, (uint)m.LParam);
                if (result == 2)	// HITTEST_CAPTION
                {
                    return;
                }
            }
            
            base.WndProc(ref m);
        }

       
    }
}
