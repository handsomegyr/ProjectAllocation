using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework.Attribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntryNameAttribute : System.Attribute
    {
        private string entryName;

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }
        
        public EntryNameAttribute(string entryName)
        {
            this.entryName = entryName;

        }

        public override string ToString()
        {
            return this.EntryName;
        }
    }
}
