using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels.Dashboard;

namespace Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        public DashboardView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsView s = new ();
            s.ShowDialog();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutView a = new ();
            a.ShowDialog();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginView l = new ();
            l.Show();
            Close();
        }
    }
}
