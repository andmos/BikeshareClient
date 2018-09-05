FROM microsoft/dotnet:2.1-sdk as builder

ARG VERSION_SUFFIX

WORKDIR /app 

COPY src/BikeshareClient .
RUN dotnet restore

RUN dotnet test TestBikeshareClient/TestBikeshareClient.csproj /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line

RUN dotnet pack -c Release -o output $VERSION_SUFFIX
