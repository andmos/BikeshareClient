using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.Models;
using BikeshareClient.Providers;
namespace BikeshareClient
{
    public class Client
    {
		private readonly string _gbfsBaseUrl;
		private readonly Lazy<StationProvider> _stationProvider;
		private readonly Lazy<BikeStatusProvider> _bikeStatusProvider;
		private readonly Lazy<StationStatusProvider> _stationStatusProvider;
		private readonly Lazy<SystemInformationProvider> _systemInformationProvider; 
        
		public Client(string gbfsBaseUrl)
        {
			_gbfsBaseUrl = gbfsBaseUrl;
			_stationProvider = new Lazy<StationProvider>();
			_bikeStatusProvider = new Lazy<BikeStatusProvider>();
			_stationStatusProvider = new Lazy<StationStatusProvider>();
			_systemInformationProvider = new Lazy<SystemInformationProvider>(); 
		}
        
		public async Task<SystemInformation> GetSystemInformationAsync()
		{
			return await _systemInformationProvider.Value.GetSystemInformationAsync(_gbfsBaseUrl);
		}

		public async Task<IEnumerable<Station>> GetStationsAsync()
		{
			return await _stationProvider.Value.GetStationsAsync(_gbfsBaseUrl);
		}

		public async Task<IEnumerable<StationStatus>> GetStationsStatusAsync()
		{
			return await _stationStatusProvider.Value.GetStationsStatusAsync(_gbfsBaseUrl);
		}

		public async Task<IEnumerable<BikeStatus>> GetBikeStatusAsync()
		{
			return await _bikeStatusProvider.Value.GetBikeStatusAsync(_gbfsBaseUrl);
		}
    }
}
