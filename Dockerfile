FROM mcr.microsoft.com/dotnet/sdk:7.0.100-bullseye-slim as builder

ARG VERSION_SUFFIX

WORKDIR /app

# For SourceLink
COPY .git .git

COPY src/ .

RUN dotnet restore BikeshareClient/

RUN dotnet test BikeshareClient/TestBikeshareClient/TestBikeshareClient.csproj /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line /p:CoverletOutputFormat=opencover /p:ExcludeByAttribute=ExcludeFromCodeCoverageAttribute

RUN dotnet pack BikeshareClient/ -c Release -o output $VERSION_SUFFIX
