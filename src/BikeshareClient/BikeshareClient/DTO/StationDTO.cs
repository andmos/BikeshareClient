using System;
using System.Collections.Generic;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct StationDTO
    {
        [JsonConstructor]
        public StationDTO(
            [JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastUpdated,
            [JsonProperty("ttl")] int timeToLive,
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))] SemanticVersion version,
            [JsonProperty("data")] StationData stationsData)
        {
            LastUpdated = lastUpdated;
            TimeToLive = timeToLive;
            Version = version ?? new SemanticVersion("1.0");
            StationsData = stationsData;
        }

        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public SemanticVersion Version { get; }

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
