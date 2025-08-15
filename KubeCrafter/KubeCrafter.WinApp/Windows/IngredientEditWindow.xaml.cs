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
using System.Windows.Shapes;
using KubeCrafter.Core.Base.Ingredient;

namespace KubeCrafter.WinApp.Windows
{
    /// <summary>
    /// Interakční logika pro IngredientEditWindow.xaml
    /// </summary>
    public partial class IngredientEditWindow : Window
    {
        #region Bindings
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnSelectedItemChanged();
                }
            }
        }
        public static List<string> ItemsList => [.. Enum.GetNames(typeof(IngredientType))];
        #endregion

        private void OnSelectedItemChanged()
        {
            if (CountUpDown == null) return;

            if (_selectedItem == "Tag")
            {
                CountText.Visibility = Visibility.Hidden;
                CountUpDown.Visibility = Visibility.Hidden;
            }
            else
            {
                CountText.Visibility = Visibility.Visible;
                CountUpDown.Visibility = Visibility.Visible;
            }
        }

        public Ingredient Ing { get; set; }

        public IngredientEditWindow(Ingredient ingredient)
        {
            Ing = ingredient;
            Ing.BeginEdit();
            SelectedItem = Enum.GetName(Ing.Type) ?? "Err. Ingredient has no type.";

            DataContext = this;

            InitializeComponent();
            
            ModTextBox.TextBoxChanged += ModTextBox_TextBoxChanged;
            ModTextBox.ShowedText = Ing.Mod;

            NameTextBox.TextBoxChanged += NameTextBox_TextBoxChanged;
            NameTextBox.ShowedText = Ing.Name;

            CountUpDown.NumChanged += CountUpDown_NumChanged;
            CountUpDown.NumberValue = Ing.Count.ToString();
        }

        #region Methods for Boxes
        private void CountUpDown_NumChanged(object? sender, EventArgs e)
        {
            if (CountUpDown.ToBeAdded < 0)
            {
                Ing.Count.SubtractSmall(-CountUpDown.ToBeAdded);
            }
            else
            {
                Ing.Count.AddSmall(CountUpDown.ToBeAdded);
            }

            CountUpDown.NumberValue = Ing.Count.ToString();
            CountUpDown.NumberBox.Text = Ing.Count.ToString();
        }

        private void ModTextBox_TextBoxChanged(object? sender, TextChangedEventArgs e)
        {
            Ing.Mod = ModTextBox.ShowedText;
        }

        private void NameTextBox_TextBoxChanged(object? sender, TextChangedEventArgs e)
        {
            Ing.Name = NameTextBox.ShowedText;
        }

        #endregion

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Ing.EndEdit();
            DialogResult = true;
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Ing.CancelEdit();
            DialogResult = false;
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
