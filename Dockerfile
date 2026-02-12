FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["ElectronicJournal.sln", "./"]
COPY ["Server/ElectronicJournal.Server.csproj", "Server/"]
COPY ["Client/ElectronicJournal.Client.csproj", "Client/"]
COPY ["Shared/ElectronicJournal.Shared.csproj", "Shared/"]

RUN dotnet restore "Server/ElectronicJournal.Server.csproj"

COPY . .
RUN dotnet publish "Server/ElectronicJournal.Server.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "ElectronicJournal.Server.dll"]
