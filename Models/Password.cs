namespace Models
{
    public class Password : SecureObject
    {
        #region MEMBER VARIABLES
        private string _login;
        private string _pass;
        private string _url;
        #endregion

        #region CONSTRUCTORS
        public Password(string name = "", string login = "", string pass = "", string url = "")
        {
            _name = name;
            _login = login;
            _pass = pass;
            _url = url;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        #endregion
    }
}
