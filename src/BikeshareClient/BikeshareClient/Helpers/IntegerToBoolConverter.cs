using System;
using Newtonsoft.Json;

namespace BikeshareClient.Helpers
{
    public class IntegerToBoolConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool boolReturnValue;
            if(Boolean.TryParse(reader.Value.ToString(), out boolReturnValue))
            {
                return boolReturnValue;
            }
            return reader.Value.ToString() == "1";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }
    }
}
