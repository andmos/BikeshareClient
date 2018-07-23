using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeshareClient.Models;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient
{
    public class TestBikeStatusProvider
    {
		[Theory]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
		[InlineData(@"http://coast.socialbicycles.com/opendata/")]
		public async Task GetBikeStatusAsync_GivenCorrectBaseUrl_ReturnsBikesStatus(string endpoint)
        {
            var bikeStatus = new List<BikeStatus>();
            var provider = new BikeStatusProvider();
            
			var bikeResponse = await provider.GetBikeStatusAsync(endpoint);
			bikeStatus = bikeResponse.ToList();

			Assert.True(bikeStatus.Any());
        }
    }
}
