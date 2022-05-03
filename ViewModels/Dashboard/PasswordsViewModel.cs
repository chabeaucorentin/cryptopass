using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ViewModels.Dashboard
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
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
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
                OnPropertyChanged(nameof(IsSelectedPassword));
            }
        }

        public bool IsSelectedPassword
        {
            get { return SelectedPassword != null; }
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
        }

        public void Remove(object parameter)
        {
            if (SelectedPassword != null)
            {
                ListPasswords.Remove(SelectedPassword);
                SelectedPassword = ListPasswords.FirstOrDefault();
            }
        }
        #endregion
    }
}
