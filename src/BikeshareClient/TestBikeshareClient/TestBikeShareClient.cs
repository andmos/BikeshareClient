using System;
using Xunit;
using BikeshareClient;
using System.Linq;
using BikeshareClient.Models;
namespace TestBikeshareClient
{
    public class TestBikeShareClient
    {
		[Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")] 
		public async void GetStationsAsync_GivenValidBaseUrl_ReturnsStations(string baseUrl)
		{
			var client = new Client(baseUrl);

			var clientResponse = await client.GetStationsAsync();
			var stations = clientResponse.ToList();

			Assert.True(stations.Any<Station>()); 
		}

		[Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")] 
		public async void GetSystemInformationAsync_GivenValidBaseUrl_ReturnsInformation(string baseUrl)
		{
			var client = new Client(baseUrl);

			var clientResponse = await client.GetSystemInformationAsync();

			Assert.False(string.IsNullOrEmpty(clientResponse.Id));
			Assert.False(string.IsNullOrEmpty(clientResponse.Name));
		}
    }
}
