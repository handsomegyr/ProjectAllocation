
namespace Project.Model
{
    public class ProjectSearchCondtion
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
