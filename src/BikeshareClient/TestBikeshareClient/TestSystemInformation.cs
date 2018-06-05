using System.Net.Http;
using BikeshareClient.models;
using Xunit;
using BikeshareClient.Helpers;

namespace TestBikeshareClient
{
    public class TestSystemInformation
    {
        [Fact]
		public async void GetStationInformation_GivenSystemName_ReturnsSystemInformation()
        {
			var endpoint = "http://gbfs.urbansharing.com/trondheim/system_information.json";
			string response; 

			using(var client = new HttpClient())
			{
				response = await client.GetStringAsync(endpoint);
			}
            
			SystemInformation myType = JsonHelper.GetFirstInstance<SystemInformation>("data", response);
			Assert.Equal("trondheim", myType.Id);
        }
       
    }
}
