using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Helpers;
using BikeshareClient.models;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
    public class StationProvider
    {
		public async Task<IEnumerable<Station>> GetStationsAsync(string pathUrl)
		{
			if (string.IsNullOrEmpty(pathUrl))
            {
                throw new ArgumentNullException();
            }

			StationDTO stationDto; 

			using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(pathUrl);
				stationDto = JsonConvert.DeserializeObject<StationDTO>(responseString);
            }
			return stationDto.StationsData.Stations; 
		}
    }
}
