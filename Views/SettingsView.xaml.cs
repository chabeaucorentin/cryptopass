using System.Windows;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        #region CONSTRUCTORS
        public SettingsView()
        {
            InitializeComponent();
            TextBoxPath.Text = AppSettings.GetPath();
        }
        #endregion

        #region METHODS
        private bool UpdateSettings()
        {

            if (PasswordBoxLastPassword.Password.Length > 0)
            {
                if (!AppSettings.CheckPass(PasswordBoxLastPassword.Password))
                {
                    MessageBox.Show("Le mot de passe entré est incorrect !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (PasswordBoxNewPassword.Password.Length == 0)
                {
                    MessageBox.Show("Le nouveau mot de passe ne peut pas être vide !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (!PasswordBoxNewPassword.Password.Equals(PasswordBoxConfirmNewPassword.Password))
                {
                    MessageBox.Show("Le nouveau mot de passe ne correspond pas !", "CryptoPass", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    AppSettings.SetPass(PasswordBoxNewPassword.Password);
                }
            }

            AppSettings.SetPath(TextBoxPath.Text);

            return true;
        }

        private void BtnSelectPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new ();
            folderBrowserDialog.SelectedPath = TextBoxPath.Text;
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateSettings())
            {
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateSettings())
            {
                PasswordBoxLastPassword.Password = "";
                PasswordBoxNewPassword.Password = "";
                PasswordBoxConfirmNewPassword.Password = "";
            }
        }
        #endregion
    }
}
