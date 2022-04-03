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
using Welcome.ViewModels;

namespace Welcome.Views
{
    /// <summary>
    /// Interaction logic for Welcome1View.xaml
    /// </summary>
    public partial class Welcome1View : UserControl
    {
        public Welcome1View()
        {
            InitializeComponent();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Welcome2ViewModel();
        }
    }
}
