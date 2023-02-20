FROM mcr.microsoft.com/dotnet/sdk:7.0.103-bullseye-slim as builder

ARG VERSION_SUFFIX

WORKDIR /app

# For SourceLink
COPY .git .git

COPY src/ .

# MSBuild arguments 
ENV CollectCoverage=true
ENV CoverletOutputFormat=opencover
ENV Threshold=80
ENV ThresholdType=line
ENV ExcludeByAttribute=ExcludeFromCodeCoverageAttribute

RUN dotnet restore BikeshareClient/

RUN dotnet test BikeshareClient/TestBikeshareClient/TestBikeshareClient.csproj

RUN dotnet pack BikeshareClient/ -c Release -o output $VERSION_SUFFIX
