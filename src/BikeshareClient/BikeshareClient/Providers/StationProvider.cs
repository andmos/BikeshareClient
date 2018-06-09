using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;

namespace BikeshareClient.Providers
{
	public class StationProvider : ProviderBase
    {
		public async Task<IEnumerable<Station>> GetStationsAsync(string pathUrl)
		{
			var stationDto = await GetProivderEndpointDtoAsync<StationDTO>(pathUrl);

			return stationDto.StationsData.Stations;
		}
    }
}
