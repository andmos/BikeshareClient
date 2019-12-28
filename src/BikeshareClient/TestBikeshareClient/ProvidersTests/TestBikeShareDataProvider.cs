using System;
using System.Threading.Tasks;
using BikeshareClient.Providers;
using BikeshareClient.DTO;
using Xunit;
using System.Net.Http;
using BikeshareClient.Helpers;

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
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeshareData_GivenBaseUrlAndHttpClient_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            var dataProvider = new BikeShareDataProvider(endpoint, httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeshareData_GivenInvalidBaseUrlAndHttpClientWithValidBaseUrl_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endpoint);
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com", httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeshareData_GivenEmptyBaseUrlAndHttpClientWithValidBaseUrl_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endpoint);
            var dataProvider = new BikeShareDataProvider("", httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Fact]
        public void GetBikeShareData_GivenEmptyBaseUrl_ThrowsArgumentNullExpection()
        {
            Assert.Throws<ArgumentNullException>(() => new BikeShareDataProvider(""));
        }

        [Fact]
        public void GetBikeShareData_GivenEmptyBaseUrlAndHTTPClientWithEmptyBaseUrl_ThrowsArgumentNullExpection()
        {
            Assert.Throws<ArgumentNullException>(() => new BikeShareDataProvider("", new HttpClient()));
        }

        [Fact]
        public async Task GetBikeShareData_GivenIllegalType_ThrowsNotSupportedException()
        {
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

            await Assert.ThrowsAsync<NotSupportedException>(async () => await dataProvider.GetBikeShareData<Int32>());
        }

		[Fact]
		public async Task GetBikeShareData_GivenBaseUrlForProviderWithMissingEndpointImplementation_ThrowsNotImplementetdException()
		{
			var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

			await Assert.ThrowsAsync<NotImplementedException>(async () => await dataProvider.GetBikeShareData<BikeStatusDTO>());
		}

		[Fact]
        public async Task GetBikeShareData_GivenWrongBaseUrl_ThrowsNotImplementetdException()
        {
			var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/");

            await Assert.ThrowsAsync<NotImplementedException>(async () => await dataProvider.GetBikeShareData<BikeStatusDTO>());
        }

        [Fact]
        public async Task GetBikeShareData_GivenBaseUrlWithoutVersionAttribute_ReturnsDefaultVersion()
        {
            var defaultVersion = new SemanticVersion("1.0");
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

            var gbfsDTO = await dataProvider.GetBikeShareData<GbfsDTO>();

            Assert.True(Equals(gbfsDTO.Version, defaultVersion));
        }
    }
}
