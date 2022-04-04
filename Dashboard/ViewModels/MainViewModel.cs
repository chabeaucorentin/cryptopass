using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dashboard.Commands;

namespace Dashboard.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private BaseViewModel _selectedViewModel;
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            _selectedViewModel = new PasswordsViewModel();
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        #endregion

        #region GETTERS/SETTERS
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        #endregion
    }
}
