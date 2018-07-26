using System;
using Newtonsoft.Json;

namespace BikeshareClient.Models
{
    public class BikeStatus
    {
		[JsonConstructor]
		public BikeStatus([JsonProperty("bike_id")]string id,
		                  [JsonProperty("name")]string name, 
		                  [JsonProperty("lat")]double latitude, 
		                  [JsonProperty("lon")]double longitude, 
		                  [JsonProperty("is_renting")]int renting, 
		                  [JsonProperty("is_returning")]int returning)
        {
			Id = id;
			Name = name;
			Latitude = latitude;
			Longitude = longitude;
			Renting = renting;
			Returning = returning;
		}

        public string Id { get; private set; }

        public string Name { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public int Renting { get; private set; }

        public int Returning { get; private set; }
    }
}
