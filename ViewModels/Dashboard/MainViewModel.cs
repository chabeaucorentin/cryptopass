using System.Runtime.Versioning;

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
        [SupportedOSPlatform("windows")]
        public MainViewModel()
        {
            _passwordsViewModel = new PasswordsViewModel();
            _notesViewModel = new NotesViewModel();
            _paymentsViewModel = new PaymentsViewModel();
            _generatorViewModel = new GeneratorViewModel();
            UpdateView("Passwords");
            SaveCommand = new DelegateCommand(Save);
            UpdateViewCommand = new DelegateCommand(UpdateView);
            Load();
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

        public IManageSecureObject PasswordsViewModel
        {
            get { return (IManageSecureObject)_passwordsViewModel; }
        }

        public IManageSecureObject NotesViewModel
        {
            get { return (IManageSecureObject)_notesViewModel; }
        }

        public IManageSecureObject PaymentsViewModel
        {
            get { return (IManageSecureObject)_paymentsViewModel; }
        }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand UpdateViewCommand { get; set; }
        #endregion

        #region METHODS
        [SupportedOSPlatform("windows")]
        public void Load()
        {
            ((PasswordsViewModel)_passwordsViewModel).Load();
            ((NotesViewModel)_notesViewModel).Load();
            ((PaymentsViewModel)_paymentsViewModel).Load();
        }

        [SupportedOSPlatform("windows")]
        public void Save(object? parameter = null)
        {
            ((PasswordsViewModel)_passwordsViewModel).Save();
            ((NotesViewModel)_notesViewModel).Save();
            ((PaymentsViewModel)_paymentsViewModel).Save();
        }

        [SupportedOSPlatform("windows")]
        public bool HasChanged()
        {
            return ((PasswordsViewModel)_passwordsViewModel).HasChanged() ||
                ((NotesViewModel)_notesViewModel).HasChanged() ||
                ((PaymentsViewModel)_paymentsViewModel).HasChanged();
        }

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
