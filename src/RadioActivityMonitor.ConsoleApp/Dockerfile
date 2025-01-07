FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY RadioActivityMonitor.ConsoleApp.csproj ./RadioActivityMonitor.ConsoleApp.csproj

RUN dotnet restore RadioActivityMonitor.ConsoleApp.csproj

COPY . ./

RUN dotnet publish RadioActivityMonitor.ConsoleApp.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RadioActivityMonitor.ConsoleApp.dll"]


