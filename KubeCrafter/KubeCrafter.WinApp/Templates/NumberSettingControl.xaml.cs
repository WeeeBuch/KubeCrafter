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
using KubeCrafter.Core;
using KubeCrafter.Core.Base.Setting;

namespace KubeCrafter.WinApp.Templates
{
    /// <summary>
    /// Interakční logika pro NumberSettingControl.xaml
    /// </summary>
    public partial class NumberSettingControl : UserControl
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
            }
        }

        public Number _value;
        public Number Value
        {
            get => _value;
            set
            {
                _value = value;
                if (Setting != null && Setting.Value != null)
                {
                    Setting.Value.Value = value;
                }
            }
        }

        public NumberSettingControl(Setting s)
        {
            Setting = s;
            Label = s.Label;
            Value = (Number)s.Value.Value;
            DataContext = this;
            InitializeComponent();

            DefaulNumerUD.NumChanged += NumberChanged;
            DefaulNumerUD.NumberValue = Value.ToString();
        }

        public void NumberChanged(object sender, EventArgs e)
        {
            if (DefaulNumerUD.ToBeAdded < 0)
            {
                Value.SubtractSmall(-DefaulNumerUD.ToBeAdded);
            }
            else 
            {
                Value.AddSmall(DefaulNumerUD.ToBeAdded);
            }  

            DefaulNumerUD.NumberValue = Value.ToString();
            DefaulNumerUD.NumberBox.Text = Value.ToString();
        } 
    }
}
