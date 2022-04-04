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
            switch (parameter?.ToString())
            {
                case "Passwords":
                    _mainViewModel.SelectedViewModel = new PasswordsViewModel();
                    break;
                case "Notes":
                    _mainViewModel.SelectedViewModel = new NotesViewModel();
                    break;
                case "Payments":
                    _mainViewModel.SelectedViewModel = new PaymentsViewModel();
                    break;
                case "Generator":
                    _mainViewModel.SelectedViewModel = new GeneratorViewModel();
                    break;
            }
        }
        #endregion
    }
}
