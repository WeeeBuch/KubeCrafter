using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using KubeCrafter.Core.Base.Setting;

namespace KubeCrafter.WinApp.Templates
{
    /// <summary>
    /// Interakční logika pro TextSettingControl.xaml
    /// </summary>
    public partial class TextSettingControl : UserControl, INotifyPropertyChanged
    {
        public Setting Setting
        {
            get;
            set;
        }

        public string _label;
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
                OnPropertyChanged(nameof(Label));
            }
        }

        public string _value;
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                if (Setting != null && Setting.Value != null)
                {
                    Setting.Value.Value = value;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private static void OnSettingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TextSettingControl)d).DataContext = d;
        }

        public void TextBoxTextChanged(object sender, EventArgs e)
        {
            Value = TextBox.ShowedText;
        }

        public TextSettingControl(Setting s)
        {
            Setting = s;
            Label = s.Label;
            Value = s.Value.Value.ToString();
            DataContext = this;

            InitializeComponent();

            TextBox.ShowedText = Value;
            TextBox.TextBoxChanged += TextBoxTextChanged;
        }
    }
}
