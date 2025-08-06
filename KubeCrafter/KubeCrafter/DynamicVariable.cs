using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubeCrafter.Core
{
    public class DynamicVariable
    {
        public object? Value { get; set; }
        public string? Type { get; set; }

        public DynamicVariable(object? value, string? type = null)
        {
            Value = value; 
            Type = type;
        }

        public string ToKubeJS()
        {
            return "";
        }

        public string ToJSON()
        {
            return "";
        }
    }
}
