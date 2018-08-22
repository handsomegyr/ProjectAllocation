
namespace Job.Model
{
    public class JobSearchCondtion
    {
        private string jobCode = string.Empty;
        public string JobCode
        {
            get { return jobCode; }
            set { jobCode = value; }
        }

        private string jobName = string.Empty;
        public string JobName
        {
            get { return jobName; }
            set { jobName = value; }
        }
    }
}
