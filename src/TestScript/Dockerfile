FROM andmos/dotnet-script

WORKDIR /scripts/

COPY main.csx main.csx

RUN ["dotnet", "script", "main.csx" , "dryrun"]

ENTRYPOINT ["dotnet", "script", "main.csx"] 
