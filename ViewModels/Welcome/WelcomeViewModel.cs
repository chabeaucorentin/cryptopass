namespace ViewModels.Welcome
{
    public abstract class WelcomeViewModel : BaseViewModel
    {
        #region CONSTRUCTORS
        public WelcomeViewModel(DelegateCommand updateViewCommand)
        {
            UpdateViewCommand = updateViewCommand;
        }
        #endregion

        #region GETTERS/SETTERS
        public DelegateCommand UpdateViewCommand { get; set; }
        #endregion
    }
}
