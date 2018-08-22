using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAllocationFramework.Statues
{
    public class EmptyStatusStrip:IStatusStrip
    {
        #region IStatusStrip 

        public string InfomationMessage
        {
            set { }
        }

        public int Percentage
        {
            set { }
        }

        public string TaskMessage
        {
            set { }
        }

        #endregion
    }
}
