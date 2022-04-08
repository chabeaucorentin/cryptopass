using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.Commands;

namespace Welcome.ViewModels
{
    public abstract class WelcomeViewModel : BaseViewModel
    {
        #region CONSTRUCTORS
        public WelcomeViewModel(MainViewModel viewModel)
        {
            UpdateViewCommand = new UpdateViewCommand(viewModel);
        }
        #endregion

        #region GETTERS/SETTERS
        public ICommand UpdateViewCommand { get; set; }
        #endregion
    }
}
