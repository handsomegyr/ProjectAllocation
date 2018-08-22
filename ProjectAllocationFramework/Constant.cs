using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectAllocationFramework
{
    public class Constant
    {
        //ProgressBar
        public const int ProgressBarMaximum = 100;

        //DB Action
        public const int ACTION_NONE = -1;
        public const int ACTION_CREATE = 0;
        public const int ACTION_UPDATE = 1;
        public const int ACTION_DELETE = 2;
        //User
        public const string OPERATOR = "Administrator";
        //Regex Int
        public const string REGEX_INT_STRING = @"^((\\+|-)\d)?\d*$";
        //Regex double
        public const string REGEX_DOUBLE_STRING = @"^(?:\+|-)?\d+(?:\.\d+)?$";

        public const string CONNECTIONSTRING = @"Data Source={0};Initial Catalog={1};Persist Security Info=false;User ID={2};Password={3};Connect Timeout = {4}";//Max Pool Size= 25;Min Pool Size= 5;

        //SuperUser
        public const string SuperUser = "Administrator";

        public static readonly System.Drawing.Font ProjectAllocationFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    
    }
}
