using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;
using SecureLibrary;

namespace Dashboard.ViewModels
{
    public class PasswordsViewModel : BaseViewModel, IAddSecureObject
    {
        #region MEMBER VARIABLES
        private PasswordViewModel? _selectedPassword;
        #endregion

        #region CONSTRUCTORS
        public PasswordsViewModel()
        {
            ListPasswords = new ObservableCollection<PasswordViewModel>();
            AddCommand = new DelegateCommand(Add);
        }
        #endregion

        #region GETTERS/SETTERS
        public PasswordViewModel? SelectedPassword
        {
            get { return _selectedPassword; }
            set
            {
                _selectedPassword = value;
                OnPropertyChanged(nameof(SelectedPassword));
            }
        }

        public ObservableCollection<PasswordViewModel> ListPasswords { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            PasswordViewModel NewPass = new(new Password());
            ListPasswords.Add(NewPass);
            SelectedPassword = NewPass;
        }

        public DelegateCommand AddCommand { get; set; }
        #endregion
    }
}
