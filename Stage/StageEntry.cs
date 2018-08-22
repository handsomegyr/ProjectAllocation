using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace Stage
{
    [EntryName("阶段管理")]
    [EntryDescription("追加,更新,删除,查询阶段的记录")]
    public class StageEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmStageMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new frmStageSearch();
        }

    }
}
