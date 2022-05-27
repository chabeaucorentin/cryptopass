using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
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

        void Load(string? file = null);

        void Save(string? file = null);
        #endregion
    }
}
