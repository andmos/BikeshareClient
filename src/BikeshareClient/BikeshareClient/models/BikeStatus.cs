using System;
using Newtonsoft.Json;

namespace BikeshareClient.models
{
    public class BikeStatus
    {
		public BikeStatus(string id, string name, double latitude, double longitude, int renting, int returning)
        {
			Id = id;
			Name = name;
			Latitude = latitude;
			Longitude = longitude;
			Renting = renting;
			Returning = returning;
		}

		[JsonProperty("bike_id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

		[JsonProperty("lat")]
        public double Latitude { get; private set; }

        [JsonProperty("lon")]
        public double Longitude { get; private set; }

		[JsonProperty("is_renting")]
        public int Renting { get; private set; }

        [JsonProperty("is_returning")]
        public int Returning { get; private set; }
    }
}
