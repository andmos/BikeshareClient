using System;
using System.Collections.Generic;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.DTO
{
	internal class StationStatusDTO
    {
        public StationStatusDTO()
        {
        }

		[JsonProperty("last_updated")]
        public int LastUpdated { get; private set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; private set; }
        
		[JsonProperty("data")]
        public StationStatusData StationsStatus { get; private set; }

    }
	internal class StationStatusData
    {
        [JsonProperty("stations")]
        public IEnumerable<StationStatus> StationsStatus { get; set; }
    }
}
