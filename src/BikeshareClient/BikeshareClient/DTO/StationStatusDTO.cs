using System;
using System.Collections.Generic;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal struct StationStatusDTO
    {
		public StationStatusDTO(DateTime lastUpdated, int timeToLive, StationStatusData stationStatusData)
        {
            LastUpdated = lastUpdated;
            TimeToLive = timeToLive;
            StationsStatus = stationStatusData; 
        }

		[JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime LastUpdated { get; private set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; private set; }
        
		[JsonProperty("data")]
        public StationStatusData StationsStatus { get; private set; }

    }
	internal struct StationStatusData
    {
        [JsonProperty("stations")]
		public IEnumerable<StationStatus> StationsStatus { get; private set; }
    }
}
