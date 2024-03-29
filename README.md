BikeshareClient
===

Dotnet client for the General Bikeshare Feed Specification ([GBFS](https://github.com/NABSA/gbfs)).
Mainly used against [Urban Infrastructure Partner](https://urbansharing.com/), with [Trondheim City Bike](https://trondheimbysykkel.no/en/open-data) and [Bergen City Bike](https://bergenbysykkel.no/en/apne-data).

For all available GBFS systems, [see the system overview from the GBFS project](https://github.com/NABSA/gbfs/blob/master/systems.csv).

Supports the required fields in the GBFS standard for now.

## Basic Usage

```csharp

// Create the client from a GBFS API URL.
IBikeshareClient client = new Client("http://gbfs.urbansharing.com/trondheim/gbfs.json");

// Or with an existing HTTPClient
IBikeshareClient client = new Client("http://gbfs.urbansharing.com/trondheim/gbfs.json", httpClient);

// All available stations, containing name, id, lat, long, address and capacity
var stations = await client.GetStationsAsync();

// All stations status, containing number of bikes and docks available, is renting, is returning etc.
var statuses = await client.GetStationsStatusAsync();

```

A simple [dotnet-script](https://github.com/filipw/dotnet-script) test script for the client can be seen [here](https://github.com/andmos/BikeshareClient/blob/master/src/TestScript/main.csx).

## Microsoft.Extensions.DependencyInjection integration

`BikeshareClient` can be registered to `IServiceCollection` by referencing the `BikeshareClient.DependencyInjection` [NuGet package](https://www.nuget.org/packages/BikeshareClient.DependencyInjection/):

```csharp
using BikeshareClient.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

services.AddBikeshareClient("http://gbfs.urbansharing.com/trondheim/gbfs.json");
```

## Build and testscript

Simple build:

```bash
docker run --rm -it -v $(pwd):/app mcr.microsoft.com/dotnet/sdk:7.0 dotnet pack app/src/BikeshareClient -o /app
```

Run test script:

```bash
docker run --rm -it -v $(pwd)/src/TestScript/:/scripts  andmos/dotnet-script main.csx "Skansen"
```

[![CI / CD](https://github.com/andmos/BikeshareClient/actions/workflows/ci.yaml/badge.svg?branch=master)](https://github.com/andmos/BikeshareClient/actions/workflows/ci.yaml)

[![codecov](https://codecov.io/gh/andmos/BikeshareClient/branch/master/graph/badge.svg)](https://codecov.io/gh/andmos/BikeshareClient)

[![NuGet BikeshareClient](https://img.shields.io/nuget/v/BikeshareClient.svg)](https://www.nuget.org/packages/BikeshareClient/)

[![NuGet BikeshareClient.DependencyInjection](https://img.shields.io/nuget/v/BikeshareClient.DependencyInjection.svg)](https://www.nuget.org/packages/BikeshareClient.DependencyInjection/)

[![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=andmos/BikeshareClient)](https://dependabot.com)

>[GBFS](https://github.com/NABSA/gbfs) is a standard backed by the North American Bike Share Association ([NABSA](https://nabsa.net/)).
