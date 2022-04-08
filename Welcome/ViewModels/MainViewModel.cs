using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welcome.ViewModels
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
            _view = 1;
            _selectedViewModel = new Welcome1ViewModel(this);
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
        #endregion

        #region METHODS
        public void UpdateView()
        {
            _view++;
            switch (_view)
            {
                case 2:
                    SelectedViewModel = new Welcome2ViewModel(this);
                    break;
                case 3:
                    SelectedViewModel = new Welcome3ViewModel(this);
                    break;
                case 4:
                    SelectedViewModel = new PasswordViewModel();
                    break;
            }
        }
        #endregion
    }
}
