using System;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal readonly struct SystemInformationDTO
    {
		public SystemInformationDTO([JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))] DateTime lastupdated, 
		                            [JsonProperty("ttl")] int timeToLive,
		                            [JsonProperty("data")] SystemInformation systemInformation)
        {
			LastUpdated = lastupdated;
			TimeToLive = timeToLive;
			SystemInformation = systemInformation;
		}
        
		public DateTime LastUpdated { get; }

		public int TimeToLive { get; }

		public SystemInformation SystemInformation { get; }

    }
}
