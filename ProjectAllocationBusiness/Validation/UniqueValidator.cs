using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Globalization;
using System.Collections;

namespace ProjectAllocationBusiness.Validation
{
    public class UniqueValidator : UniqueValidator<string>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        public UniqueValidator(List<String> list)
            : this(list, false)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        public UniqueValidator(List<String> list, bool negated)
            : this(list, negated, null)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        /// <param name="messageTemplate">The message template to log failures.</param>
        public UniqueValidator(List<String> list, string messageTemplate)
            : this(list, false, messageTemplate)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/> with a message template.</para>
        /// </summary>
        /// <param name="negated">True if the validator must negate the result of the validation.</param>
        /// <param name="messageTemplate">The message template to log failures.</param>
        public UniqueValidator(List<String> list, bool negated, string messageTemplate)
            : this(list, negated, messageTemplate, null)
        {
        }

        public UniqueValidator(List<String> list, bool negated, string messageTemplate, string tag)
            : base(list, negated, messageTemplate, tag)
        {
        }
    }
}
