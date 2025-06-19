FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /source

COPY GestaoDispositivos.sln .

COPY src/API/API.csproj ./src/API/
COPY src/Application/Application.csproj ./src/Application/
COPY src/Domain/Domain.csproj ./src/Domain/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/

RUN dotnet restore GestaoDispositivos.sln

COPY src/. ./src/
WORKDIR /source/src/API

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]