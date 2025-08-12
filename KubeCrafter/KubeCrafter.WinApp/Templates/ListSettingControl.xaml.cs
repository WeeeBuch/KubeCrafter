using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using KubeCrafter.Core.Base;
using KubeCrafter.Core.Base.Ingredient;
using KubeCrafter.Core.Base.Setting;

namespace KubeCrafter.WinApp.Templates
{
    /// <summary>
    /// Interakční logika pro ListSettingControl.xaml
    /// </summary>
    public partial class ListSettingControl : UserControl
    {
        public Setting Setting { get; }
        private List<object> ItemsList { get; set; }

        public string _label;
        public string Label
        {
            get => _label;
            set
            {
                _label = value;
            }
        }

        public ListSettingControl(Setting setting)
        {
            InitializeComponent();
            Setting = setting;
            Label = setting.Label;
            DataContext = this;
            ItemsList = new List<object>(Setting.Value?.Value as IEnumerable<object>);
            BuildItems();
        }

        private void BuildItems()
        {
            ItemsPanel.Children.Clear();

            foreach (var item in ItemsList)
            {
                var ctrl = CreateControlForItem(item);
                ItemsPanel.Children.Add(ctrl);
            }
        }

        private UserControl CreateControlForItem(object item)
        {
            // Rozhodni podle typu, co použít
            return item switch
            {
                string str => new TextSettingControl(new Setting { Value = new DynamicVariable(str) }),
                int or double or float => new NumberSettingControl(new Setting { Value = new DynamicVariable(item) }),
                //Ingredient ingredient => new IngredientSettingControl(new Setting { Value = new DynamicVariable(ingredient) }),
                _ => new TextSettingControl(new Setting { Value = new DynamicVariable(item?.ToString() ?? "") })
            };
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            // Defaultní typ nové položky — třeba string
            ItemsList.Add(string.Empty);
            BuildItems();
        }
    }
}
