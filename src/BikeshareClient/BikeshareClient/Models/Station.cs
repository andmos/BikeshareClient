using System.Diagnostics;
using BikeshareClient.Helpers;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
    [DebuggerDisplay("{Address} holds {Capacity} bikes, Id: {Id}", Name = "{Name}")]
    public class Station
    {
        [JsonConstructor]
        public Station([JsonProperty("station_id")] string id,
                       [JsonProperty("name"), JsonConverter(typeof(TrimmingConverter))] string name,
                       [JsonProperty("address")] string address,
                       [JsonProperty("lat")] double latitude,
                       [JsonProperty("lon")] double longitude,
                       [JsonProperty("capacity")] int capacity)
        {
            Id = id;
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Capacity = capacity;
        }

        public string Id { get; }

        public string Name { get; }

        public string Address { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public int Capacity { get; }
    }

}
