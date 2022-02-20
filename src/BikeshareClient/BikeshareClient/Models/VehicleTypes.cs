using System.Runtime.Serialization;
using BikeshareClient.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.Models
{
    public class VehicleTypes
    {
        [JsonConstructor]
        public VehicleTypes(
            [JsonProperty("vehicle_type_id")] string id,
            [JsonProperty("form_factor"), JsonConverter(typeof(StringEnumConverter))] VehicleFormFactor vehicleFormFactor,
            [JsonProperty("propulsion_type"), JsonConverter(typeof(StringEnumConverter))] PropulsionType propulsionType,
            [JsonProperty("max_range_meters")] long maxRangeMeters,
            [JsonProperty("name"), JsonConverter(typeof(TrimmingConverter))] string name
            )
        {
            Id = id;
            VehicleFormFactor = vehicleFormFactor;
            PropulsionType = propulsionType;
            MaxRangeMeters = maxRangeMeters;
            Name = string.IsNullOrEmpty(name) ? Id : name;
        }

        public string Id { get; }

        public VehicleFormFactor VehicleFormFactor { get; }

        public PropulsionType PropulsionType { get; }

        public long MaxRangeMeters { get; }

        public string Name { get; }

        public bool HasMaxRange => MaxRangeMeters > 0;
    }

    public enum VehicleFormFactor
    {
        [EnumMember(Value = "bicycle")]
        Bicycle,
        [EnumMember(Value = "car")]
        Car,
        [EnumMember(Value = "moped")]
        Moped,
        [EnumMember(Value = "scooter")]
        Scooter,
        [EnumMember(Value = "other")]
        Other
    }

    public enum PropulsionType
    {
        [EnumMember(Value = "human")]
        Human,
        [EnumMember(Value = "electric_assist")]
        ElectricAssist,
        [EnumMember(Value = "electric")]
        Electric,
        [EnumMember(Value = "combustion")]
        Combustion
    }
}
