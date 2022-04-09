using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;

namespace Welcome.ViewModels
{
    public class Welcome3ViewModel : WelcomeViewModel
    {
        #region CONSTRUCTORS
        public Welcome3ViewModel(DelegateCommand updateViewCommand) : base(updateViewCommand) { }
        #endregion
    }
}
