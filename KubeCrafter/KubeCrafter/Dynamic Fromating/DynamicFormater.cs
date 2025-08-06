using KubeCrafter.Core.Dynamic_Fromating;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace KubeCrafter.Core
{
    public static class DynamicFormater
    {
        public static string Format(object rawFormat, DynamicVariable variable)
        {
            if (rawFormat == null) throw new ArgumentNullException(nameof(rawFormat));

            string json;

            switch (rawFormat)
            {
                case string str:
                    json = str;
                    break;

                case JsonElement element:
                    json = element.GetRawText();
                    break;

                case List<object> list:
                    json = JsonSerializer.Serialize(list);
                    break;

                default:
                    throw new ArgumentException("Unsupported format type.");
            }

            var options = new JsonSerializerOptions();
            options.Converters.Add(new OutputLineConverter());

            var outputLines = JsonSerializer.Deserialize<List<IOutputLine>>(json, options)
                ?? throw new ArgumentException("Invalid or empty format.");

            return Render(outputLines, variable);
        }

        public static string Render(List<IOutputLine> lines, DynamicVariable variable)
        {
            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                switch (line)
                {
                    case TextLine text:
                        sb.AppendLine(text.Value);
                        break;

                    case RepeatBlock repeat:
                        if (variable.Value == null) continue;

                        if (repeat.Type == "array" && variable.Value is List<object> list)
                        {
                            foreach (var item in list)
                            {
                                var formatted = repeat.Format.Replace($"<{repeat.Var}>", item.ToString());
                                sb.AppendLine(formatted);
                            }
                        }
                        else if (repeat.Type == "map" && variable.Value is Dictionary<string, object> dict)
                        {
                            foreach (var kvp in dict)
                            {
                                var formatted = repeat.Format
                                    .Replace($"<{repeat.Key}>", kvp.Key)
                                    .Replace($"<{repeat.Var}>", SafeToString(kvp.Value));
                                sb.AppendLine(formatted);
                            }
                        }
                        break;
                }
            }

            return sb.ToString();
        }

        private static string SafeToString(object? obj)
        {
            return obj switch
            {
                null => "",

                string s => s,

                Number n => n.ToString(),

                Ingredient i => i.ToKubeJS(),

                DynamicVariable dv => SafeToString(dv.Value),

                JsonElement e => e.ToString(),

                _ => obj.ToString() ?? ""
            };
        }
    }
}
