﻿using System;
using System.Collections.Generic;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct BikeStatusDTO
    {
        [JsonConstructor]
        public BikeStatusDTO(
            [JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastUpdate,
            [JsonProperty("ttl")] int timeToLive,
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))] SemanticVersion version,
            [JsonProperty("data")] BikeStatusData bikeData)
        {
            LastUpdated = lastUpdate;
            TimeToLive = timeToLive;
            Version = version ?? new SemanticVersion("1.0");
            BikeStatusData = bikeData;
        }

        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public SemanticVersion Version { get; }

        public BikeStatusData BikeStatusData { get; }
    }

    internal struct BikeStatusData
    {
        [JsonConstructor]
        public BikeStatusData(IEnumerable<BikeStatus> bikes)
        {
            Bikes = bikes;
        }

        public IEnumerable<BikeStatus> Bikes { get; }
    }

}