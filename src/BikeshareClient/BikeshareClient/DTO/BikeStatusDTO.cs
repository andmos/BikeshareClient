using System;
using System.Collections.Generic;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal struct BikeStatusDTO
    {
		public BikeStatusDTO(DateTime lastUpdate, int timeToLive, BikeStatusData bikeData)
        {
			LastUpdated = lastUpdate;
			TimeToLive = timeToLive;
			BikeStatusData = bikeData; 
		}

		[JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastUpdated { get; private set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; private set; }

        [JsonProperty("data")]
		public BikeStatusData BikeStatusData { get; private set; }
	}

	internal class BikeStatusData
    {
		[JsonProperty("bikes")]
		public IEnumerable<BikeStatus> Bikes { get; private set; }
    }

}


