using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Note : SecureObject
    {
        #region MEMBER VARIABLES
        private string _content;
        #endregion

        #region CONSTRUCTORS
        public Note(string name = "", string content = "")
        {
            _name = name;
            _content = content;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        #endregion
    }
}
