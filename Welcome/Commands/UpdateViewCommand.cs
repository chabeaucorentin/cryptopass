using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Welcome.ViewModels;

namespace Welcome.Commands
{
    public class UpdateViewCommand : ICommand
    {
        #region MEMBER VARIABLES
        private readonly MainViewModel _mainViewModel;
        public event EventHandler? CanExecuteChanged;
        #endregion

        #region CONSTRUCTORS
        public UpdateViewCommand(MainViewModel viewModel)
        {
            _mainViewModel  = viewModel;
        }
        #endregion

        #region METHODS
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _mainViewModel.UpdateView();
        }
        #endregion
    }
}
