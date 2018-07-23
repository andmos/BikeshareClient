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
			string resourceName = string.Empty;
			switch (default(T))
			{
				case BikeStatusDTO bikeStatus:
					resourceName = "free_bike_status.json";
					break;
				case StationDTO station:
					resourceName = "station_information.json";
					break;
				case StationStatusDTO stationStatus:
					resourceName = "station_status.json";
					break;
				case SystemInformationDTO systemInformation:
					resourceName = "system_information.json";
					break;
				default:
					throw new NotSupportedException($"The type {typeof(T).FullName} is not a supported GBFS resource.");
			}

			return resourceName;
		}

		private async Task<T> GetProivderEndpointDtoAsync<T>(string resource)
        {
			if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException();
            }

			var baseUrl = new Uri(_gbfsBaseUrl).Append(resource).AbsoluteUri;

            T Dto;

            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(baseUrl);
                Dto = JsonConvert.DeserializeObject<T>(responseString);
            }
            return Dto;
        }
    }
}
