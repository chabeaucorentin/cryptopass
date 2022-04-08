using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dashboard.ViewModels;
using SecureLibrary;

namespace Dashboard.Commands
{
    public class AddCommand : ICommand
    {
        #region MEMBER VARIABLES
        private readonly IAddSecureObject _viewModel;
        public event EventHandler? CanExecuteChanged;
        #endregion

        #region CONSTRUCTORS
        public AddCommand(IAddSecureObject viewModel)
        {
            _viewModel = viewModel;
        }
        #endregion

        #region METHODS
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Add();
        }
        #endregion
    }
}
