using System;
using System.Collections.Generic;
using BikeshareClient.Helpers;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
    internal readonly struct VehicleTypesDTO
    {
        public VehicleTypesDTO(
            [JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastupdated,
            [JsonProperty("ttl")] int timeToLive,
            [JsonProperty("version"), JsonConverter(typeof(StringToSemanticVersionConverter))] SemanticVersion version,
            [JsonProperty("data")] VehicleTypesData vehiclesTypesData)
        {
            LastUpdated = lastupdated;
            TimeToLive = timeToLive;
            Version = version ?? new SemanticVersion("2.1");
            VehiclesTypesData = vehiclesTypesData;
        }

        public DateTime LastUpdated { get; }

        public int TimeToLive { get; }

        public SemanticVersion Version { get; }

        public VehicleTypesData VehiclesTypesData { get; }
    }

    internal struct VehicleTypesData
    {
        [JsonConstructor]
        public VehicleTypesData([JsonProperty("vehicle_types")] IEnumerable<VehicleTypes> vehicleTypes)
        {
            VehicleTypes = vehicleTypes;
        }

        public IEnumerable<VehicleTypes> VehicleTypes { get; }
    }
}
