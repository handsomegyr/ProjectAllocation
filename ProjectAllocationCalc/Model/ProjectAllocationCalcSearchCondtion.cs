
namespace ProjectAllocationCalc.Model
{
    public class ProjectAllocationCalcSearchCondtion
    {
        private string projectCode = string.Empty;
        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }

        private string projectName = string.Empty;
        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
    }
}
