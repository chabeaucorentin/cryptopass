using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Welcome
{
    public class Welcome1ViewModel : WelcomeViewModel
    {
        #region CONSTRUCTORS
        public Welcome1ViewModel(DelegateCommand updateViewCommand) : base(updateViewCommand) { }
        #endregion
    }
}
