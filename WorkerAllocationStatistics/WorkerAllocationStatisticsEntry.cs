using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace WorkerAllocationStatistics
{
    [EntryName("员工项目产值统计")]
    [EntryDescription("查询员工项目产值")]
    public class WorkerAllocationStatisticsEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmWorkerAllocationStatisticsMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new Form();
        }
    }
}
