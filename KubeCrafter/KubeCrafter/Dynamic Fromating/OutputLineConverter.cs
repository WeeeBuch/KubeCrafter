using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KubeCrafter.Core.Dynamic_Fromating
{
    public class OutputLineConverter : JsonConverter<IOutputLine>
    {
        public override IOutputLine Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new TextLine { Value = reader.GetString() };
            }

            using var doc = JsonDocument.ParseValue(ref reader);
            var obj = doc.RootElement;

            if (obj.TryGetProperty("repeat", out var repeat))
            {
                var block = new RepeatBlock
                {
                    Type = repeat.GetProperty("type").GetString(),
                    Var = repeat.GetProperty("var").GetString(),
                    Format = repeat.GetProperty("format").GetString(),
                };

                if (repeat.TryGetProperty("key", out var keyProp))
                    block.Key = keyProp.GetString();

                return block;
            }

            throw new JsonException("Unknown output line type.");
        }

        public override void Write(Utf8JsonWriter writer, IOutputLine value, JsonSerializerOptions options)
        {
            throw new NotImplementedException("Unsupported – read only.");
        }
    }
}
