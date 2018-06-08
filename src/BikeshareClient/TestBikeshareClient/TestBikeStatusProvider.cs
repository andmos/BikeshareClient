using System;
using System.Collections.Generic;
using System.Linq;
using BikeshareClient.models;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient
{
    public class TestBikeStatusProvider
    {
		[Theory]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/free_bike_status.json")]
		public async void GetBikeStatusAsync_GivenCorrectBaseUrl_ReturnsBikesStatus(string endpoint)
        {
            var bikeStatus = new List<BikeStatus>();
            var provider = new BikeStatusProvider();
            
			var bikeResponse = await provider.GetBikeStatusAsync(endpoint);
			bikeStatus = bikeResponse.ToList();

			Assert.True(bikeStatus.Count > 1);
        }
    }
}
