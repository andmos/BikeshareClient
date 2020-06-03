using System;
using System.Diagnostics;
using BikeshareClient.Helpers;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
	[DebuggerDisplay("ID: {Id}, Name {Name}")]
    public class BikeStatus
    {
		[JsonConstructor]
		public BikeStatus(
			[JsonProperty("bike_id")]string id,
			[JsonProperty("name")]string name, 
			[JsonProperty("lat")]double latitude, 
			[JsonProperty("lon")]double longitude, 
			[JsonProperty("is_reserved"), JsonConverter(typeof(IntegerToBoolConverter))] bool reserved, 
			[JsonProperty("is_disabled"), JsonConverter(typeof(IntegerToBoolConverter))] bool disabled)
        {
			Id = id;
			Name = string.IsNullOrEmpty(name) ? id : name;
			Latitude = latitude;
			Longitude = longitude;
			Reserved = reserved;
            Disabled = disabled;
		}

        public string Id { get; private set; }

        public string Name { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public bool Reserved { get; private set; }

        public bool Disabled { get; private set; }
    }
}
