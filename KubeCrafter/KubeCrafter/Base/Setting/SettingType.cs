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
        public bool IsArray { get; set; }
        public bool IsMap { get; set; }
        public string? ElementType { get; set; }
        public string? KeyType { get; set; }
        public string? ValueType { get; set; }


    }
}
