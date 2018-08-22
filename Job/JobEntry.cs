using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace Job
{
    [EntryName("工序管理")]
    [EntryDescription("追加,更新,删除,查询工序的记录")]
    public class JobEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmJobMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new frmJobSearch();
        }

    }
}
