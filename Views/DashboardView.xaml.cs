using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModels.Dashboard;
using System.ComponentModel;

namespace Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : Window
    {
        #region MEMBER VARIABLES
        private MainViewModel _mainViewModel;
        #endregion

        #region CONSTRUCTORS
        public DashboardView()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;
        }
        #endregion

        #region METHODS
        private static string? SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new ();
            saveFileDialog.Filter = "Fichier JSON (*.json)|*.json";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        private static string? OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new ();
            openFileDialog.Filter = "Fichier JSON (*.json)|*.json";
            DialogResult result = openFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return null;
        }

        private void BtnExportPasswords_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = SaveFileDialog();
            if (fileName != null)
            {
                _mainViewModel.PasswordsViewModel.Save(fileName);
            }
        }

        private void BtnExportNotes_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = SaveFileDialog();
            if (fileName != null)
            {
                _mainViewModel.NotesViewModel.Save(fileName);
            }
        }

        private void BtnExportPayments_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = SaveFileDialog();
            if (fileName != null)
            {
                _mainViewModel.PaymentsViewModel.Save(fileName);
            }
        }

        private void BtnImportPasswords_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = OpenFileDialog();
            if (fileName != null)
            {
                _mainViewModel.PasswordsViewModel.Load(fileName);
            }
        }

        private void BtnImportNotes_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = OpenFileDialog();
            if (fileName != null)
            {
                _mainViewModel.NotesViewModel.Load(fileName);
            }
        }

        private void BtnImportPayments_Click(object sender, RoutedEventArgs e)
        {
            string? fileName = OpenFileDialog();
            if (fileName != null)
            {
                _mainViewModel.PaymentsViewModel.Load(fileName);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_mainViewModel.HasChanged())
            {
                switch (System.Windows.Forms.MessageBox.Show("Souhaitez-vous enregistrer les modifications ?",
                    "CryptoPass", MessageBoxButtons.YesNoCancel))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        _mainViewModel.Save();
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            base.OnClosing(e);
        }
        #endregion
    }
}
