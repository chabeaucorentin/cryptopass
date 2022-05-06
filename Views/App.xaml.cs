using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DashboardView d = new();
            d.Show();
            WelcomeView w = new();
            w.Show();
            AboutView a = new();
            a.Show();
            LoginView l = new();
            l.Show();
            SettingsView s = new();
            s.Show();
        }
    }
}
