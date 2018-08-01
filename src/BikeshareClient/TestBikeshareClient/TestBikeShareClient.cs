using Xunit;
using BikeshareClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestBikeshareClient
{
    public class TestBikeShareClient
    {
		[Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")] 
		public async Task GetStationsAsync_GivenValidBaseUrl_ReturnsStations(string baseUrl)
		{
			var client = new Client(baseUrl);

			var clientResponse = await client.GetStationsAsync();
			var stations = clientResponse.ToList();

			Assert.True(stations.Any()); 
		}

		[Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")] 
		public async Task GetSystemInformationAsync_GivenValidBaseUrl_ReturnsInformation(string baseUrl)
		{
			var client = new Client(baseUrl);

			var clientResponse = await client.GetSystemInformationAsync();

			Assert.False(string.IsNullOrEmpty(clientResponse.Id));
			Assert.False(string.IsNullOrEmpty(clientResponse.Name));
		}

		[Theory]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        [InlineData(@"http://coast.socialbicycles.com/opendata/")]
        public async Task GetBikeStatusAsync_GivenCorrectBaseUrl_ReturnsBikesStatus(string endpoint)
        {
			var client = new Client(endpoint);

			var clientRespons = await client.GetBikeStatusAsync();

			Assert.True(clientRespons.Any());
        }

		[Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrl_ReturnsStationsStatus(string endpoint)
        {
			var client = new Client(endpoint);

			var clientRespons = await client.GetStationsStatusAsync();

            Assert.True(clientRespons.Any());
        }
              
    }
}
