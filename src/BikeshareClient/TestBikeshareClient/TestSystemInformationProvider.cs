using System.Net.Http;
using BikeshareClient.models;
using Xunit;

using BikeshareClient.Providers;

namespace TestBikeshareClient
{
    public class TestSystemInformationProvider
    {
        [Fact]
		public async void GetSystemInformation_GivenValidSystemInformationUrl_ReturnsSystemInformation()
        {
			var endpoint = @"http://gbfs.urbansharing.com/trondheim/system_information.json";
			var systmInfromationProvder = new SystemInformationProvider();

			var systemInformation = await systmInfromationProvder.GetSystemInformationAsync(endpoint);

			Assert.Equal("trondheim", systemInformation.Id);
        }
       
    }
}
