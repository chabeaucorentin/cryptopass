using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dashboard.ViewModels;

namespace Dashboard.Commands
{
    public class UpdateViewCommand : ICommand
    {
        #region MEMBER VARIABLES
        private MainViewModel _mainViewModel;
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
            _mainViewModel.UpdateView(parameter?.ToString());
        }
        #endregion
    }
}
