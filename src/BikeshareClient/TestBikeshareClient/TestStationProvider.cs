using System.Collections.Generic;
using BikeshareClient.Models;
using BikeshareClient.Providers;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace TestBikeshareClient
{
    public class TestStationProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
	 	[InlineData(@"http://hamilton.socialbicycles.com/opendata/")]      
		public async Task GetStationsAsync_GivenValidUrl_ReturnsListOfStations(string endpoint)
		{
			var stations = new List<Station>();
			var provider = new StationProvider();

			var stationResponse = await provider.GetStationsAsync(endpoint);
			stations = stationResponse.ToList();

			Assert.True(stations.Any()); 
		}
    }
}
