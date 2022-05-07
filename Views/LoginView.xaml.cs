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
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnUnlock_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPass.Password.Length == 0)
            {
                MessageBox.Show("Le mot de passe ne peut pas être vide !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!AppSettings.CheckPass(PasswordBoxPass.Password))
            {
                MessageBox.Show("Le mot de passe entré est incorrect !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DashboardView d = new();
                d.Show();
                Close();
            }
        }
    }
}
