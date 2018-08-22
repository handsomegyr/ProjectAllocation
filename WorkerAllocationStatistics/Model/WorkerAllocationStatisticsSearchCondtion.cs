
namespace WorkerAllocationStatistics.Model
{
    public class WorkerAllocationStatisticsSearchCondtion
    {
        private string workerCode = string.Empty;
        public string WorkerCode
        {
            get { return workerCode; }
            set { workerCode = value; }
        }

        private string workerName = string.Empty;
        public string WorkerName
        {
            get { return workerName; }
            set { workerName = value; }
        }
    }
}
