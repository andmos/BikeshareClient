FROM andmos/dotnet-script

COPY main.csx /scripts/main.csx

RUN ["dotnet", "/dotnet-script/dotnet-script.dll", "main.csx" , "dryrun"]

ENTRYPOINT ["dotnet", "/dotnet-script/dotnet-script.dll", "main.csx"] 
