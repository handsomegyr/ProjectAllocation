using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationFramework.Command;
using ProjectAllocationFramework.Statues;
using ProjectAllocationBusiness;
using ProjectAllocationBusiness.Command;

namespace ProjectAllocationLayout
{
    public class Presenter
    {
        private frmBase View{get;set;}
        
        public Presenter(frmBase frmBase)
        {
            this.View = frmBase;
        }
    }
}
