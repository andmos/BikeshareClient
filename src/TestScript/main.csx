#! "netcoreapp2.0"

#r "nuget: BikeshareClient, 3.0.1"

using BikeshareClient;
using BikeshareClient.Providers;
using BikeshareClient.Models;
using System.Linq; 
using System.Threading.Tasks;

await ParseArguments();

private async Task ParseArguments()
{
    Client client = new Client("http://gbfs.urbansharing.com/trondheim/gbfs.json");
    IEnumerable<Station> stations = await GetStations(client);
    if (Args.Any())
    {
        if (Args[0] != "dryrun")
        {
            string stationName = "";
            foreach (var arg in Args)
            {
                if (stations.Any(s => s.Name.Equals(arg)))
                {
                    stationName = arg;
                }
            }
            var availableBikes = await GetAvailableBikes(GetStationId(stationName, stations),client);
            var availableDocks = await GetAvailableDocks(GetStationId(stationName, stations),client);

            Console.WriteLine($"Available bikes at {stationName}: {availableBikes}");
            Console.WriteLine($"Available docks at {stationName}: {availableDocks}");
        }
        return;
    }
    else
    {
        Console.WriteLine("Stations:");
        foreach(var station in stations.Where(s => s.Capacity > 0).Select(s => s.Name))
        {
            Console.WriteLine($"{station}");
        }
    }
}

private async Task<IEnumerable<Station>> GetStations(Client client)
{
    var stations = await client.GetStationsAsync();

    return stations;
}

private string GetStationId(string stationName, IEnumerable<Station> stations)
{
    return stations.SingleOrDefault(s => s.Name.Equals(stationName)).Id; 
}

private async Task<int> GetAvailableBikes(string stationId, Client client)
{
    var stations = await client.GetStationsStatusAsync();

    var station = stations.FirstOrDefault(s => s.Id.Equals(stationId));
    if(station.Renting)
    {
        return station.BikesAvailable;
    }
    return 0;    
}

private async Task<int> GetAvailableDocks(string stationId, Client client)
{
    var stations = await client.GetStationsStatusAsync();

    var station = stations.FirstOrDefault(s => s.Id.Equals(stationId));
    if(station.Returning)
    {
        return station.DocksAvailable;
    }
    return 0; 
}

