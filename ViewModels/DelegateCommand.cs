using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModels
{
    public class DelegateCommand : ICommand
    {
        #region MEMBER VARIABLES
        private readonly Action<object> _execute;
        private readonly Predicate<object>? _canExecute;
        public event EventHandler? CanExecuteChanged;
        #endregion

        #region CONSTRUCTORS
        public DelegateCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region METHODS
        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
