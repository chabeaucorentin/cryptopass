using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        #region CONSTRUCTORS
        public LoginView()
        {
            InitializeComponent();
        }
        #endregion

        #region METHODS
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
                DashboardView d = new ();
                d.Show();
                Close();
            }
        }
        #endregion
    }
}
