using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Helpers;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
    public class BikeShareDataProvider
    {
		private readonly string _gbfsBaseUrl;

		public BikeShareDataProvider(string gbfsBaseUrl)
        {
			if (string.IsNullOrEmpty(gbfsBaseUrl))
            {
                throw new ArgumentNullException();
            }
			_gbfsBaseUrl = gbfsBaseUrl;
        }

		public async Task<T> GetBikeShareData<T>()
		{
			return await GetProivderEndpointDtoAsync<T>(FindResourceType<T>());

		}

		private static KeyValuePair<string,string> FindResourceType<T>()
		{
			switch (default(T))
			{
				case BikeStatusDTO bikeStatus:
					return new KeyValuePair<string, string>("free_bike_status.json","Bikes");
				case StationDTO station:
					return new KeyValuePair<string, string>("station_information.json","Stations");
				case StationStatusDTO stationStatus:
					return new KeyValuePair<string, string>("station_status.json","Station status");
				case SystemInformationDTO systemInformation:
					return new KeyValuePair<string, string>("system_information.json","GBFS System information");
				default:
					throw new NotSupportedException($"The type {typeof(T).FullName} is not a supported GBFS resource.");
			}
		}

		private async Task<T> GetProivderEndpointDtoAsync<T>(KeyValuePair<string,string> resource)
        {
			if (string.IsNullOrEmpty(resource.Key))
            {
                throw new ArgumentNullException();
            }

			var baseUrl = new Uri(_gbfsBaseUrl).Append(resource.Key).AbsoluteUri;
         
            using (var client = new HttpClient())
            {
				var response = await client.GetAsync(baseUrl);
				if(!response.IsSuccessStatusCode)
				{
					throw new NotImplementedException($"Could not find any {resource.Value}, {baseUrl} returned status code {response.StatusCode}");
				}
				return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
