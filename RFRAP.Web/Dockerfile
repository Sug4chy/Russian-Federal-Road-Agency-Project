FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-arm64v8 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy-arm64v8 AS build
WORKDIR /src
COPY ["RFRAP.Web/RFRAP.Web.csproj", "RFRAP.Web/"]
COPY ["RFRAP.Domain/RFRAP.Domain.csproj", "RFRAP.Domain/"]
COPY ["RFRAP.Data/RFRAP.Data.csproj", "RFRAP.Data/"]
RUN dotnet restore "RFRAP.Web/RFRAP.Web.csproj" -r linux-arm64
COPY . .
WORKDIR "/src/RFRAP.Web"
RUN dotnet build "RFRAP.Web.csproj" -c release -o /app/build -r linux-arm64

FROM build AS publish
RUN dotnet publish "RFRAP.Web.csproj" -c release -o /app/publish /p:UseAppHost=false -r linux-arm64

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RFRAP.Web.dll"]