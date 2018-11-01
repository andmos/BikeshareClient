using System;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
    public class Feed
    {
		[JsonConstructor]
		public Feed([JsonProperty("name")]string name,
		            [JsonProperty("url")]string url)
        {
			Name = name;
			Url = url;
		}

		public string Name { get; private set; }
		public string Url { get; private set; }
    }
}
