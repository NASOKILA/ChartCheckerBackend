FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ChartChecker.Backend/ChartChecker.Backend.csproj", "ChartChecker.Backend/"]
COPY ["ChartChecker.Models/ChartChecker.Models.csproj", "ChartChecker.Models/"]
COPY ["ChartChecker.Data/ChartChecker.Data.csproj", "ChartChecker.Data/"]
RUN dotnet restore "ChartChecker.Backend/ChartChecker.Backend.csproj"
COPY . .
WORKDIR "/src/ChartChecker.Backend"
RUN dotnet build "ChartChecker.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChartChecker.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChartChecker.Backend.dll"]