using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krtalic.Common.Json.Converters
{
    /// <summary>
    /// Custom JSON converter to convert DateTime value to only date with YYYY-MM-DD format
    /// </summary>
    public class IsoDateOnlyConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var nullable = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>);

            var t = nullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            DateTime dateTime;

            if (reader.TokenType == JsonToken.Date)
                dateTime = (DateTime)reader.Value;
            else if (reader.TokenType == JsonToken.String)
            {
                var s = (string)reader.Value;
                if (!DateTime.TryParse(s, out dateTime))
                    throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected date format: {0}.", s));
            }
            else
                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Unexpected token parsing date. Expected String, got {0}.", reader.TokenType));

            if (dateTime.Kind == DateTimeKind.Unspecified)
                dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Local);
            else
                dateTime = dateTime.ToLocalTime();

            if (t == typeof(DateTimeOffset))
                return new DateTimeOffset(dateTime);
            return dateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DateTime? date = null;

            if (value is DateTime?)
            {
                if (((DateTime?)value).HasValue)
                {
                    date = (DateTime?)value;
                }
            }
            else if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else
            {
                throw new NotSupportedException(string.Concat("Not supported object type: ", value.GetType()));
            }

            if (date.HasValue)
            {
                serializer.Serialize(writer, date.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}
