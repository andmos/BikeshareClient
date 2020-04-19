using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Helpers;
using Newtonsoft.Json;
using System.Linq;

namespace BikeshareClient.Providers
{
    public class BikeShareDataProvider
    {
        private readonly string _gbfsBaseUrl;
        private const string GbfsDiscovery = "gbfs";
        private const string JsonExtension = ".json";
        private const string GbfsDiscoveryFile = GbfsDiscovery + JsonExtension;
        private readonly HttpClient _httpClient;

        public BikeShareDataProvider(string gbfsBaseUrl, HttpClient httpClient = null)
        {
            if (string.IsNullOrEmpty(gbfsBaseUrl) && httpClient?.BaseAddress == null)
            {
                throw new ArgumentNullException($"{nameof(gbfsBaseUrl)} must be set to valid GBFS address, or HttpClient with GBFS BaseAddress set.");
            }

            _gbfsBaseUrl = httpClient?.BaseAddress?.ToString() ?? gbfsBaseUrl;
            
            _httpClient = httpClient ?? new HttpClient();
            
        }

        public async Task<T> GetBikeShareData<T>()
        {
            return await GetProviderDtoAsync<T>(FindResourceType<T>());
        }

        private static KeyValuePair<string, string> FindResourceType<T>()
        {
            switch (default(T))
            {
                case GbfsDTO gbfsDiscovery:
                    return new KeyValuePair<string, string>(GbfsDiscovery, "GBFS Discovery");
                case BikeStatusDTO bikeStatus:
                    return new KeyValuePair<string, string>("free_bike_status", "Bikes");
                case StationDTO station:
                    return new KeyValuePair<string, string>("station_information", "Stations");
                case StationStatusDTO stationStatus:
                    return new KeyValuePair<string, string>("station_status", "Station status");
                case SystemInformationDTO systemInformation:
                    return new KeyValuePair<string, string>("system_information", "GBFS System information");
                default:
                    throw new NotSupportedException($"The type {typeof(T).FullName} is not a supported GBFS resource.");
            }
        }

        private async Task<T> GetProviderDtoAsync<T>(KeyValuePair<string, string> resource)
        {
            if (string.IsNullOrEmpty(resource.Key))
            {
                throw new ArgumentNullException();
            }

            var requestUrl = await CreateGbfsRequestUrl(resource.Key);

            return await GetProviderDtoFromRequest<T>(requestUrl, resource);
        }

        private async Task<string> CreateGbfsRequestUrl(string resource)
        {
            var baseUrl = new Uri(_gbfsBaseUrl).AbsoluteUri;

            if (DuplicateResourceOnBaseUrl(baseUrl, resource))
            {
                baseUrl = new Uri(baseUrl).RemoveLastElement().AbsoluteUri;
            }

            if (BaseUrlIsGbfsDiscoveryFile(baseUrl))
            {
                return await GetResourceUrlFromGbfsDiscoveryFileFeeds(baseUrl, resource);
            }

            resource += JsonExtension;
            return new Uri(baseUrl).Append(resource).AbsoluteUri;
        }

        private bool DuplicateResourceOnBaseUrl(string baseUrl, string resource) =>
            baseUrl.EndsWith(resource + JsonExtension, StringComparison.InvariantCulture);


        private bool BaseUrlIsGbfsDiscoveryFile(string baseUrl) =>
            baseUrl.EndsWith(GbfsDiscoveryFile, StringComparison.InvariantCulture);


        private async Task<string> GetResourceUrlFromGbfsDiscoveryFileFeeds(string baseUrl, string resource)
        {
            var gbfsDiscoveryResponse = await GetProviderDtoFromRequest<GbfsDTO>(baseUrl, FindResourceType<GbfsDTO>());
            return baseUrl = new Uri(
                gbfsDiscoveryResponse.FeedsData.SelectMany(l => l.Language.Feeds.ToList()).FirstOrDefault(f => f.Name.Equals(resource)).Url).AbsoluteUri;
        }

        private async Task<T> GetProviderDtoFromRequest<T>(string baseUrl, KeyValuePair<string, string> resource)
        {
            var response = await _httpClient.GetAsync(baseUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new NotImplementedException($"Could not find any {resource.Value}, {baseUrl} returned status code {response.StatusCode}");
            }
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
