using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Json.Converters
{
    /// <summary>
    /// Variant of enum converter that outputs "" instead of default enum value (0)
    /// </summary>
    public class EmptyStringEnumConveter : StringEnumConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return 0;
            }
            else
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if ((int)value == 0)
            {
                writer.WriteValue("");
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}
