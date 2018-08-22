using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.ComponentModel;

namespace ProjectAllocationBusiness.Command
{
    public class GetDbInstanceCommand : CommandBase
    {

        public override object CommandBody(params object[] paras)
        {            
            if (paras.Length < 4)
            {
                throw new ArgumentException();
            }

            string ProjectAllocationServer = paras[0] as string ;
            string ProjectAllocationDB = "master" ;
            string SQLUserID = paras[1] as string ;
            string SQLPwd = paras[2] as string ;
            string TimeOut = paras[3] as string;


            return BusinessFacade.GetDbInstance(
                ProjectAllocationServer,
                ProjectAllocationDB,
                SQLUserID,
                SQLPwd,
               TimeOut);

        }
    }
}