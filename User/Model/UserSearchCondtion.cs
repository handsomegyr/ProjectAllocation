
namespace User.Model
{
    public class UserSearchCondtion
    {
        private string userCode = string.Empty;
        public string UserCode
        {
            get { return userCode; }
            set { userCode = value; }
        }

        private string userName = string.Empty;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
