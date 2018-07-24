using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeshareClient.Models;
using BikeshareClient.DTO;
using BikeshareClient.Providers;

namespace BikeshareClient
{
	public class Client : IBikeshareClient
    {
		private readonly string _gbfsBaseUrl;
		private readonly BikeShareDataProvider _bikeShareDataProvider; 
        
		public Client(string gbfsBaseUrl)
        {
			_gbfsBaseUrl = gbfsBaseUrl;
			_bikeShareDataProvider = new BikeShareDataProvider(_gbfsBaseUrl);
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

    }
}
