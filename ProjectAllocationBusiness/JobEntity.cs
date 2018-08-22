using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationBusiness.Entity;
using Microsoft.Practices.EnterpriseLibrary.Validation; 
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using ProjectAllocationFramework;
using ProjectAllocationBusiness.Validation;

namespace ProjectAllocationBusiness
{
    public class JobEntity : ProjectAllocationBusiness.Entity.Entity
    {
        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator(
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Job_JobCode_NotNull")]
        [StringLengthValidator(1, 10,
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Job_JobCode_Length")]
        public string JobCode { get; set; }

        [StringLengthValidator(0, 50,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Job_JobName_Length")]
        public string JobName { get; set; }

        [StringLengthValidator(0, 10,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Job_Percent_Length")]
        [RegexValidator(Constant.REGEX_DOUBLE_STRING,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Job_Percent_Format")]
        public string Percent { get; set; }
                
    }
}
