using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class SecureObject
    {
        #region MEMBER VARIABLES
        protected string _name;
        #endregion

        #region CONSTRUCTORS
        public SecureObject(string name = "")
        {
            _name = name;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
    }
}
