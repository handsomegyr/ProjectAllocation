using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationBusiness.Entity;
using Microsoft.Practices.EnterpriseLibrary.Validation; 
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ProjectAllocationBusiness
{
    public class ProjectEntity : ProjectAllocationBusiness.Entity.Entity
    {
        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator(
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Project_ProjectCode_NotNull")]
        [StringLengthValidator(1, 30,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Project_ProjectCode_Length")]
        public string ProjectCode { get; set; }

        [StringLengthValidator(0, 100,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Project_ProjectName_Length")]
        public string ProjectName { get; set; }

    }
}
