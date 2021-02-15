FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dapr.gql.customer/dapr.gql.customer.csproj", "dapr.gql.customer/"]
RUN dotnet restore "dapr.gql.customer/dapr.gql.customer.csproj"
COPY . .
WORKDIR "/src/dapr.gql.customer"
RUN dotnet build "dapr.gql.customer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dapr.gql.customer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dapr.gql.customer.dll"]
