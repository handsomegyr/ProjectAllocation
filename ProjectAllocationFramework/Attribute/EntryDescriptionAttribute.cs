using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework.Attribute
{
    public class EntryDescriptionAttribute : System.Attribute
    {
        private string entryDescription;

        public string EntryDescription
        {
            get { return entryDescription; }
            set { entryDescription = value; }
        }

        public EntryDescriptionAttribute(string entryDescription)
        {
            this.entryDescription = entryDescription;

        }

        public override string ToString()
        {
            return this.EntryDescription;
        }
    }
}
