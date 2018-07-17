#! "netcoreapp2.0"

#r "nuget: BikeshareClient, 1.0.0"

using BikeshareClient.Providers;
using BikeshareClient.Models;
using System.Linq; 

private string StationName = "Skansen";
private IEnumerable<Station> Stations = await GetStations();

ParseArguments();

var availableBikes = await GetAvailableBikes(GetStationId(StationName, Stations));
var availableDocks = await GetAvailableDocks(GetStationId(StationName, Stations));

Console.WriteLine($"Available bikes at {StationName}: {availableBikes}");
Console.WriteLine($"Available docks at {StationName}: {availableDocks}");


private void ParseArguments()
{
    if (Args.Any())
    {
        foreach (var arg in Args)
        {
            if (Stations.Any(s => s.Name.Equals(arg)))
            {
                StationName = arg;
            }
        }
    }
}

private async Task<IEnumerable<Station>> GetStations()
{
    var stationProvider = new StationProvider();
    var stations = await stationProvider.GetStationsAsync("http://gbfs.urbansharing.com/trondheim/station_information.json");

    return stations;
}

private string GetStationId(string stationName, IEnumerable<Station> stations)
{
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

