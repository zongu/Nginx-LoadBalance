FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore ./WebApiUnit
RUN dotnet publish "WebApiUnit/WebApiUnit.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /src/out ./
ENTRYPOINT ["dotnet", "WebApiUnit.dll"]