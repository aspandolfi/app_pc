using ControleBO.Application.Utils;
using Newtonsoft.Json;
using System;

namespace ControleBO.Application.Converters
{
    public class DateTimeOffSetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                var date = (DateTime)reader.Value;
                return date.ConvertToLocalTime();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
