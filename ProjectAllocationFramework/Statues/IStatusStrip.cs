using System;
namespace ProjectAllocationFramework.Statues
{
    public interface IStatusStrip
    {
        string InfomationMessage { set; }
        string TaskMessage { set; }
        int Percentage { set; }
    }
}
