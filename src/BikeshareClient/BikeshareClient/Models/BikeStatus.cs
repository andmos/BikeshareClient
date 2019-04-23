using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
	[DebuggerDisplay("ID: {Id}, Name {Name}")]
    public class BikeStatus
    {
		[JsonConstructor]
		public BikeStatus([JsonProperty("bike_id")]string id,
		                  [JsonProperty("name")]string name, 
		                  [JsonProperty("lat")]double latitude, 
		                  [JsonProperty("lon")]double longitude, 
		                  [JsonProperty("is_reserved")]int reserved, 
		                  [JsonProperty("is_disabled")]int disabled)
        {
			Id = id;
			Name = name;
			Latitude = latitude;
			Longitude = longitude;
			Reserved = reserved;
            Disabled = disabled;
		}

        public string Id { get; private set; }

        public string Name { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public int Reserved { get; private set; }

        public int Disabled { get; private set; }
    }
}
