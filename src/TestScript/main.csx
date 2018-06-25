#! "netcoreapp2.0"

#r "nuget: BikeshareClient, 1.0.0"

using BikeshareClient.Providers;
using System.Linq; 

private string StationName => "Skansen";

var availableBikes = await GetAvailableBikes(await GetStationId(StationName));
var availableDocks = await GetAvailableDocks(await GetStationId(StationName));

Console.WriteLine($"Available bikes at {StationName}: {availableBikes}");
Console.WriteLine($"Available docks at {StationName}: {availableDocks}");

private async Task<string> GetStationId(string stationName)
{
    var stationProvider = new StationProvider();
    var stations = await stationProvider.GetStationsAsync("http://gbfs.urbansharing.com/trondheim/station_information.json");

    return stations.SingleOrDefault(s => s.Name.Equals(stationName)).Id; 
}

private async Task<int> GetAvailableBikes(string stationId)
{
    var stationStatusProvider = new StationStatusProvider();
    var stations = await stationStatusProvider.GetStationsStatusAsync("http://gbfs.urbansharing.com/trondheim/station_status.json");

    var availableBikes = stations.FirstOrDefault(s => s.Id.Equals(stationId)).BikesAvailable;

    return availableBikes; 
}

private async Task<int> GetAvailableDocks(string stationId)
{
    var stationStatusProvider = new StationStatusProvider();
    var stations = await stationStatusProvider.GetStationsStatusAsync("http://gbfs.urbansharing.com/trondheim/station_status.json");

    var availableDocks = stations.FirstOrDefault(s => s.Id.Equals(stationId)).DocksAvailable;

    return availableDocks; 
}