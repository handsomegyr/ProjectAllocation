using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using ProjectAllocationFramework;
using System.IO;
using System.Reflection;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;
using System.Linq;

namespace ProjectAllocation
{
    public partial class MenuDataTreeView : TreeView
    {
        private List<UserMenuItem> myMenuItem = new List<UserMenuItem>();
        public MenuDataTreeView()
        {
            InitializeComponent();
            this.Font = Constant.ProjectAllocationFont;

            Initialize();
        }

        public MenuDataTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Initialize();
        }

        public void LoadMenu()
        {
            ReadMenuItemFormXML();

            ShowMenu();
            
        }

        private void Initialize()
        {
            Core.CoreData.CoreDataChanged += new CoreDataChangedEventHandler(CoreData_CoreDataChanged);
            this.treeViewIcoList.Images.Add("Programas_close", ProjectAllocationResource.Resource.folder_locked);
            this.treeViewIcoList.Images.Add("Programas_open", ProjectAllocationResource.Resource.folder_grey_open);
        }

        private void ReadMenuItemFormXML()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xmlStream = assembly.GetManifestResourceStream(typeof(MenuDataTreeView), "Menu.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlStream);

            myMenuItem.Clear();
            ReadXml(doc.DocumentElement, 0);

        }

        private void ReadXml(XmlNode root, int intI)
        {
            XmlNodeList nodeList = null;
            int intIdx  = 0;

            nodeList = root.SelectNodes("Item");
        
            foreach (XmlNode xlmItem in nodeList)
	        {
		        foreach (XmlNode subxlmItem in xlmItem.ChildNodes)
                {
		            if(subxlmItem.Name == "SubItems"){
                        ReadXml(subxlmItem, intI + 1);
                    }else{
                        if (subxlmItem.Name == "Name")
                        {
                            UserMenuItem menu = new UserMenuItem();
                            menu.Grade = intI;
                            menu.Name = subxlmItem.InnerText;

                            if (subxlmItem.Attributes["shell"] == null)
                            {
                                menu.Shell = "";
                            }else
                            {
                                menu.Shell = subxlmItem.Attributes["shell"].InnerText; 
                            }
                            
                            if (subxlmItem.Attributes["MenuKey"] == null)
                            {
                                menu.MenuKey = "";
                            }else
                            {
                                menu.MenuKey = subxlmItem.Attributes["MenuKey"].InnerText; 
                            }
  
                            myMenuItem.Add(menu);
                        }
                    }
                }

                intIdx = intIdx + 1;
	        }
        }

        private void ShowMenu()
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var item in myMenuItem)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = item.Name;
                newNode.Name = item.Name;
                newNode.Tag = item;
                newNode.ImageKey = "Programas_close";
                newNode.SelectedImageKey = "Programas_open";
                item.Node = newNode;
 
                if (item.Grade == 0)
                {
                    newNode.NodeFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    nodes.Add(newNode);
                }
                else
                {
                    TreeNode parentNode = nodes[nodes.Count - 1];
                    UserMenuItem parentItem = parentNode.Tag as UserMenuItem;
                    int grade = parentItem.Grade + 1;
                    while (item.Grade > grade)
                    {
                        parentNode = parentNode.Nodes[parentNode.Nodes.Count - 1];
                        parentItem = parentNode.Tag as UserMenuItem;
                        grade = parentItem.Grade + 1;
                    }
                    
                    parentNode.Nodes.Add(newNode);
                }
                
            }
            this.Nodes.Clear();
            foreach (var node in nodes)
            {
                this.Nodes.Add(node);
            }
        }
        
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
           
            TreeNode node = e.Node;
            if (node == null)
                return;
            node.Expand();
            TreeNode prevNode = node.PrevNode;
            while (prevNode != null)
            {
                prevNode.Collapse();
                prevNode = prevNode.PrevNode;
            }
            
            UserMenuItem menuItem = node.Tag as UserMenuItem;
            Core.CoreData[CoreDataType.MenuItemSelected] = menuItem;
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
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

        private IDockContent LastActiveContent = null;
        protected virtual void CoreData_CoreDataChanged(object sender, CoreDataChangedEventArgs e)
        {
            switch (e.Key)
            {
                case CoreDataType.ActiveDockContent:
                    IDockContent ActiveContent = Core.CoreData[CoreDataType.ActiveDockContent] as IDockContent;

                    //if (this.InvokeRequired)
                    //{
                    //    this.BeginInvoke(new ThreadStart(delegate()
                    //    {
                    //        SetSelectedNode(ActiveContent);
                    //    }));
                    //}
                    //else
                    //{
                    //    SetSelectedNode(ActiveContent);
                    //}

                    break;
                default:
                    break;
            }
        }
        
        private void SetSelectedNode(IDockContent ActiveContent)
        {
            if (ActiveContent == null)
            {
                ResetSelectedNode();

                return;
            }

            if (ActiveContent is MenuItemTreePanel)
            {
                return;
            }

            if (LastActiveContent == ActiveContent)
            {
                return;
            }

            LastActiveContent = ActiveContent;

            Type t = ActiveContent.GetType();
            string shell = t.Assembly.ManifestModule.Name;
            var result = from item in myMenuItem
                            where item.Shell == shell
                            select item;
            TreeNode node = result.FirstOrDefault().Node;

            SetSelectedNode(ActiveContent, node);
   
            
        }

        private void SetSelectedNode(IDockContent ActiveContent, TreeNode node)
        {
            if (this.IsDisposed)
            {
                return;
            }
            this.SelectedNode = null;
            //this.SelectedNode = node; 
            ProjectAllocationUtil.NativeMethods.SetFocus(ActiveContent.DockHandler.Form.Handle);
            
        }

        private void ResetSelectedNode()
        {
            if (this.IsDisposed)
            {
                return;
            }
            if (this.SelectedNode != null && this.SelectedNode.Parent != null)
            {
                this.SelectedNode = this.SelectedNode.Parent;
                ProjectAllocationUtil.NativeMethods.SetFocus(this.Handle);
                return;
            }
           
        }
    }
}
