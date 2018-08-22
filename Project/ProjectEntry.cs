using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace Project
{
    [EntryName("项目管理")]
    [EntryDescription("追加,更新,删除,查询项目的记录")]
    public class ProjectEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmProjectMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new frmProjectSearch();
        }
    }
}
