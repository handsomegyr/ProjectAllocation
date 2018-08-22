using System;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using System.ComponentModel;
using ProjectAllocation.Model;
using ProjectAllocationFramework;
using ProjectAllocationBusiness;
using ProjectAllocationBusiness.Business;

namespace ProjectAllocation.Command
{
    public class LoginCommand : CommandBase
    {

        public override object CommandBody(params object[] paras)
        {
            if (paras.Length < 2)
            {
                throw new ArgumentException();
            }
            string userCode = paras[0] as string;
            string pwd = paras[1] as string;

            if (Constant.SuperUser.Equals(userCode, StringComparison.OrdinalIgnoreCase) && Constant.SuperUser.Equals(pwd, StringComparison.OrdinalIgnoreCase))
            {
                UserEntity item = new UserEntity();
                item.UserCode = Constant.SuperUser;
                item.UserName = Constant.SuperUser;
                item.Password = Constant.SuperUser;
                User.Operator = item;
                return true;

            }else{
                ProjectAllocationManager manager = new ProjectAllocationManager();

                return manager.Login(userCode, pwd);
            }
        }
    }
}