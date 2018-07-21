using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Models;

namespace BikeshareClient.Providers
{
	public class StationStatusProvider : ProviderBase
    {
		public async Task<IEnumerable<StationStatus>> GetStationsStatusAsync(string pathUrl)
        {
			var resourceName = "station_status.json";
			var stationStatusDto = await base.GetProivderEndpointDtoAsync<StationStatusDTO>(pathUrl, resourceName);

			return stationStatusDto.StationsStatus.StationsStatus;
        }
    }
}
