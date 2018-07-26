using System;
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

		private static string FindResourceType<T>()
		{
			switch (default(T))
			{
				case BikeStatusDTO bikeStatus:
					return "free_bike_status.json";
				case StationDTO station:
					return "station_information.json";
				case StationStatusDTO stationStatus:
					return "station_status.json";
				case SystemInformationDTO systemInformation:
					return "system_information.json";
				default:
					throw new NotSupportedException($"The type {typeof(T).FullName} is not a supported GBFS resource.");
			}
		}

		private async Task<T> GetProivderEndpointDtoAsync<T>(string resource)
        {
			if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException();
            }

			var baseUrl = new Uri(_gbfsBaseUrl).Append(resource).AbsoluteUri;
         
            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(baseUrl);
				return JsonConvert.DeserializeObject<T>(responseString);
            }
        }
    }
}
