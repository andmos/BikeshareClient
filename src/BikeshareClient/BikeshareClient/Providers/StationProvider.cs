using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Models;

namespace BikeshareClient.Providers
{
	public class StationProvider : ProviderBase
    {
		public async Task<IEnumerable<Station>> GetStationsAsync(string pathUrl)
		{
			var resourceName = "station_information.json";
			var stationDto = await GetProivderEndpointDtoAsync<StationDTO>(pathUrl, resourceName);

			return stationDto.StationsData.Stations;
		}
    }
}
