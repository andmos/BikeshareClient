using System.Diagnostics;
using BikeshareClient.Helpers;
using Newtonsoft.Json;

namespace BikeshareClient.Models {
    [DebuggerDisplay("{Address} holds {Capacity} bikes, Id: {Id}", Name = "{Name}")]
    public class Station {
        public Station(string id, string name, string address, double latitude, double longitude, int capacity) {
            Id = id;
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            Capacity = capacity;
        }

        [JsonProperty("station_id")]
        public string Id { get; }

        [JsonProperty("name")]
        [JsonConverter(typeof(TrimmingConverter))]
        public string Name { get; }

        [JsonProperty("address")]
        public string Address { get; }

        [JsonProperty("lat")]
        public double Latitude { get; }

        [JsonProperty("lon")]
        public double Longitude { get; }

        [JsonProperty("capacity")]
        public int Capacity { get; }
    }

}
