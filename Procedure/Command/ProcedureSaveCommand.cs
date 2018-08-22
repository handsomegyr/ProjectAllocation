using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using System.Collections.Generic;
using Procedure.Model;

namespace Procedure.Command
{
    public class ProcedureSaveCommand : CommandBase
    {
        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 1)
            {
                throw new ArgumentException();
            }
            List<ProcedureEntity> SaveData = paras[0] as List<ProcedureEntity>;
            
            ProcedureManager manager = new ProcedureManager();

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Procedure_TaskMessage_Validate;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //check
            manager.DataValidation(OnProgress, SaveData);

            if (OnProgress != null)
            {
                string TaskName = ProjectAllocationResource.Message.Procedure_TaskMessage_Save;
                ProjectAllocationFramework.Statues.ProgressChangedEventArgs args = new ProjectAllocationFramework.Statues.ProgressChangedEventArgs(TaskName);
                OnProgress(null, args);
            }
            //save
            manager.SaveDataToDB(OnProgress, SaveData);

            return SaveData;
        }
    }
}