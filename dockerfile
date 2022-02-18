FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["hp-api/hp-api.csproj", "hp-api/"]
RUN dotnet restore "hp-api/hp-api.csproj"
COPY . .
WORKDIR "/src/hp-api"
RUN dotnet build "hp-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hp-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet hp-api.dll
