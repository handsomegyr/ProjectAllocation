using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ProjectAllocationFramework.Attribute;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public abstract class Entry : IEntry   
    {
        private string entryDescription = string.Empty;
        public string Description
        {
            get
            {
                return entryDescription;
            }
            set
            {
                entryDescription = value;
            }
        }

        private string entryName = string.Empty;
        public string Name
        {
            get
            {
                return entryName;
            }
            set
            {
                entryName = value;
            }
        }

        public Entry()
        {
            entryDescription = this.GetType().GetCustomAttributes(typeof(EntryDescriptionAttribute), true)[0].ToString();
            entryName = this.GetType().GetCustomAttributes(typeof(EntryNameAttribute), true)[0].ToString();
        }

        public abstract List<DockContent> GetContents(object[] args);
        public abstract Form GetSearchDialog(object[] args);
    }
}
