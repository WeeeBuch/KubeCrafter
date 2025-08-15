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
using KubeCrafter.Core;
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
            UserControl control;

            switch (item)
            {
                case string str:
                    control = new DefaultTextBox();
                    ((DefaultTextBox)control).ShowedText = str;
                    ((DefaultTextBox)control).TextBoxChanged += (s, e) =>
                    {
                        if (s is DefaultTextBox textBox)
                        {
                            int index = ItemsList.IndexOf(item);
                            if (index >= 0)
                            {
                                ItemsList[index] = textBox.ShowedText;
                                Setting.Value.Value = ItemsList;
                            }
                        }
                    };
                    break;

                case Number number:
                    control = new DefaultNumberUpAndDown();
                    ((DefaultNumberUpAndDown)control).NumberValue = number.ToString();
                    ((DefaultNumberUpAndDown)control).NumChanged += (s, e) =>
                    {
                        if (s is DefaultNumberUpAndDown numberControl)
                        {
                            int index = ItemsList.IndexOf(number);
                            if (index >= 0)
                            {
                                if (numberControl.ToBeAdded < 0)
                                {
                                    number.SubtractSmall(-numberControl.ToBeAdded);
                                }
                                else
                                {
                                    number.AddSmall(numberControl.ToBeAdded);
                                }

                                numberControl.NumberValue = number.ToString();
                                numberControl.NumberBox.Text = number.ToString();
                                ItemsList[index] = number;
                                Setting.Value.Value = ItemsList;
                            }
                        }
                    };

                    break;

                default:
                    control = new DefaultTextBox();
                    ((DefaultTextBox)control).ShowedText = item.ToString() ?? "Null is here";
                    ((DefaultTextBox)control).TextBoxChanged += (s, e) =>
                    {
                        if (s is DefaultTextBox textBox)
                        {
                            int index = ItemsList.IndexOf(item);
                            if (index >= 0)
                            {
                                ItemsList[index] = textBox.ShowedText;
                                Setting.Value.Value = ItemsList;
                            }
                        }
                    };
                    break;
            }

            return control;

            /*
            return item switch
            {
                string str => new DefaultTextBox() { ShowedText = str},
                int or double or float => new NumberSettingControl(new Setting { Value = new DynamicVariable(item) }),
                //Ingredient ingredient => new IngredientSettingControl(new Setting { Value = new DynamicVariable(ingredient) }),
                _ => new TextSettingControl(new Setting { Value = new DynamicVariable(item?.ToString() ?? "") })
            };
            */
        }
    }
}
