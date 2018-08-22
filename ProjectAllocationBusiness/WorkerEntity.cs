using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationBusiness.Entity;
using Microsoft.Practices.EnterpriseLibrary.Validation; 
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ProjectAllocationBusiness
{
    public class WorkerEntity : ProjectAllocationBusiness.Entity.Entity
    {
        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator(
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Worker_WorkerCode_NotNull")]
        [StringLengthValidator(1, 30,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Worker_WorkerCode_Length")]
        public string WorkerCode { get; set; }

        [StringLengthValidator(0, 100,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Worker_WorkerName_Length")]
        public string WorkerName { get; set; }

    }
}
