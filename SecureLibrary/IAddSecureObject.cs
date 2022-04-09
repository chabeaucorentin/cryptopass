using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;

namespace SecureLibrary
{
    public interface IAddSecureObject
    {
        #region GETTERS/SETTERS
        DelegateCommand AddCommand { get; set; }
        #endregion

        #region METHODS
        void Add(object parameter);
        #endregion
    }
}
