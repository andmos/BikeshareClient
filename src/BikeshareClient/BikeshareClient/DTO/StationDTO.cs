using System;
using System.Collections.Generic;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal class StationDTO
    {
		public StationDTO(DateTime lastupdated, int timeToLive, StationData stationData)
        {
			LastUpdated = lastupdated;
            TimeToLive = timeToLive;
			StationsData = stationData;
        }

		[JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime LastUpdated { get; private set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; private set; }
        
		[JsonProperty("data")]
		public StationData StationsData { get; private set; }
    }
    
	internal class StationData
    {
		[JsonProperty("stations")]
		public IEnumerable<Station> Stations { get; set; }
    }

}
