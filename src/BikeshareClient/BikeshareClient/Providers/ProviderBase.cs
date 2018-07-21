using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BikeshareClient.Helpers;

namespace BikeshareClient.Providers
{
	public abstract class ProviderBase
    {

		internal async Task<T> GetProivderEndpointDtoAsync<T>(string gbfsBaseUrl, string resource)
        {
			if (string.IsNullOrEmpty(gbfsBaseUrl) || string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException();
            }

			var baseUrl = new Uri(gbfsBaseUrl).Append(resource).AbsoluteUri;

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
