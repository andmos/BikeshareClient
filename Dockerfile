FROM mcr.microsoft.com/dotnet/core/sdk:3.0 as builder

ARG VERSION_SUFFIX

WORKDIR /app 

COPY src/BikeshareClient .
RUN dotnet restore

RUN dotnet test TestBikeshareClient/TestBikeshareClient.csproj /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line /p:CoverletOutputFormat=opencover /p:ExcludeByAttribute=ExcludeFromCodeCoverageAttribute

RUN dotnet pack -c Release -o output $VERSION_SUFFIX
