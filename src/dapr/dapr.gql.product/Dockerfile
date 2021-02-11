FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dapr.gql.product/dapr.gql.product.csproj", "dapr.gql.product/"]
RUN dotnet restore "dapr.gql.product/dapr.gql.product.csproj"
COPY . .
WORKDIR "/src/dapr.gql.product"
RUN dotnet build "dapr.gql.product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dapr.gql.product.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dapr.gql.product.dll"]
