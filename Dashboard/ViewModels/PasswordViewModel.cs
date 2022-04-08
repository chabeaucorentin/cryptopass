using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureLibrary;

namespace Dashboard.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private readonly Password _password;
        #endregion

        #region CONSTRUCTORS
        public PasswordViewModel(Password password)
        {
            _password = password;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Name
        {
            get { return _password.Name; }
            set
            {
                _password.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Login
        {
            get { return _password.Login; }
            set
            {
                _password.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Pass
        {
            get { return _password.Pass; }
            set
            {
                _password.Pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }

        public string Url
        {
            get { return _password.Url; }
            set
            {
                _password.Url = value;
                OnPropertyChanged(nameof(Url));
            }
        }
        #endregion
    }
}
