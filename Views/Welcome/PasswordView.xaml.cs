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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModels;

namespace Views.Welcome
{
    /// <summary>
    /// Interaction logic for PasswordView.xaml
    /// </summary>
    public partial class PasswordView : UserControl
    {
        public PasswordView()
        {
            InitializeComponent();
        }

        private void BtnAccess_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPass.Password.Length == 0)
            {
                MessageBox.Show("Le mot de passe ne peut pas être vide !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (PasswordBoxConfirmPass.Password.Length == 0)
            {
                MessageBox.Show("La confirmation du mot de passe ne peut pas être vide !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!PasswordBoxPass.Password.Equals(PasswordBoxConfirmPass.Password))
            {
                MessageBox.Show("Les mots de passe ne correspondent pas !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                AppSettings.SetPass(PasswordBoxPass.Password);
                DashboardView d = new ();
                d.Show();
                Window.GetWindow(this).Close();
            }
        }
    }
}
