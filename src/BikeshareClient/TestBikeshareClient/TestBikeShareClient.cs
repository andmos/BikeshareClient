﻿using Xunit;
using BikeshareClient;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using BikeshareClient.Models;

namespace TestBikeshareClient
{
    public class TestBikeShareClient
    {
        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
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
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsAsync_GivenValidBaseUrlAndHttpClient_ReturnsStations(string baseUrl)
        {
            var httpClient = new HttpClient();
            var client = new Client(baseUrl, httpClient);

            var clientResponse = await client.GetStationsAsync();
            var stations = clientResponse.ToList();

            Assert.True(stations.Any());
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsAsync_GivenEmptyBaseUrlAndHttpClientWithValidBaseUrl_ReturnsStations(string baseUrl)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
            var client = new Client("", httpClient);

            var clientResponse = await client.GetStationsAsync();
            var stations = clientResponse.ToList();

            Assert.True(stations.Any());
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsAsync_GivenValidBaseUrl_ReturnsStationsWithAddress(string baseUrl)
        {
            var client = new Client(baseUrl);

            var clientResponse = await client.GetStationsAsync();
            var stations = clientResponse.ToList();

            Assert.All(stations, s => Assert.NotNull(s.Address));
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsAsync_GivenValidBaseUrl_ReturnsStationsWithId(string baseUrl)
        {
            var client = new Client(baseUrl);

            var clientResponse = await client.GetStationsAsync();
            var stations = clientResponse.ToList();

            Assert.All(stations, s => Assert.NotNull(s.Id));
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]
        public async Task GetStationsAsync_GivenValidBaseUrl_ReturnsStationWithValidPropertyValues(string baseUrl)
        {
            var client = new Client(baseUrl);

            var clientResponse = await client.GetStationsAsync();
            var firstStation = clientResponse.FirstOrDefault();

            Assert.NotEmpty(firstStation.Id);
            Assert.NotEmpty(firstStation.Address);
            Assert.NotEmpty(firstStation.Name);
            Assert.True(firstStation.Capacity >= 0);
            Assert.True(firstStation.Latitude >= 0);
            Assert.True(firstStation.Longitude >= 0);
        }

        [Theory]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/station_information.json")]
        public async Task GetStationsAsync_GivenNotImplementedCapacityProperty_ReturnsZero(string baseUrl)
        {
            var client = new Client(baseUrl);

            var clientResponse = await client.GetStationsAsync();
            var firstStation = clientResponse.FirstOrDefault();

            Assert.Equal(0, firstStation.Capacity);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetSystemInformationAsync_GivenValidBaseUrl_ReturnsInformation(string baseUrl)
        {
            var client = new Client(baseUrl);

            var clientResponse = await client.GetSystemInformationAsync();

            Assert.NotEmpty(clientResponse.Id);
            Assert.NotEmpty(clientResponse.Name);
            Assert.NotEmpty(clientResponse.Language);
            Assert.NotEmpty(clientResponse.Email);
            Assert.NotEmpty(clientResponse.TimeZone);
            Assert.NotEmpty(clientResponse.PhoneNumber);
        }


        [Theory]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_mr/gbfs.json")]
        [InlineData(@"https://hamilton.socialbicycles.com/opendata/gbfs.json")]

        public async Task GetBikeStatusAsync_GivenCorrectBaseUrl_ReturnsBikesStatus(string endpoint)
        {
            var client = new Client(endpoint);

            var clientRespons = await client.GetBikeStatusAsync();

            Assert.True(clientRespons.Any());
        }

        [Theory]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_mr/gbfs.json")]
        [InlineData(@"https://hamilton.socialbicycles.com/opendata/gbfs.json")]

        public async Task GetBikeStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsBikesStatus(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetBikeStatusAsync();

            Assert.True(clientResponse.Any());
        }

        [Theory]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_mr/gbfs.json")]
        [InlineData(@"https://hamilton.socialbicycles.com/opendata/gbfs.json")]
        public async Task GetBikeStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsValidPropertyValues(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetBikeStatusAsync();
            var firstBikeStatus = clientResponse.FirstOrDefault();

            Assert.IsType<bool>(firstBikeStatus.Disabled);
            Assert.IsType<bool>(firstBikeStatus.Reserved);
            Assert.NotEmpty(firstBikeStatus.Id);
            Assert.NotEmpty(firstBikeStatus.Name);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_madison/")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrl_ReturnsStationsStatus(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetStationsStatusAsync();

            Assert.True(clientResponse.Any());
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/gbfs.json")]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_madison/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/gbfs.json")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsStationsStatus(string endpoint)
        {
            var client = new Client(endpoint);

            var clientRespons = await client.GetStationsStatusAsync();

            Assert.True(clientRespons.Any());
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/gbfs.json")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_HasReturningStations(string endpoint)
        {
            var client = new Client(endpoint);

            var clientRespons = await client.GetStationsStatusAsync();

            Assert.Contains(clientRespons, s => s.Returning);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"http://gbfs.urbansharing.com/bergen-city-bike/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/gbfs.json")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_HasRentingStations(string endpoint)
        {
            var client = new Client(endpoint);

            var clientRespons = await client.GetStationsStatusAsync();

            Assert.Contains(clientRespons, s => s.Returning);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]

        public async Task GetStationsStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsLastReported(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetStationsStatusAsync();

            Assert.NotEqual(default(DateTime), clientResponse.FirstOrDefault().LastReported);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        public async Task GetStationsStatusAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsValidPropertyValues(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetStationsStatusAsync();
            var firstStationStatus = clientResponse.FirstOrDefault();

            Assert.NotEqual(default(DateTime), firstStationStatus.LastReported);
            Assert.NotEmpty(firstStationStatus.Id);
            Assert.True(firstStationStatus.Installed);
            Assert.IsType<int>(firstStationStatus.BikesAvailable);
            Assert.IsType<bool>(firstStationStatus.Renting);
            Assert.IsType<int>(firstStationStatus.BikesDisabled);
            Assert.IsType<bool>(firstStationStatus.Returning);
            Assert.IsType<int>(firstStationStatus.DocksAvailable);
        }


        [Theory]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/gbfs.json")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_si/gbfs.json")]
        public async Task GetAvailableFeedsAsync_GivenBaseUrlWithGbfsJson_ReturnsListOfAvailableFeeds(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetAvailableFeedsAsync();

            Assert.True(clientResponse.Any());
        }

        [Theory]
        [InlineData(@"https://gbfs.bcycle.com/bcycle_aventura/gbfs.json")]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/gbfs.json")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]
        public async Task GetAvailableLanguagesAsync_GivenBaseUrlWithGbfsJson_ReturnsListOfAvailableLanguages(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetAvailableLanguagesAsync();

            Assert.NotEmpty(clientResponse);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        public async Task GetAvailableLanguagesAsync_GivenBaseUrlWithGbfsJson_ReturnsExpectedLanguage(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetAvailableLanguagesAsync();

            Assert.Equal("nb", clientResponse.First().Name);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        [InlineData(@"https://gbfs.urbansharing.com/oslobysykkel.no/gbfs.json")]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_si/gbfs.json")]
        public async Task GetAvailableLanguagesAsync_GivenBaseUrlWithGbfsJson_ReturnsExpectedFeed(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetAvailableLanguagesAsync();

            Assert.Contains(clientResponse, f => f.Feeds.Any(n => n.Name.Equals("system_information")));
        }

        [Theory]
        [InlineData(@"http://hamilton.socialbicycles.com/opendata/")]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v1/nextbike_si/")]
        public async Task GetAvailableLanguagesAsync_GivenBaseUrlWithoutGbfsJson_ReturnsListOfAvailableLanguages(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetAvailableLanguagesAsync();

            Assert.NotEmpty(clientResponse);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        [InlineData(@"https://gbfs.nextbike.net/maps/gbfs/v2/nextbike_al/gbfs.json")]
        public async Task GetVehicleTypesAsync_GivenBaseUrlWithGbfsJsonAndAvialableVehicleInformation_ReturnsListOfVehicles(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetVehicleTypesAsync();

            Assert.NotEmpty(clientResponse);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        public async Task GetVehicleTypesAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsValidPropertyValues(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetVehicleTypesAsync();
            var firstVehicleType = clientResponse.FirstOrDefault();

            Assert.NotEmpty(firstVehicleType.Id);
            Assert.IsType<long>(firstVehicleType.MaxRangeMeters);
            Assert.IsType<VehicleFormFactor>(firstVehicleType.VehicleFormFactor);
            Assert.IsType<PropulsionType>(firstVehicleType.PropulsionType);
            Assert.IsType<string>(firstVehicleType.Name);
        }

        [Theory]
        [InlineData(@"http://gbfs.urbansharing.com/trondheim/gbfs.json")]
        public async Task GetVehicleTypesAsync_GivenCorrectBaseUrlWithGbfsDiscoveryFile_ReturnsCorrectHasMaxRangeValue(string endpoint)
        {
            var client = new Client(endpoint);

            var clientResponse = await client.GetVehicleTypesAsync();
            var firstVehicleType = clientResponse.FirstOrDefault();

            if (firstVehicleType.PropulsionType == PropulsionType.Human)
            {
                Assert.False(firstVehicleType.HasMaxRange);
            }
            else
            {
                Assert.True(firstVehicleType.HasMaxRange);
            }
        }
    }
}
