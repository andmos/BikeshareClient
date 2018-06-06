using System;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.DTO
{
	internal class SystemInformationDTO
    {
		public SystemInformationDTO(int lastupdated, int timeToLive, SystemInformation systemInformation)
        {
			LastUpdated = lastupdated;
			TimeToLive = timeToLive;
			SystemInformation = systemInformation;
		}
        
		[JsonProperty("last_updated")]
		public int LastUpdated { get; private set; }

		[JsonProperty("ttl")]
		public int TimeToLive { get; private set; }

		[JsonProperty("data")]
		public SystemInformation SystemInformation { get; private set; }

    }
}
