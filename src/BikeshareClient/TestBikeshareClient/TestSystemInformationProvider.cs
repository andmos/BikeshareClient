using System.Net.Http;
using BikeshareClient.Models;
using Xunit;

using BikeshareClient.Providers;
using System.Threading.Tasks;

namespace TestBikeshareClient
{
    public class TestSystemInformationProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		[InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/")]
		[InlineData(@"http://hamilton.socialbicycles.com/opendata/")]      
		public async Task GetSystemInformation_GivenValidSystemInformationUrl_ReturnsSystemInformation(string endpoint)
        {
			var systmInfromationProvder = new SystemInformationProvider();

			var systemInformation = await systmInfromationProvder.GetSystemInformationAsync(endpoint);

			Assert.False(string.IsNullOrEmpty(systemInformation.Name));
        }
       
    }
}
