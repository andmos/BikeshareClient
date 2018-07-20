#! "netcoreapp2.0"

#r "nuget: BikeshareClient, 1.0.0"

using BikeshareClient.Providers;
using BikeshareClient.Models;
using System.Linq; 

await ParseArguments();

private async Task ParseArguments()
{
    IEnumerable<Station> stations = await GetStations();
    if (Args.Any())
    {
        string stationName = "";
        foreach (var arg in Args)
        {
            if (stations.Any(s => s.Name.Equals(arg)))
            {
                stationName = arg;
            }
        }
        var availableBikes = await GetAvailableBikes(GetStationId(stationName, stations));
        var availableDocks = await GetAvailableDocks(GetStationId(stationName, stations));

        Console.WriteLine($"Available bikes at {stationName}: {availableBikes}");
        Console.WriteLine($"Available docks at {stationName}: {availableDocks}");
    }
    else
    {
        Console.WriteLine("Stations:");
        foreach(var station in stations.Select(s => s.Name))
        {
            Console.WriteLine($"{station}");
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

