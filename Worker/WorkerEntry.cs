using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace Worker
{
    [EntryName("员工管理")]
    [EntryDescription("追加,更新,删除,查询员工的记录")]
    public class WorkerEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmWorkerMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new frmWorkerSearch();
        }


    }
}
