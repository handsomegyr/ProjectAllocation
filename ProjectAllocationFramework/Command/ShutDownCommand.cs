
namespace ProjectAllocationFramework.Command
{
    public class ShutDownCommand:CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            System.Windows.Forms.Application.Exit();
            return true;
        }
    }
}