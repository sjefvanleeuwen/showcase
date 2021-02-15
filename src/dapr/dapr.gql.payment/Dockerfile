FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dapr.gql.payment/dapr.gql.payment.csproj", "dapr.gql.payment/"]
RUN dotnet restore "dapr.gql.payment/dapr.gql.payment.csproj"
COPY . .
WORKDIR "/src/dapr.gql.payment"
RUN dotnet build "dapr.gql.payment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dapr.gql.payment.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dapr.gql.payment.dll"]
