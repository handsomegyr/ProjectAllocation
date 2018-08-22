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
    public class ProcedureAllocationCalcEntity : ProjectAllocationBusiness.Entity.Entity
    {
        [ValidatorComposition(CompositionType.And)]
        [NotNullValidator(
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Procedure_ProcedureCode_NotNull")]
        [StringLengthValidator(1, 10,
            MessageTemplateResourceType= typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Procedure_ProcedureCode_Length")]
        public string ProcedureCode { get; set; }

        [StringLengthValidator(0, 50,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Procedure_ProcedureName_Length")]
        public string ProcedureName { get; set; }

        [StringLengthValidator(0, 10,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Procedure_Percent_Length")]
        [RegexValidator(Constant.REGEX_DOUBLE_STRING,
            MessageTemplateResourceType = typeof(ProjectAllocationResource.Message),
            MessageTemplateResourceName = "Procedure_Percent_Format")]
        public double Percent { get; set; }
        
        public double Worth { get; set; }

        public List<JobAllocationCalcEntity> JobAllocationCalcEntityList { get; set; }
    }
}
