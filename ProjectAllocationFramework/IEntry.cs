using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectAllocationFramework
{
    public interface IEntry
    {
        string Description { get; set; }
        string Name { get; set; }
        List<ProjectAllocationFramework.DockContent> GetContents(object[] args);
        Form GetSearchDialog(object[] args);
        
    }
}
