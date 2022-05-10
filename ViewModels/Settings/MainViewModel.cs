using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Settings
{
    public class MainViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private string _path;
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            _path = AppSettings.GetPath();
            SelectPathCommand = new DelegateCommand(SelectPath);
        }
        #endregion

        #region GETTERS/SETTERS
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public DelegateCommand SelectPathCommand { get; set; }
        #endregion

        #region METHODS
        public void SelectPath(object parameter)
        {
            //CODE
        }
        #endregion
    }
}
