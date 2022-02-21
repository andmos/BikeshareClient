using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.Models;
using BikeshareClient.DTO;
using BikeshareClient.Providers;
using System.Linq;
using System.Net.Http;

namespace BikeshareClient
{
    public class Client : IBikeshareClient
    {
        private readonly BikeShareDataProvider _bikeShareDataProvider; 
        
        public Client(string gbfsBaseUrl, HttpClient httpClient = null)
        {
            _bikeShareDataProvider = new BikeShareDataProvider(gbfsBaseUrl, httpClient);
        }

        public async Task<IEnumerable<Feed>> GetAvailableFeedsAsync()
        {
            var gbfsDiscovery = await _bikeShareDataProvider.GetBikeShareData<GbfsDTO>();
            return gbfsDiscovery.FeedsData.SelectMany(l => l.Language.Feeds);
        }
        
        public async Task<IEnumerable<Language>> GetAvailableLanguagesAsync()
        {
            var gbfsDiscovery = await _bikeShareDataProvider.GetBikeShareData<GbfsDTO>();
            return gbfsDiscovery.FeedsData.Select(l => l.Language);
        }
        
        public async Task<SystemInformation> GetSystemInformationAsync()
        {
            var systemInformation = await _bikeShareDataProvider.GetBikeShareData<SystemInformationDTO>();
            return systemInformation.SystemInformation;
        }

        public async Task<IEnumerable<Station>> GetStationsAsync()
        {
            var stations = await _bikeShareDataProvider.GetBikeShareData<StationDTO>();
            return stations.StationsData.Stations;
        }

        public async Task<IEnumerable<StationStatus>> GetStationsStatusAsync()
        {
            var stationStatus = await _bikeShareDataProvider.GetBikeShareData<StationStatusDTO>();
            return stationStatus.StationsStatusData.StationsStatus;
        }

        public async Task<IEnumerable<BikeStatus>> GetBikeStatusAsync()
        {
            var bikeStatus = await _bikeShareDataProvider.GetBikeShareData<BikeStatusDTO>();
            return bikeStatus.BikeStatusData.Bikes;
        }

        public async Task<IEnumerable<VehicleTypes>> GetVehicleTypesAsync()
        {
            var vehicleTypes = await _bikeShareDataProvider.GetBikeShareData<VehicleTypesDTO>();
            return vehicleTypes.VehiclesTypesData.VehicleTypes;
        }
    }
}
