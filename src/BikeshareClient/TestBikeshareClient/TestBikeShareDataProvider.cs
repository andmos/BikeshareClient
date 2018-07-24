using System;
using System.Threading.Tasks;
using BikeshareClient.Providers;
using BikeshareClient.DTO;
using Xunit;
namespace TestBikeshareClient
{
    public class TestBikeShareDataProvider
    {
		[Theory]
		[InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
		public async Task GetBikeShareData_GivenCorrectBaseUrlAndType_ReturnsCorrectType(string endpoint)
		{
			var dataProvider = new BikeShareDataProvider(endpoint);

			var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

			Assert.True(stationDto.TimeToLive != 0);
		}

		[Fact]
		public void GetBikeShareData_GivenEmptyBaseUrl_ThrowsArgumentNullExpection()
		{
			Assert.Throws<ArgumentNullException>(() => new BikeShareDataProvider(""));
		}

		[Fact]
		public async Task GetBikeShareData_GivenIllegalType_ThrowsNotSupportedException()
        {
			var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

			await Assert.ThrowsAsync<NotSupportedException>(async () => await dataProvider.GetBikeShareData<Int32>());
        }
    }
}
