using System;
using System.Collections.Generic;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal struct BikeStatusDTO
    {
		public BikeStatusDTO(DateTime lastUpdate, int timeToLive, BikeData bikeData)
        {
			LastUpdated = lastUpdate;
			TimeToLive = timeToLive;
			BikeData = bikeData; 
		}

		[JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastUpdated { get; private set; }

        [JsonProperty("ttl")]
        public int TimeToLive { get; private set; }

        [JsonProperty("data")]
		public BikeData BikeData { get; private set; }
	}

	internal class BikeData
    {
		[JsonProperty("bikes")]
		public IEnumerable<BikeStatus> Bikes { get; private set; }
    }

}


