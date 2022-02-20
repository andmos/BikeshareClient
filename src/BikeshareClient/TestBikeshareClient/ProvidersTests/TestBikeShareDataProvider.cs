using System;
using System.Net.Http;
using System.Threading.Tasks;
using BikeshareClient.DTO;
using BikeshareClient.Helpers;
using BikeshareClient.Providers;
using Xunit;

namespace TestBikeshareClient.ProvidersTests
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
        public async Task GetBikeShareData_GivenBaseUrlAndHttpClient_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            var dataProvider = new BikeShareDataProvider(endpoint, httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeShareData_GivenInvalidBaseUrlAndHttpClientWithValidBaseUrl_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(endpoint) };
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com", httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeShareData_GivenEmptyBaseUrlAndHttpClientWithValidBaseUrl_ReturnsValidResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endpoint);
            var dataProvider = new BikeShareDataProvider("", httpClient);

            var stationDto = await dataProvider.GetBikeShareData<StationDTO>();

            Assert.True(stationDto.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, stationDto.LastUpdated);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        public async Task GetBikeShareData_GivenEmptyBaseUrlAndHttpClientWithValidBaseUrl_ReturnsValidVehicleTypeResponse(string endpoint)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(endpoint);
            var dataProvider = new BikeShareDataProvider("", httpClient);

            var vehicleTypesDTO = await dataProvider.GetBikeShareData<VehicleTypesDTO>();

            Assert.True(vehicleTypesDTO.TimeToLive != 0);
            Assert.NotEqual(DateTime.MinValue, vehicleTypesDTO.LastUpdated);
        }

        [Fact]
        public void GetBikeShareData_GivenEmptyBaseUrl_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BikeShareDataProvider(""));
        }

        [Fact]
        public void GetBikeShareData_GivenEmptyBaseUrlAndHTTPClientWithEmptyBaseUrl_ThrowsArgumentNullException()
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
		public async Task GetBikeShareData_GivenBaseUrlForProviderWithMissingEndpointImplementation_ThrowsNotImplementedException()
		{
			var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

			await Assert.ThrowsAsync<NotImplementedException>(async () => await dataProvider.GetBikeShareData<BikeStatusDTO>());
		}

		[Fact]
        public async Task GetBikeShareData_GivenWrongBaseUrl_ThrowsNotImplementedException()
        {
			var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/");

            await Assert.ThrowsAsync<NotImplementedException>(async () => await dataProvider.GetBikeShareData<BikeStatusDTO>());
        }

        [Fact]
        public async Task GetBikeShareData_GivenBaseUrlWithoutVersionAttribute_ReturnsDefaultVersion()
        {
            var defaultVersion = new SemanticVersion("1.0");
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/oslovintersykkel.no/");

            var gbfsDto = await dataProvider.GetBikeShareData<GbfsDTO>();

            Assert.True(Equals(gbfsDto.Version, defaultVersion));
        }

        [Fact]
        public async Task GetBikeShareData_GivenBaseUrlWithVersionAttribute_ReturnsCorrectVersion()
        {
            var excpectedVersion = new SemanticVersion("2.2");
            var dataProvider = new BikeShareDataProvider("http://gbfs.urbansharing.com/trondheim/");

            var gbfsDto = await dataProvider.GetBikeShareData<GbfsDTO>();

            Assert.True(Equals(gbfsDto.Version, excpectedVersion));
        }
    }
}
