using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Bindings
        private ObservableCollection<string> _itemsList;
        public ObservableCollection<string> ItemsList
        {
            get => _itemsList;
            set { _itemsList = value; OnPropertyChanged(nameof(ItemsList)); }
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> Formats { get; }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            ItemsList = ["Option1", "Option2", "Option3"];
            Formats = ["KubeJS", "JSON"];
            DataContext = this;
        }

        #region Theme handling
        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Dark");

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Light");
        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        #region Top bar
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized) WindowState = WindowState.Normal;
            else WindowState = WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => Close();

        #endregion

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("here will be output as text");
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            // some export method
        }

        private void FormatButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Content is string format)
            {
                // just for now
                MessageBox.Show($"Selected format: {format}");

            }
        }
    }
}