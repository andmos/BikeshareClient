using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.models
{
    public class StationStatus
    {
		public StationStatus(string id, int bikesAvailable, int docksAvailable, int installed, int renting, int returning, DateTime lastReported)
        {
			Id = id;
			BikesAvailable = bikesAvailable;
			DocksAvailable = docksAvailable;
			Installed = installed;
			Renting = renting;
			Returning = returning;
			LastReported = lastReported;
		}
        
		[JsonProperty("station_id")]
		public string Id { get; private set; }

		[JsonProperty("num_bikes_available")]
		public int BikesAvailable { get; private set; }

		[JsonProperty("num_bikes_disabled")]
		public int BikesDisabled { get; private set; }

		[JsonProperty("num_docks_available")]
		public int DocksAvailable { get; private set; }

		[JsonProperty("is_installed")]
		public int Installed { get; private set; }

		[JsonProperty("is_renting")]
		public int Renting { get; private set; }

		[JsonProperty("is_returning")]
		public int Returning { get; private set; }

		[JsonProperty("num_docks_disabled")]
		public int DocksDisabled { get; private set; }

		[JsonProperty("last_reported"), JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime LastReported { get; private set; }

	}
}
