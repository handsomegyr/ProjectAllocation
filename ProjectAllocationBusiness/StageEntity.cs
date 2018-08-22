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
    public class StageEntity : ProjectAllocationBusiness.Entity.Entity
    {
        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator(
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Stage_StageCode_NotNull")]
        [StringLengthValidator(1, 10,
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Stage_StageCode_Length")]
        public string StageCode { get; set; }

        [StringLengthValidator(0, 50,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Stage_StageName_Length")]
        public string StageName { get; set; }

        [StringLengthValidator(0, 10,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Stage_Percent_Length")]
        [RegexValidator(Constant.REGEX_DOUBLE_STRING,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Stage_Percent_Format")]
        public string Percent { get; set; }
                
    }
}
