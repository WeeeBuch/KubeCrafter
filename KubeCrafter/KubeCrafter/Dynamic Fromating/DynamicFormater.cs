using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace KubeCrafter.Core
{
    public static class DynamicFormater
    {
        public static string FormateSetting(object format)
        {
            StringBuilder sb = new StringBuilder();

            JsonElement jsonValue = JsonSerializer.Deserialize(format);





            return sb.ToString();
        }

    }
}
