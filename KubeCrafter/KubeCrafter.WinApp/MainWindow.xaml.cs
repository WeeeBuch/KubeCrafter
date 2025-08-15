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
using KubeCrafter.Core.Base.Ingredient;
using KubeCrafter.Core.Base.Setting;
using KubeCrafter.WinApp.Templates;
using KubeCrafter.WinApp.Windows;

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

        private ObservableCollection<Setting> _settingsList;
        public ObservableCollection<Setting> SettingsList
        {
            get => _settingsList;
            set { _settingsList = value; OnPropertyChanged(nameof(SettingsList)); }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            ItemsList = ["Option1", "Option2", "Option3"];
            Formats = ["KubeJS", "JSON"];
            SettingsList = [
                new Setting()
                {
                    Id = "setting 1",
                    Label = "text test setting",
                    Output = new(),
                    Type = new SettingType()
                    {
                        TypeEnum = SettingTypeEnum.Text, 
                        Raw = "text"
                    },
                    Value = new("default test text", "text")
                },
                new Setting()
                {
                    Id = "setting 2",
                    Label = "number test setting",
                    Output = new(),
                    Type = new SettingType()
                    {
                        TypeEnum = SettingTypeEnum.Number,
                        Raw = "number"
                    },
                    Value = new(new KubeCrafter.Core.Number(10,20), "number")
                },
                new Setting()
                {
                    Id = "setting 3",
                    Label = "list test setting",
                    Output = new(),
                    Type = new SettingType()
                    {
                        TypeEnum = SettingTypeEnum.Array,
                        Raw = "array"
                    },
                    Value = new(new List<string>(["text1", "text2"]), "array")
                },
            ];
            BuildControlsFromSettings();
            DataContext = this;
        }

        private void BuildControlsFromSettings()
        {
            SettingsPanel.Children.Clear();
            for (int i = 0; i < SettingsList.Count; i++)
            {
                Setting s = SettingsList[i];

                UserControl ctrl = s.Type.TypeEnum switch
                {
                    SettingTypeEnum.Text => new TextSettingControl(s),
                    SettingTypeEnum.Number => new NumberSettingControl(s),
                    SettingTypeEnum.Array => new ListSettingControl(s),
                    _ => new TextSettingControl(s)
                };

                SettingsPanel.Children.Add(ctrl);

                if (i < SettingsList.Count - 1)
                {
                    var separator = new Line
                    {
                        X1 = 0,
                        Y1 = 0,
                        X2 = 1,
                        Y2 = 0,
                        Style = (Style)Application.Current.FindResource("BasicSeparatorLine")
                    };
                    SettingsPanel.Children.Add(separator);
                }
            }
        }

        #region Theme handling
        private void ThemeToggleButton_Checked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Dark");

        private void ThemeToggleButton_Unchecked(object sender, RoutedEventArgs e)
            => ((App)Application.Current).ApplyTheme("Light");
        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        #region Top bar
        private void btnMinimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

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