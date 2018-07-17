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
			var bikesStatus = await GetProivderEndpointDtoAsync<BikeStatusDTO>(pathUrl);

			return bikesStatus.BikeData.Bikes;
        }
    }
}
