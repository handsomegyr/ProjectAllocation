
namespace Procedure.Model
{
    public class ProcedureSearchCondtion
    {
        private string procedureCode = string.Empty;
        public string ProcedureCode
        {
            get { return procedureCode; }
            set { procedureCode = value; }
        }

        private string procedureName = string.Empty;
        public string ProcedureName
        {
            get { return procedureName; }
            set { procedureName = value; }
        }
    }
}
