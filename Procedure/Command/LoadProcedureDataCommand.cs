using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationFramework;
using Procedure.Model;
using System.Collections.Generic;
using ProjectAllocationBusiness;

namespace Procedure.Command
{
    public class LoadProcedureDataCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }

            ProcedureSearchCondtion searchCondition = new ProcedureSearchCondtion();
            searchCondition.ProcedureCode = paras[0] as string;
            searchCondition.ProcedureName = paras[1] as string;

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Procedure_TaskMessage_Load;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }

            ProcedureManager manager = new ProcedureManager();
            List<ProcedureEntity> data = manager.GetDataFromDB(OnProgress, searchCondition);
            Core.CoreData[CoreDataType.PROCEDURE_SEARCH] = data;
            return data;
        }
    }
}