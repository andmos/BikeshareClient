using System.Collections.Generic;
using System.Linq;
using BikeshareClient.models;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient
{
    public class TestStationStatusProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/station_status.json")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/station_status.json")]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/station_status.json")]
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
