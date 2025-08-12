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

namespace KubeCrafter.WinApp.Templates
{
    /// <summary>
    /// Interakční logika pro DefaultTextBox.xaml
    /// </summary>
    public partial class DefaultTextBox : UserControl
    {
        public string ShowedText { get; set; }
        public event EventHandler<TextChangedEventArgs> TextBoxChanged;

        public DefaultTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowedText = ((TextBox)sender).Text;
            TextBoxChanged?.Invoke(this, e);
        }
    }
}
