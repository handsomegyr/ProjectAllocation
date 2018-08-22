
namespace Currency.Model
{
    public class CurrencySearchCondtion
    {
        private string currencyCode = string.Empty;
        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        private string currencyName = string.Empty;
        public string CurrencyName
        {
            get { return currencyName; }
            set { currencyName = value; }
        }

        private string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
