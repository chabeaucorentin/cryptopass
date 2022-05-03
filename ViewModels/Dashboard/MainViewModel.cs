using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Dashboard
{
    public class MainViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private string? _title;
        private BaseViewModel? _selectedViewModel;
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
            UpdateView("Passwords");
            UpdateViewCommand = new DelegateCommand(UpdateView);
        }
        #endregion

        #region GETTERS/SETTERS
        public string? Title
        {
            get { return _title; }
            set
            {
                _title = "CryptoPass - " + value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public BaseViewModel? SelectedViewModel
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
            switch (parameter.ToString())
            {
                case "Passwords":
                    Title = "Mots de passe";
                    SelectedViewModel = _passwordsViewModel;
                    break;
                case "Notes":
                    Title = "Notes sécurisées";
                    SelectedViewModel = _notesViewModel;
                    break;
                case "Payments":
                    Title = "Moyens de paiements";
                    SelectedViewModel = _paymentsViewModel;
                    break;
                case "Generator":
                    Title = "Générateur de mots de passe";
                    SelectedViewModel = _generatorViewModel;
                    break;
            }
        }
        #endregion
    }
}
