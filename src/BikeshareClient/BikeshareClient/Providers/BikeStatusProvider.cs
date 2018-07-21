using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Models;

namespace BikeshareClient.Providers
{
	public class BikeStatusProvider : ProviderBase
    {
		public async Task<IEnumerable<BikeStatus>> GetBikeStatusAsync(string pathUrl)
        {
			var resourceName = "free_bike_status.json";
			var bikesStatus = await GetProivderEndpointDtoAsync<BikeStatusDTO>(pathUrl, resourceName);

			return bikesStatus.BikeData.Bikes;
        }
    }
}
