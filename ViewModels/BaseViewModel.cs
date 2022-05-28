using System.ComponentModel;

namespace ViewModels
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
