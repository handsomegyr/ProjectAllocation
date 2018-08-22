using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using System.Windows.Forms;

namespace ProjectAllocationCalc
{
    [EntryName("产值计算")]
    [EntryDescription("产值计算")]
    public class ProjectAllocationCalcEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmProjectAllocationCalc());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new Form();
        }

    }
}
