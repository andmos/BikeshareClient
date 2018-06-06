using System.Net.Http;
using BikeshareClient.models;
using Xunit;

using BikeshareClient.Providers;

namespace TestBikeshareClient
{
    public class TestSystemInformationProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/system_information.json")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/system_information.json")]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/system_information.json")]      
		public async void GetSystemInformation_GivenValidSystemInformationUrl_ReturnsSystemInformation(string endpoint)
        {
			var systmInfromationProvder = new SystemInformationProvider();

			var systemInformation = await systmInfromationProvder.GetSystemInformationAsync(endpoint);

			Assert.True(!string.IsNullOrEmpty(systemInformation.Name));
        }
       
    }
}
