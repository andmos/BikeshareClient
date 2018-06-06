using System;
using Newtonsoft.Json;

namespace BikeshareClient.models
{
    public class Station
    {
		public Station(string id, string name, string address, double latitude, double longitude, int capacity)
        {
			Id = id;
			Name = name;
			Address = address;
			Latitude = latitude;
			Longitude = longitude;
			Capacity = capacity; 
		}

		[JsonProperty("station_id")]
		public string Id { get; private set; }

		[JsonProperty("name")]
		public string Name { get; private set; }

		[JsonProperty("address")]
		public string Address { get; private set; }

		[JsonProperty("lat")]
		public double Latitude { get; private set; }

		[JsonProperty("lon")]
		public double Longitude { get; private set; }

		[JsonProperty("capacity")]
		public int Capacity { get; private set; }
	}

}
