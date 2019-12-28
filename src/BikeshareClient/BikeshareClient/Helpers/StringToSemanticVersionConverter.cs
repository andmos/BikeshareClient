using System;
using Newtonsoft.Json;
namespace BikeshareClient.Helpers
{
    public class StringToSemanticVersionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            SemanticVersion version;
            var parsed = SemanticVersion.TryParse(reader.Value.ToString(), out version);
            return parsed ? version : new SemanticVersion("1.0");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
