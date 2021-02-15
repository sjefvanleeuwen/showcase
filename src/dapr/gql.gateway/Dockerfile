FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["gql.gateway/gql.gateway.csproj", "gql.gateway/"]
RUN dotnet restore "gql.gateway/gql.gateway.csproj"
COPY . .
WORKDIR "/src/gql.gateway"
RUN dotnet build "gql.gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gql.gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gql.gateway.dll"]
