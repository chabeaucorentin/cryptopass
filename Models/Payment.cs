namespace Models
{
    public class Payment : SecureObject
    {
        #region MEMBER VARIABLES
        private string _number;
        private string _cvv;
        private DateOnly _date;
        #endregion

        #region CONSTRUCTORS
        public Payment(string name = "", string number = "", string cvv = "", int year = -1, int month = -1)
        {
            _name = name;
            _number = number;
            _cvv = cvv;
            if (year < 0)
                year = DateTime.Now.Year;
            if (month < 0)
                month = DateTime.Now.Month;
            _date = new DateOnly(year, month, 1);
        }
        #endregion

        #region GETTERS/SETTERS
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Cvv
        {
            get { return _cvv; }
            set { _cvv = value; }
        }

        public int Year
        {
            get { return _date.Year; }
            set { _date = new DateOnly(value, _date.Month, 1); }
        }

        public int Month
        {
            get { return _date.Month; }
            set { _date = new DateOnly(_date.Year, value, 1); }
        }
        #endregion
    }
}
