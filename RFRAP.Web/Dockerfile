FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RFRAP.Web/RFRAP.Web.csproj", "RFRAP.Web/"]
COPY ["RFRAP.Domain/RFRAP.Domain.csproj", "RFRAP.Domain/"]
COPY ["RFRAP.Data/RFRAP.Data.csproj", "RFRAP.Data/"]
RUN dotnet restore "RFRAP.Web/RFRAP.Web.csproj"
COPY . .
WORKDIR "/src/RFRAP.Web"
RUN dotnet build "RFRAP.Web.csproj" -c release -o /app/build

FROM build AS publish
RUN dotnet publish "RFRAP.Web.csproj" -c release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RFRAP.Web.dll"]