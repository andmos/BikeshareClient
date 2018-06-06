using System;
using System.Collections.Generic;
using BikeshareClient.models;
using BikeshareClient.Providers;
using Xunit;
using System.Linq; 
namespace TestBikeshareClient

{
    public class TestStationProvider
    {
		[Fact]
		public async void GetStationsAsync_GivenValidUrl_ReturnsListOfStations()
		{
			var endpoint = @"http://gbfs.urbansharing.com/trondheim/station_information.json";
			var stations = new List<Station>();

			var provider = new StationProvider();
			var stationResponse = await provider.GetStationsAsync(endpoint);
			stations = stationResponse.ToList();

			Assert.True(stations.Count > 1); 
		}
    }
}
