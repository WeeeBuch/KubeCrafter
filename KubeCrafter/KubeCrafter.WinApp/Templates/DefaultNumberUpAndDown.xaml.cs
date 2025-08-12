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
        public string NumberValue { get; set; }
        public int ToBeAdded = 0;
        public event EventHandler<EventArgs> NumChanged;
        public DefaultNumberUpAndDown()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            ToBeAdded = 10;
            NumChanged.Invoke(this, EventArgs.Empty);
            ToBeAdded = 0;
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            ToBeAdded = -10;
            NumChanged.Invoke(this, EventArgs.Empty);
            ToBeAdded = 0;
        }
    }
}
