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
using KubeCrafter.Core.Base.Setting;

namespace KubeCrafter.WinApp.Templates
{
    /// <summary>
    /// Interakční logika pro DefaultNumberUpAndDown.xaml
    /// </summary>
    public partial class DefaultNumberUpAndDown : UserControl
    {
        private string _numberValue;
        public string NumberValue 
        { 
            get => _numberValue; 
            set 
            { 
                _numberValue = value;
                NumberBox.Text = NumberValue; 
            } 
        }
        public event EventHandler<bool> NumChanged;
        public DefaultNumberUpAndDown()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            NumChanged.Invoke(this, true);
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            NumChanged.Invoke(this, false);
        }
    }
}
