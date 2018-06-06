using System;
using System.Collections.Generic;
using System.Linq;
using BikeshareClient.models;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient
{
    public class TestStationStatusProvider
    {
		[Fact]
		public async void GetGetStationsStatusAsync_GivenCorrectBaseUrl_ReturnsStationsStatus()
		{
			var endpoint = @"http://gbfs.urbansharing.com/trondheim/station_status.json";
			var stationsStatus = new List<StationStatus>();

            var provider = new StationStatusProvider();
			var stationResponse = await provider.GetStationsStatusAsync(endpoint);
			stationsStatus = stationResponse.ToList();

			Assert.True(stationsStatus.Count > 1); 
		}
    }
}
