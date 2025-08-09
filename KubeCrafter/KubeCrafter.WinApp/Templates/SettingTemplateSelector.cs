using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KubeCrafter.Core.Base.Setting;

namespace KubeCrafter.WinApp.Templates
{
    public class SettingTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate NumberTemplate { get; set; }
        public DataTemplate ListTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Setting setting = (Setting)item;

            switch (setting.Type.TypeEnum)
            {
                case SettingTypeEnum.Text:
                    return TextTemplate;
                case SettingTypeEnum.Number:
                    return NumberTemplate;
                case SettingTypeEnum.Array:
                    return ListTemplate;
                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
