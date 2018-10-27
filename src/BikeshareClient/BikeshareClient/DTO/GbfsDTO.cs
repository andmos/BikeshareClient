using System;
using System.Collections.Generic;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BikeshareClient.DTO
{
	internal readonly struct GbfsDTO
    {
        [JsonConstructor]
        public GbfsDTO([JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastUpdated,
                       [JsonProperty("ttl")] int timeToLive,
                       [JsonProperty("data"), JsonConverter(typeof(FeedsConverter))] FeedsData[] feedsData)
        {
            LastUpdated = lastUpdated;
            TimeToLive = timeToLive;
            FeedsData = feedsData;
        }
        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public FeedsData[] FeedsData { get; }

    }

    internal struct FeedsData
    {
        [JsonConstructor]
        public FeedsData(Language language)
        {
            Language = language;
        }
        public Language Language { get; }
    }
        
}