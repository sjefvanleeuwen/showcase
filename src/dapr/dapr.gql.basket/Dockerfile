FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dapr.gql.basket/dapr.gql.basket.csproj", "dapr.gql.basket/"]
RUN dotnet restore "dapr.gql.basket/dapr.gql.basket.csproj"
COPY . .
WORKDIR "/src/dapr.gql.basket"
RUN dotnet build "dapr.gql.basket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dapr.gql.basket.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dapr.gql.basket.dll"]
