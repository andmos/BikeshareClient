using System.Collections.Generic;
using BikeshareClient.models;
using BikeshareClient.Providers;
using Xunit;
using System.Linq; 
namespace TestBikeshareClient
{
    public class TestStationProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/station_information.json")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/station_information.json")]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/station_information.json")]      
		public async void GetStationsAsync_GivenValidUrl_ReturnsListOfStations(string endpoint)
		{
			var stations = new List<Station>();
			var provider = new StationProvider();

			var stationResponse = await provider.GetStationsAsync(endpoint);
			stations = stationResponse.ToList();

			Assert.True(stations.Count > 1); 
		}
    }
}
