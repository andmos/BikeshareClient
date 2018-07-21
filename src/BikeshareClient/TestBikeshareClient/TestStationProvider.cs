using System.Collections.Generic;
using BikeshareClient.Models;
using BikeshareClient.Providers;
using Xunit;
using System.Linq; 
namespace TestBikeshareClient
{
    public class TestStationProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
	 	[InlineData(@"http://hamilton.socialbicycles.com/opendata/")]      
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
