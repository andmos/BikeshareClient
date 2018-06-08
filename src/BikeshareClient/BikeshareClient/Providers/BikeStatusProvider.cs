using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
    public class BikeStatusProvider
    {
		public async Task<IEnumerable<BikeStatus>> GetBikeStatusAsync(string pathUrl)
        {
            if (string.IsNullOrEmpty(pathUrl))
            {
                throw new ArgumentNullException();
            }

			BikeStatusDTO bikeStatusDto;
            
            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(pathUrl);
				bikeStatusDto = JsonConvert.DeserializeObject<BikeStatusDTO>(responseString);
            }
			return bikeStatusDto.BikeData.Bikes;
        }
    }
}
