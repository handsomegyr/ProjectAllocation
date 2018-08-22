using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Data.Common;
using ProjectAllocationUtil;
using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;

namespace ProjectAllocationBusiness
{
    public class DatabaseUtil 
    {
        public static DbCommand GetCommand(DbCommand command)
        {
            command.CommandTimeout = ConvertUtil.ToInt(ConfigUtil.GetTimeOut());
            return command;
        }

    }
}
