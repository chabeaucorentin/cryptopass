using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;

namespace Dashboard.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private BaseViewModel _selectedViewModel;
        private readonly BaseViewModel _passwordsViewModel;
        private readonly BaseViewModel _notesViewModel;
        private readonly BaseViewModel _paymentsViewModel;
        private readonly BaseViewModel _generatorViewModel;
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            _passwordsViewModel = new PasswordsViewModel();
            _notesViewModel = new NotesViewModel();
            _paymentsViewModel = new PaymentsViewModel();
            _generatorViewModel = new GeneratorViewModel();
            _selectedViewModel = _passwordsViewModel;
            UpdateViewCommand = new DelegateCommand(UpdateView);
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

        public DelegateCommand UpdateViewCommand { get; set; }
        #endregion

        #region METHODS
        public void UpdateView(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Passwords":
                    SelectedViewModel = _passwordsViewModel;
                    break;
                case "Notes":
                    SelectedViewModel = _notesViewModel;
                    break;
                case "Payments":
                    SelectedViewModel = _paymentsViewModel;
                    break;
                case "Generator":
                    SelectedViewModel = _generatorViewModel;
                    break;
            }
        }
        #endregion
    }
}
