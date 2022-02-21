using System;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct SystemInformationDTO
    {
        public SystemInformationDTO(
            [JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastupdated,
            [JsonProperty("ttl")] int timeToLive,
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))] SemanticVersion version,
            [JsonProperty("data")] SystemInformation systemInformation)
        {
            LastUpdated = lastupdated;
            TimeToLive = timeToLive;
            Version = version ?? new SemanticVersion("1.0");
            SystemInformation = systemInformation;
        }

        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public SemanticVersion Version { get; }

        public SystemInformation SystemInformation { get; }

    }
}
