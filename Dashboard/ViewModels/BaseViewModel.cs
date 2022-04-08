using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region MEMBER VARIABLES
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region METHODS
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
