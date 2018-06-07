BikeShareClient
===

Dotnet client for [GBFS](https://github.com/NABSA/gbfs).
Mainly used against [Trondheim Bysykkel](https://trondheimbysykkel.no/open-data).

Simple build:
```
$ docker run --rm -it -v $(pwd):/app microsoft/dotnet:2.0-sdk dotnet pack app/src/BikeshareClient -o /app
```
