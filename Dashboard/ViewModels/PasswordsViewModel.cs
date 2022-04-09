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
    public class PasswordsViewModel : BaseViewModel, IManageSecureObject
    {
        #region MEMBER VARIABLES
        private PasswordViewModel? _selectedPassword;
        #endregion

        #region CONSTRUCTORS
        public PasswordsViewModel()
        {
            ListPasswords = new ObservableCollection<PasswordViewModel>();
            PasswordViewModel NewPass = new(new Password());
            ListPasswords.Add(NewPass);
            SelectedPassword = NewPass;
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove, CanExecuteRemove);
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

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            PasswordViewModel NewPass = new(new Password());
            ListPasswords.Add(NewPass);
            SelectedPassword = NewPass;
            RemoveCommand.RaiseCanExecuteChanged();
        }

        public void Remove(object parameter)
        {
            ListPasswords.Remove(SelectedPassword);
            SelectedPassword = ListPasswords.FirstOrDefault();
            RemoveCommand.RaiseCanExecuteChanged();
        }

        public bool CanExecuteRemove(object parameter)
        {
            return ListPasswords.Count > 0;
        }
        #endregion
    }
}
