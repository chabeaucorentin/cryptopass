using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region CONSTRUCTORS
        public App()
        {
            if (AppSettings.PassExist())
            {
                LoginView l = new ();
                l.Show();
            }
            else
            {
                WelcomeView w = new ();
                w.Show();
            }
        }
        #endregion
    }
}
