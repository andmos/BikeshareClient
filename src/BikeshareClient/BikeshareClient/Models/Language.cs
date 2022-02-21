using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
    public class Language
    {
        [JsonConstructor]
        public Language([JsonProperty("feeds")] IEnumerable<Feed> feeds, string name)
        {
            Feeds = feeds;
            Name = name;

        }
        public string Name { get; }
        public IEnumerable<Feed> Feeds { get; }
    }
}
