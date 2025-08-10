using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core.Base.Setting
{
    public class Setting
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public SettingType Type { get; set; }
        public Dictionary<string, List<object>> Output { get; set; }
        public DynamicVariable Value { get; set; }


    }
}
