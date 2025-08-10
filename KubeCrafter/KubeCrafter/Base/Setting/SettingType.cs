using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core.Base.Setting
{
    public class SettingType
    {

        public string Raw { get; set; }
        public SettingTypeEnum TypeEnum { get; set; }
        public string? ElementType { get; set; }
        public string? KeyType { get; set; }
        public string? ValueType { get; set; }


    }

    public enum SettingTypeEnum
    {
        Text,
        Number,
        Ingredient,
        Array,
        Map
    }
}
