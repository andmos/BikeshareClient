FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim as builder

ARG VERSION_SUFFIX

WORKDIR /app 

# For SourceLink
COPY .git .git

COPY src/BikeshareClient .
RUN dotnet restore

RUN dotnet test TestBikeshareClient/TestBikeshareClient.csproj /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line /p:CoverletOutputFormat=opencover /p:ExcludeByAttribute=ExcludeFromCodeCoverageAttribute

RUN dotnet pack -c Release -o output $VERSION_SUFFIX
