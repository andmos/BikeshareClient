using System;
using System.Collections.Generic;
using BikeshareClient.DTO;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BikeshareClient.Helpers
{
	public class FeedsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GbfsDTO);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            var root = jObject.Root.SelectToken("data");

            List<FeedsData> result = new List<FeedsData>();
            foreach (var childToken in jObject.Children().Children())
            {
                var feedsToken = childToken.SelectToken("feeds");
                var feeds = feedsToken.ToObject<Feed[]>();
				var language = new Language(feeds, childToken.Path);
                var feedsData = new FeedsData(language);
                result.Add(feedsData);
            }
            return result.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			throw new NotImplementedException();
        }
    }
}
