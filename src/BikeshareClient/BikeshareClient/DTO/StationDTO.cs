using System;
using System.Collections.Generic;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.DTO
{
	internal class StationDTO
    {
		public StationDTO(int lastupdated, int timeToLive, StationData stationData)
        {
			LastUpdated = lastupdated;
            TimeToLive = timeToLive;
			StationsData = stationData;
        }

		[JsonProperty("last_updated")]
        public int LastUpdated { get; private set; }

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
