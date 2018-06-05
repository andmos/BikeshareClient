using System;
using Newtonsoft.Json;

namespace BikeshareClient.models
{
    public class StationStatus
    {
		public StationStatus(int id, int bikesAvailable, int docksAvailable, int installed, int renting, int returning, DateTime lastReported)
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
        public int Id { get; private set; }

		[JsonProperty("num_bikes_available")]
		public int BikesAvailable { get; set; }

		[JsonProperty("num_docks_available")]
        public int DocksAvailable { get; set; }

		[JsonProperty("is_installed")]
		public int Installed { get; set; }

		[JsonProperty("is_renting")]
        public int Renting { get; set; }

		[JsonProperty("is_returning")]
        public int Returning { get; set; }

		[JsonProperty("last_report")]
		public DateTime LastReported { get; set; }

	}
}
