using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BikeshareClient.Providers
{
	public abstract class ProviderBase
    {
		internal async Task<T> GetProivderEndpointDtoAsync<T>(string pathUrl)
        {
            if (string.IsNullOrEmpty(pathUrl))
            {
                throw new ArgumentNullException();
            }

            T Dto;
          
            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(pathUrl);
				Dto = JsonConvert.DeserializeObject<T>(responseString);
            }
			return Dto;
        }
    }
}
