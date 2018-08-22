using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationFramework;
using ProjectAllocationBusiness.Business;

namespace ProjectAllocationBusiness.Entity
{
    public abstract class Entity : IEntity
    {
        private int action = Constant.ACTION_NONE;

        public int Action
        {
            get { return action; }
            set { action = value; }
        }
        
        public string User
        {
            get { return ProjectAllocationBusiness.Business.User.Operator.UserCode; }
        }

        public bool Del
        {
            get { return Action == Constant.ACTION_DELETE; }

            set { Action = (value ? Constant.ACTION_DELETE : Constant.ACTION_NONE); }
        }

        public int Row { get; set; }

        public bool ReadOnly { get; set; }// if true ,data has been in db;
        
    }
}
