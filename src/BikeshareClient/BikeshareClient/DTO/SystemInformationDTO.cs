using System;
using BikeshareClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BikeshareClient.DTO
{
	internal class SystemInformationDTO
    {
		public SystemInformationDTO(DateTime lastupdated, int timeToLive, SystemInformation systemInformation)
        {
			LastUpdated = lastupdated;
			TimeToLive = timeToLive;
			SystemInformation = systemInformation;
		}
        
		[JsonProperty("last_updated"), JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime LastUpdated { get; private set; }

		[JsonProperty("ttl")]
		public int TimeToLive { get; private set; }

		[JsonProperty("data")]
		public SystemInformation SystemInformation { get; private set; }

    }
}
