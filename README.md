BikeShareClient
===

Dotnet client for [GBFS](https://github.com/NABSA/gbfs).
Mainly used against [Urban Infrastructure Partner](https://urbansharing.com/), with [Trondheim City Bike](https://trondheimbysykkel.no/en/open-data) and [Bergen City Bike](https://bergenbysykkel.no/en/apne-data). 
Supports the required fields in GBFS for now. 

A simple [dotnet-script](https://github.com/filipw/dotnet-script) test script can be seen [here](https://github.com/andmos/BikeshareClient/blob/master/src/TestScript/main.csx). 

Simple build:
```
$ docker run --rm -it -v $(pwd):/app microsoft/dotnet:2.1-sdk dotnet pack app/src/BikeshareClient -o /app
```

[![Build Status](https://travis-ci.org/andmos/BikeshareClient.svg?branch=master)](https://travis-ci.org/andmos/BikeshareClient)

[![NuGet](https://img.shields.io/nuget/v/BikeshareClient.svg)](https://www.nuget.org/packages/BikeshareClient/)
