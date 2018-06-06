using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
    public class StationStatusProvider
    {
		public async Task<IEnumerable<StationStatus>> GetStationsStatusAsync(string pathUrl)
        {
            if (string.IsNullOrEmpty(pathUrl))
            {
                throw new ArgumentNullException();
            }

			StationStatusDTO stationStatusDto;

            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(pathUrl);
				stationStatusDto = JsonConvert.DeserializeObject<StationStatusDTO>(responseString);
            }
			return stationStatusDto.StationsStatus.StationsStatus;
        }
    }
}
