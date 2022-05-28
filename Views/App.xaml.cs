using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
