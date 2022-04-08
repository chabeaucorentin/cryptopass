using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureLibrary
{
    public class Payment : SecureObject
    {
        #region MEMBER VARIABLES
        private string _number;
        private string _cvv;
        private DateTime _date;
        #endregion

        #region CONSTRUCTORS
        public Payment(string name = "", string number = "", string cvv = "", int year = 0, int month = 0)
        {
            _name = name;
            _number = number;
            _cvv = cvv;
            _date = new DateTime(year, month, 0);
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
            set { _date = new DateTime(value, _date.Month, 0); }
        }

        public int Month
        {
            get { return _date.Month; }
            set { _date = new DateTime(_date.Year, value, 0); }
        }
        #endregion
    }
}
