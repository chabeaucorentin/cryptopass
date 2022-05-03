using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Welcome
{
    public class MainViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private int _view;
        private BaseViewModel _selectedViewModel;
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            UpdateViewCommand = new DelegateCommand(UpdateView);
            _view = 1;
            _selectedViewModel = new Welcome1ViewModel(UpdateViewCommand);
        }
        #endregion

        #region GETTERS/SETTERS
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public DelegateCommand UpdateViewCommand { get; set; }
        #endregion

        #region METHODS
        public void UpdateView(object parameter)
        {
            _view++;
            switch (_view)
            {
                case 2:
                    SelectedViewModel = new Welcome2ViewModel(UpdateViewCommand);
                    break;
                case 3:
                    SelectedViewModel = new Welcome3ViewModel(UpdateViewCommand);
                    break;
                case 4:
                    SelectedViewModel = new PasswordViewModel();
                    break;
            }
        }
        #endregion
    }
}
