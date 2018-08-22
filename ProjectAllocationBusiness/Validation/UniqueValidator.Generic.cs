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
    public class UniqueValidator<T> : ValueValidator<T>
        where T : IComparable
    {
        private List<T> list = default(List<T>);

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        public UniqueValidator(List<T> list)
            : this(list, false)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        public UniqueValidator(List<T> list, bool negated)
            : this(list, negated, null)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/>.</para>
        /// </summary>
        /// <param name="messageTemplate">The message template to log failures.</param>
        public UniqueValidator(List<T> list, string messageTemplate)
            : this(list, false, messageTemplate)
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="NotNullValidator"/> with a message template.</para>
        /// </summary>
        /// <param name="negated">True if the validator must negate the result of the validation.</param>
        /// <param name="messageTemplate">The message template to log failures.</param>
        public UniqueValidator(List<T> list, bool negated, string messageTemplate)
            : this(list, negated, messageTemplate, null)
        {
        }

        public UniqueValidator(List<T> list, bool negated, string messageTemplate, string tag)
            : base(messageTemplate, tag, negated)
        {
            this.list = list;
        }

        /// <summary>
        /// Validates by comparing <paramref name="objectToValidate"/> with the constraints
        /// specified for the validator.
        /// </summary>
        /// <param name="objectToValidate">The object to validate.</param>
        /// <param name="currentTarget">The object on the behalf of which the validation is performed.</param>
        /// <param name="key">The key that identifies the source of <paramref name="objectToValidate"/>.</param>
        /// <param name="validationResults">The validation results to which the outcome of the validation should be stored.</param>
        /// <remarks>
        /// <see langword="null"/> is considered a failed validation.
        /// </remarks>
        protected override void DoValidate(T objectToValidate,
            object currentTarget,
            string key,
            ValidationResults validationResults)
        {
            bool logError = false;
            bool isObjectToValidateNull = objectToValidate == null;

            logError = !isObjectToValidateNull && !this.IsUnique(objectToValidate);

            if (isObjectToValidateNull || (logError != Negated))
            {
                LogValidationResult(validationResults,
                    GetMessage(objectToValidate, key),
                    currentTarget,
                    key);
            }
        }

   

        protected virtual bool IsUnique(T target)
        {
            List<T> results = this.list.FindAll(
                                                delegate(T obj)
                                                {
                                                    return target.Equals(obj);
                                                }
                                                );
            return (results.Count <= 1);
        }

        /// <summary>
        /// Gets the message representing a failed validation.
        /// </summary>
        /// <param name="objectToValidate">The object for which validation was performed.</param>
        /// <param name="key">The key representing the value being validated for <paramref name="objectToValidate"/>.</param>
        /// <returns>The message representing the validation failure.</returns>
        protected override string GetMessage(object objectToValidate, string key)
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                this.MessageTemplate,
                objectToValidate,
                key,
                this.Tag,
                objectToValidate);
        }

        /// <summary>
        /// Gets the Default Message Template when the validator is non negated.
        /// </summary>
        protected override string DefaultNonNegatedMessageTemplate
        {
            get 
            { 
                return ProjectAllocationResource.Resource.UniqueValidatorNonNegatedDefaultMessageTemplate; 
            }
        }

        /// <summary>
        /// Gets the Default Message Template when the validator is negated.
        /// </summary>
        protected override string DefaultNegatedMessageTemplate
        {
            get
            {
                return ProjectAllocationResource.Resource.UniqueValidatorNegatedDefaultMessageTemplate; 
            }
        }
    }
}
