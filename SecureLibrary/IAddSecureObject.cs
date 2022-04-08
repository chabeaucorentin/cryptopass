using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SecureLibrary
{
    public interface IAddSecureObject
    {
        #region GETTERS/SETTERS
        ICommand AddCommand { get; set; }
        #endregion

        #region METHODS
        void Add();
        #endregion
    }
}
