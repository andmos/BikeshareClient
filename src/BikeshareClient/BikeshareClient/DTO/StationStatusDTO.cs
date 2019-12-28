using System;
using System.Collections.Generic;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct StationStatusDTO
    {
        [JsonConstructor]
        public StationStatusDTO(
            [JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]DateTime lastUpdated, 
            [JsonProperty("ttl")] int timeToLive,
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))] SemanticVersion version,
            [JsonProperty("data")]StationStatusData stationStatusData)
        {
            LastUpdated = lastUpdated;
            TimeToLive = timeToLive;
            Version = version ?? new SemanticVersion("1.0");
            StationsStatusData = stationStatusData; 
        }


        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public SemanticVersion Version { get; }

        public StationStatusData StationsStatusData { get; }

    }
    internal struct StationStatusData
    {
        [JsonConstructor]
        public StationStatusData(IEnumerable<StationStatus> stations)
        {
            StationsStatus = stations;
        }
        
        public IEnumerable<StationStatus> StationsStatus { get; }
    }
}
