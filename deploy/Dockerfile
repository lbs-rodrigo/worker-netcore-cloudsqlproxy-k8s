FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["Example.Worker.Cloudsqlproxy.csproj", "Worker.Cloudsqlproxy/"]
RUN dotnet restore "Worker.Cloudsqlproxy/Example.Worker.Cloudsqlproxy.csproj"
COPY . .
WORKDIR "/src/Worker.Cloudsqlproxy"
RUN dotnet build "Example.Worker.Cloudsqlproxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Worker.Cloudsqlproxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Worker.Cloudsqlproxy.dll"]