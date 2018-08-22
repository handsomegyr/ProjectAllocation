using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Collections;

namespace ProjectAllocationBusiness.Validation
{
    public class ListRangeValidatorAttribute : ValueValidatorAttribute
    {
        private List<String> list;
        public ListRangeValidatorAttribute(
            List<String> list)
        {
            this.list = list;
        }

        /// <summary>
        /// The lower bound
        /// </summary>
        public List<String> List { get { return this.list; } }

        protected override Validator DoCreateValidator(Type targetType) { return new ListRangeValidator(this.List,this.Negated, this.MessageTemplate,this.Tag); }
    }
}
