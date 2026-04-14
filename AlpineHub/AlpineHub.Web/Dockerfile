FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AlpineHub.Web/AlpineHub.Web.csproj", "AlpineHub.Web/"]
COPY ["AlpineHub.Common/AlpineHub.Common.csproj", "AlpineHub.Common/"]
COPY ["AlpineHub.Data/AlpineHub.Data.csproj", "AlpineHub.Data/"]
COPY ["AlpineHub.Data.Models/AlpineHub.Data.Models.csproj", "AlpineHub.Data.Models/"]
COPY ["AlpineHub.Web.Infrastructure/AlpineHub.Web.Infrastructure.csproj", "AlpineHub.Web.Infrastructure/"]
COPY ["AlpineHub.Core/AlpineHub.Core.csproj", "AlpineHub.Core/"]
RUN dotnet restore "AlpineHub.Web/AlpineHub.Web.csproj"
COPY . .
WORKDIR "/src/AlpineHub.Web"
RUN dotnet build "./AlpineHub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AlpineHub.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlpineHub.Web.dll"]
