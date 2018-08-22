using System.Collections.Generic;
using ProjectAllocationFramework;
using ProjectAllocationFramework.Attribute;
using ProjectAllocationFramework.Command;
using System.Reflection;
using System.Windows.Forms;

namespace User
{
    [EntryName("后台用户管理")]
    [EntryDescription("追加,更新,删除,查询后台用户的记录")]
    public class UserEntry : Entry
    {
        public override List<DockContent> GetContents(object[] args)
        {
            List<DockContent> list = new List<DockContent>();
            list.Add(new frmUserMaster());
            return list;
        }

        public override Form GetSearchDialog(object[] args)
        {
            return new Form();
        }

    }
}
