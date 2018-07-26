using System;
using System.Collections.Generic;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct StationDTO
    {
        [JsonConstructor]
        public StationDTO([JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastUpdated,
                          [JsonProperty("ttl")] int timeToLive,
                          [JsonProperty("data")] StationData stationsData)
        {
            LastUpdated = lastUpdated;
            TimeToLive = timeToLive;
            StationsData = stationsData;
        }

        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public StationData StationsData { get; }
    }

    internal struct StationData
    {
        [JsonConstructor]
        public StationData(IEnumerable<Station> stations)
        {
            Stations = stations;
        }

        public IEnumerable<Station> Stations { get; }
    }

}
