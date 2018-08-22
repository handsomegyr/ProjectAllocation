using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace Procedure
{
    [EntryName("专业管理")]
    [EntryDescription("追加,更新,删除,查询专业的记录")]
    public class ProcedureEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmProcedureMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new frmProcedureSearch();
        }

    }
}
