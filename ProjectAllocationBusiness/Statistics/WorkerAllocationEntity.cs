using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectAllocationBusiness.Entity;
using Microsoft.Practices.EnterpriseLibrary.Validation; 
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace ProjectAllocationBusiness.Statistics
{
    public class WorkerAllocationEntity : ProjectAllocationBusiness.Entity.Entity
    {        
        public string WorkerCode { get; set; }
        
        public string WorkerName { get; set; }

        public double ProjectCount { get; set; }
        public double WorthTotal { get; set; }
    }
}
