using System.Windows;
using ViewModels.Welcome;

namespace Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Window
    {
        #region CONSTRUCTORS
        public WelcomeView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        #endregion
    }
}
