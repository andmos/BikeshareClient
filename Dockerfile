FROM microsoft/dotnet:2.0-sdk as builder

ARG VERSION_SUFFIX

WORKDIR /app 

COPY src/BikeshareClient .
RUN dotnet restore

RUN dotnet test TestBikeshareClient/TestBikeshareClient.csproj

RUN dotnet pack -c Release -o output $VERSION_SUFFIX
