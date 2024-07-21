FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

COPY *.sln ./
COPY Application/Application.csproj Application/
COPY Domain/Domain.csproj Domain/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY RickAndMortyDavivienda/RickAndMortyDavivienda.csproj RickAndMortyDavivienda/
RUN dotnet restore

COPY . ./
RUN dotnet publish RickAndMortyDavivienda -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "RickAndMortyDavivienda.dll"]