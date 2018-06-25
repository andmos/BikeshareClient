BikeShareClient
===

Dotnet client for [GBFS](https://github.com/NABSA/gbfs).
Mainly used against [Trondheim Bysykkel](https://trondheimbysykkel.no/open-data).
Supports the required fields for now. 

A simple [dotnet-script](https://github.com/filipw/dotnet-script) test script can be seen [here](src/TestScript/Main.csx). 

Simple build:
```
$ docker run --rm -it -v $(pwd):/app microsoft/dotnet:2.0-sdk dotnet pack app/src/BikeshareClient -o /app
```

[![Build Status](https://travis-ci.org/andmos/BikeshareClient.svg?branch=master)](https://travis-ci.org/andmos/BikeshareClient)
