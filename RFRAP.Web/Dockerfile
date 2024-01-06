FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RFRAP.Web/RFRAP.Web.csproj", "RFRAP.Web/"]
RUN dotnet restore "RFRAP.Web/RFRAP.Web.csproj"
COPY . .
WORKDIR "/src/RFRAP.Web"
RUN dotnet build "RFRAP.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RFRAP.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RFRAP.Web.dll"]
