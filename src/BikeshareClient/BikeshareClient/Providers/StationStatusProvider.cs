using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
	public class StationStatusProvider : ProviderBase
    {
		public async Task<IEnumerable<StationStatus>> GetStationsStatusAsync(string pathUrl)
        {
			var stationStatusDto = await base.GetProivderEndpointDtoAsync<StationStatusDTO>(pathUrl);

			return stationStatusDto.StationsStatus.StationsStatus;
        }
    }
}
