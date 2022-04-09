using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;

namespace SecureLibrary
{
    public interface IManageSecureObject
    {
        #region GETTERS/SETTERS
        DelegateCommand AddCommand { get; set; }

        DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        void Add(object parameter);

        void Remove(object parameter);

        bool CanExecuteRemove(object parameter);
        #endregion
    }
}
