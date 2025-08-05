using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KubeCrafter.WinApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Theme handling
        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Dark");

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Light");
        #endregion
    }
}