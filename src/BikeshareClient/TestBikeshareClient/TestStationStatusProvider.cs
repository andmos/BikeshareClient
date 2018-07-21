using System.Collections.Generic;
using System.Linq;
using BikeshareClient.Models;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient
{
    public class TestStationStatusProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
		public async void GetGetStationsStatusAsync_GivenCorrectBaseUrl_ReturnsStationsStatus(string endpoint)
		{
			var stationsStatus = new List<StationStatus>();
            var provider = new StationStatusProvider();
		
			var stationResponse = await provider.GetStationsStatusAsync(endpoint);
			stationsStatus = stationResponse.ToList();

			Assert.True(stationsStatus.Count > 1); 
		}
    }
}
